using eBookie.services;
using eBookie.view;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace eBookie.viewmodel
{
    public class AboutPageViewModel
    {
        static AboutPageViewModel instance;

        public static AboutPageViewModel Instance
        {
            get { return instance ?? (instance = new AboutPageViewModel()); }
            set { instance = value; } // Nötig, damit ViewModel-Instanz auf null gesetzt werden kann
        }

        private AboutPageViewModel()
        {
            init_AppWindow_GUIElements();

            initEnabledButtons();
        }

        private void init_AppWindow_GUIElements()
        {
            AppWindow.Instance.Title = i18n.Resources.AboutPage_title;
            AppWindow.Instance.Icon = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/info.png"));
        }

        private void initEnabledButtons()
        {
            AppWindow.Instance.btn_Home.IsEnabled = true;
            AppWindow.Instance.btn_Reset.IsEnabled = false;
            AppWindow.Instance.btn_Save.IsEnabled = false;
            AppWindow.Instance.btn_Sync.IsEnabled = false;
            AppWindow.Instance.btn_Language.IsEnabled = true;
            AppWindow.Instance.btn_Exit.IsEnabled = true;
        }
    }
}
