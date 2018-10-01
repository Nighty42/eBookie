using System.Windows;
using System.Windows.Input;
using System;
using System.Windows.Media.Imaging;
using EBookie.services;
using System.Linq;
using EBookie.view;

namespace EBookie.viewmodel
{
    public class LicenseTermsPageViewModel
    {
        private static LicenseTermsPageViewModel instance;

        public static LicenseTermsPageViewModel Instance
        {
            get { return instance ?? (instance = new LicenseTermsPageViewModel()); }
            set { instance = value; } // Nötig, damit ViewModel-Instanz auf null gesetzt werden kann
        }

        public ICommand btn_Home { get; private set; }
        public ICommand btn_Back { get; private set; }
        public ICommand btn_Cancel { get; private set; }
        public ICommand btn_Reset { get; private set; }
        public ICommand btn_Delete { get; private set; }
        public ICommand btn_Create { get; private set; }
        public ICommand btn_Apply { get; private set; }
        public ICommand btn_Language { get; private set; }
        public ICommand btn_Logout { get; private set; }
        public ICommand btn_Exit { get; private set; }

        private LicenseTermsPageViewModel()
        {
            init_AppWindow_GUIElements();

            initEnabledButtons();

            initButtonCommands();
        }

        private void init_AppWindow_GUIElements()
        {
            AppWindow.Instance.Title = languages.Resources.LicenseTermsPage_title;
            AppWindow.Instance.Icon = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/ebookie.png"));
        }

        private void initEnabledButtons()
        {
            AppWindow.Instance.btn_Home.IsEnabled = true;
            //AppWindow.Instance.btn_Back.IsEnabled = true;
            AppWindow.Instance.btn_Reset.IsEnabled = false;
            AppWindow.Instance.btn_Save.IsEnabled = false;
            AppWindow.Instance.btn_Sync.IsEnabled = false;
            AppWindow.Instance.btn_Language.IsEnabled = true;
            AppWindow.Instance.btn_Exit.IsEnabled = true;
        }

        private void initButtonCommands()
        {
            btn_Home = new RelayCommand(btn_Home_Clicked);
            btn_Back = new RelayCommand(btn_Back_Clicked);
            btn_Reset = new RelayCommand(btn_Reset_Clicked);
            btn_Apply = new RelayCommand(btn_Apply_Clicked);
            btn_Language = new RelayCommand(btn_Language_Clicked);
            btn_Exit = new RelayCommand(btn_Exit_Clicked);
        }

        private bool CanClickButton()
        {
            return true;
        }

        public void btn_Home_Clicked()
        {
            AppWindowViewModel.Instance.btn_Home_Clicked();
        }

        public void btn_Back_Clicked()
        {
            AppWindowViewModel.Instance.btn_Back_Clicked();
        }

        public void btn_Reset_Clicked()
        {

        }

        public void btn_Apply_Clicked()
        {

        }

        public void btn_Sync_Clicked()
        {

        }

        public void btn_Language_Clicked()
        {
            AppWindowViewModel.Instance.btn_Language_Clicked();
        }

        public void btn_Exit_Clicked()
        {
            MessageBox.Show("LicenseTermsPageViewModel");
            AppWindowViewModel.Instance.btn_Exit_Clicked();
        }
    }
}
