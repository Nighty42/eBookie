using eBookie.model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace eBookie.viewmodel
{
    public class MainPageViewModel
    {
        private static MainPageViewModel instance;

        public static MainPageViewModel Instance
        {
            get { return instance ?? (instance = new MainPageViewModel()); }
            set { instance = value; } // damit ViewModel-Instanz auf null gesetzt werden kann
        }

        public Visibility cb_configs_visibility { get; set; }
        public Visibility cb_user_visibility { get; set; }
        public Visibility cb_tcodes_visibility { get; set; }

        public List<IField> IFIELDS { get; set; }

        private MainPageViewModel()
        {
            InitAppWindowGUIElements();

            InitEnabledButtons();
        }

        private void InitAppWindowGUIElements()
        {
            AppWindow.Instance.Title = i18n.Resources.appTitle;
            AppWindow.Instance.Icon = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/ebookie.png"));
        }

        private void InitEnabledButtons()
        {
            AppWindow.Instance.btn_Home.IsEnabled = false;
            AppWindow.Instance.btn_Reset.IsEnabled = false;
            AppWindow.Instance.btn_Save.IsEnabled = false;
            AppWindow.Instance.btn_Sync.IsEnabled = false;
            AppWindow.Instance.btn_Language.IsEnabled = true;
            AppWindow.Instance.btn_Exit.IsEnabled = true;
        }
    }
}
