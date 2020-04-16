using System;
using System.Windows.Media.Imaging;

namespace eBookie.viewmodel
{
    public class LicenseTermsPageViewModel
    {
        private static LicenseTermsPageViewModel instance;

        public static LicenseTermsPageViewModel Instance
        {
            get { return instance ?? (instance = new LicenseTermsPageViewModel()); }
            set { instance = value; } // Nötig, damit ViewModel-Instanz auf null gesetzt werden kann
        }

        private LicenseTermsPageViewModel()
        {
            init_AppWindow_GUIElements();

            initEnabledButtons();
        }

        private void init_AppWindow_GUIElements()
        {
            AppWindow.Instance.Title = i18n.Resources.LicenseTermsPage_title;
            AppWindow.Instance.Icon = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/ebookie.png"));
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
