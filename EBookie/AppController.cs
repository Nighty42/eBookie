using EBookie.model;
using EBookie.services;
using EBookie.view;
using EBookie.viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EBookie
{
    public class AppController
    {
        public Settings SETTINGS;
        public string PATH_TO_PROGRAM;
        public string PATH_TO_SETTINGS;
        public PageEntry HOMEPAGE;

        public ObservableCollection<PageEntry> BACKSTACK;
        public List<Language> SUPPORTED_LANGUAGES;

        public bool SOMETHING_CHANGED = false;

        private static AppController instance;

        public static AppController Instance
        {
            get { return instance ?? (instance = new AppController()); }
        }

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public ObservableCollection<T> DeepCopy<T>(ObservableCollection<T> list) where T : ICloneable
        {
            ObservableCollection<T> newList = new ObservableCollection<T>();
            foreach (T rec in list)
            {
                newList.Add((T)rec.Clone());
            }
            return newList;
        }

        // Aufruf durch Klick auf MenuItem in Tray
        public void btn_apply_MainPage_click(object sender, RoutedEventArgs e)
        {
            navigate_to_page("MainPage", null);
            AppWindow.Instance.DONT_SAVE_BACK_ENTRY = true;
            MainPageViewModel.Instance.raise_btnApply_ClickedEvent();
        }

        public void navigate_to_page(string pagename, object[] args)
        {
            Type type = Type.GetType("EBookie.view." + pagename);
            Page page = Activator.CreateInstance(type, args) as Page;

            AppWindow.Instance._FRAME.Navigate(page);
        }

        public void logged_in_out_routine(int logged_in_out)
        {
            switch (logged_in_out)
            {
                // Logged_in
                case 1:
                    AppWindow.Instance.mi_Extras.IsEnabled = true;
                    break;
                // Logged_out
                case 2:
                    exit_app(true);
                    break;
            }

            AppWindow.Instance.DONT_SAVE_BACK_ENTRY = true;
        }

        public void exit_prepare()
        {
            // Settings speichern
            ReadWriteService.Instance.write_settings_to_xml();
        }

        public void exit_app(bool restart)
        {
            // Daten speichern und Taskbar abbauen
            exit_prepare();

            // Anwendung neustarten
            if (restart)
            {
                Process.Start(Application.ResourceAssembly.Location);
            }

            // Anwendung beenden
            Environment.Exit(0);
        }

        public void init_language()
        {
            set_app_language(SETTINGS.LANGUAGE.CODE);
        }

        // Sprache der Anwendung ändern
        public void change_language()
        {
            if (languages.Resources.Culture.Name.Equals("de-DE"))
            {
                set_app_language("en-GB");
            }
            else
            {
                set_app_language("de-DE");
            }
        }

        // Sprache der Anwendung setzen
        private void set_app_language(string language)
        {
            CultureInfo new_culture;

            if (language.Equals("de-DE"))
            {
                new_culture = new CultureInfo("de-DE");
                SETTINGS.LANGUAGE.NAME = "Deutsch";
                SETTINGS.LANGUAGE.CODE = "de-DE";
            }
            else
            {
                new_culture = new CultureInfo("en-GB");
                SETTINGS.LANGUAGE.NAME = "English";
                SETTINGS.LANGUAGE.CODE = "en-GB";
            }

            // Culture der Anwendung ändern
            languages.Resources.Culture = new_culture;
            Thread.CurrentThread.CurrentCulture = new_culture;
        }
    }
}
