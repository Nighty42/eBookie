using EBookie.services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EBookie
{
    /// <summary>
    /// Interaktionslogik für AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public bool DONT_SAVE_BACK_ENTRY = false;

        public ContextMenu tray_context_menu;

        // Instanz des Windows (Klasse)
        static AppWindow instance;

        public static AppWindow Instance
        {
            get { return instance; }
        }

        public AppWindow()
        {
            InitializeComponent();

            instance = this;

            if (AppController.Instance.SETTINGS.LANGUAGE.CODE.Equals("de-DE"))
            {
                img_btnLanguage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/english.png"));
            }
            else
            {
                img_btnLanguage.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/german.png"));
            }
        }

        private void _FRAME_ContentRendered(object sender, EventArgs e)
        {
            if (AppController.Instance.BACKSTACK.Count > 0 || AppController.Instance.HOMEPAGE != null)
            {
                btn_Back.IsEnabled = true;
            }
            else
            {
                btn_Back.IsEnabled = false;
            }

            DONT_SAVE_BACK_ENTRY = false;
        }

        //*********************************************************************//
        //*********************** MenuItem-Click-Events ***********************//
        //*********************************************************************//

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            AppController.Instance.exit_app(false);
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
            AppController.Instance.navigate_to_page("SettingsPage", null);
        }

        private void FeedbackItem_Click(object sender, RoutedEventArgs e)
        {
            string url = "mailto:nighty42@mailbox.org?subject=eBookie - Feedback";
            Process.Start(url);
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            AppController.Instance.navigate_to_page("AboutPage", null);
        }

        //*****************************************************************************************//
        //*****************************************************************************************//

        private void AppWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AppController.Instance.exit_app(false);
        }
    }
}
