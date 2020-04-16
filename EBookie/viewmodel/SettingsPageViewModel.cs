using System;
using System.Windows.Media.Imaging;

namespace eBookie.viewmodel
{
    public class SettingsPageViewModel
    {
        static SettingsPageViewModel instance;

        public static SettingsPageViewModel Instance
        {
            get { return instance ?? (instance = new SettingsPageViewModel()); }
            set { instance = value; } // Nötig, damit ViewModel-Instanz auf null gesetzt werden kann
        }

        private SettingsPageViewModel()
        {
            init_AppWindow_GUIElements();

            initEnabledButtons();
        }

        private void init_AppWindow_GUIElements()
        {
            AppWindow.Instance.Title = i18n.Resources.settings;
            AppWindow.Instance.Icon = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/settings.png"));
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
