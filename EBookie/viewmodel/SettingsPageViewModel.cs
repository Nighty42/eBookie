using EBookie.model;
using EBookie.services;
using EBookie.view;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EBookie.viewmodel
{
    public class SettingsPageViewModel
    {
        static SettingsPageViewModel instance;

        public static SettingsPageViewModel Instance
        {
            get { return instance ?? (instance = new SettingsPageViewModel()); }
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

        private SettingsPageViewModel()
        {
            init_AppWindow_GUIElements();

            initEnabledButtons();

            initButtonCommands();
        }

        private void init_AppWindow_GUIElements()
        {
            AppWindow.Instance.Title = languages.Resources.settings;
            AppWindow.Instance.Icon = new BitmapImage(new Uri("pack://siteoforigin:,,,/images/settings.png"));
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
            btn_Cancel = new RelayCommand(btn_Cancel_Clicked);
            btn_Reset = new RelayCommand(btn_Reset_Clicked);
            btn_Delete = new RelayCommand(btn_Delete_Clicked);
            btn_Create = new RelayCommand(btn_Create_Clicked);
            btn_Apply = new RelayCommand(btn_Apply_Clicked);
            btn_Language = new RelayCommand(btn_Language_Clicked);
            btn_Exit = new RelayCommand(btn_Exit_Clicked);
        }

        private bool CanClickButton()
        {
            return true;
        }

        private void btn_Home_Clicked()
        {
            AppWindowViewModel.Instance.btn_Home_Clicked();
        }

        private void btn_Back_Clicked()
        {
            AppWindowViewModel.Instance.btn_Back_Clicked();
        }

        private void btn_Cancel_Clicked()
        {

        }

        private void btn_Delete_Clicked()
        {

        }

        private void btn_Reset_Clicked()
        {
            
        }

        private void btn_Create_Clicked()
        {

        }

        private void btn_Apply_Clicked()
        {
            
        }

        private void btn_Language_Clicked()
        {
            AppWindowViewModel.Instance.btn_Language_Clicked();
        }

        private void btn_Exit_Clicked()
        {
            AppWindowViewModel.Instance.btn_Exit_Clicked();
        }
    }
}
