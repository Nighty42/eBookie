using eBookie.model;
using eBookie.services;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace eBookie
{
    /// <summary>
    /// Interaktionslogik für AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public ContextMenu tray_context_menu;

        public static AppWindow Instance { get; set; } = new AppWindow();

        public AppWindow()
        {
            InitializeComponent();

            if (Settings.Instance.Language.Code.Equals("de-DE"))
            {
                img_btnLanguage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/english.png"));
            }
            else
            {
                img_btnLanguage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/german.png"));
            }
        }

        private void FrameContentRendered(object sender, EventArgs e)
        {
            if (NavigationController.Instance.PageStack.Count > 0 || NavigationController.Instance.Homepage != null)
            {
                btn_Back.IsEnabled = true;
            }
            else
            {
                btn_Back.IsEnabled = false;
            }

            NavigationController.Instance.DontSaveBackEntry = false;
        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            NavigationController.Instance.Home();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationController.Instance.Back();
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Language_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show(i18n.Resources.mbx_q_restart_app_1 + "\n\n" + i18n.Resources.mbx_q_restart_app_2, i18n.Resources.change_language, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (answer != MessageBoxResult.Cancel)
            {
                LanguageController.Instance.ChangeLanguage();

                if (answer == MessageBoxResult.Yes)
                {
                    // Settings speichern und Anwendung neustarten
                    App.Instance.Exit(true);
                }
            }
        }

        private void btn_Sync_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Instance.Exit(false);
        }

        //*********************************************************************//
        //*********************** MenuItem-Click-Events ***********************//
        //*********************************************************************//

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            App.Instance.Exit(false);
        }

        // Datei wählen, Systeme aus ausgewählter Datei importieren
        private void ImportBooksItem_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension
            //dlg.Filter = languages.Resources.dlg_filter_dat_ini;

            bool? result = dlg.ShowDialog();

            // Prüfen, ob Änderungen vorgenommen wurden
            if (result == true)
            {
                // Wenn Datei verschlüsselt, Passworteingabe ermöglichen, versuchen zu entschlüsseln, max. 3 Versuche
                if (dlg.FileName.Contains(".ini"))
                {
                   
                }
                else
                {
                    
                }
            }
            else
            {
                MessageCreationService.create_message("cancelled_import", null, 1);
            }
        }

        private void SettingsItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationController.Instance.NavigateToPage("SettingsPage", null);
        }

        private void FeedbackItem_Click(object sender, RoutedEventArgs e)
        {
            string url = "mailto:mariusraht+1@gmail.com?subject=eBookie - Feedback";
            Process.Start(url);
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            NavigationController.Instance.NavigateToPage("AboutPage", null);
        }

        //*****************************************************************************************//
        //*****************************************************************************************//

        private void AppWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Instance.Exit(false);
        }
    }
}
