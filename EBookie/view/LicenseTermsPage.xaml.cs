using EBookie.model;
using EBookie.services;
using EBookie.viewmodel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EBookie.view
{
    /// <summary>
    /// Interaktionslogik für LicenseTermsPage.xaml
    /// </summary>
    public partial class LicenseTermsPage : Page
    {
        // Instanz der Page (Klasse)
        static LicenseTermsPage instance;

        public static LicenseTermsPage Instance
        {
            get { return instance; }
        }

        public LicenseTermsPage()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            init_data_context();

            init_UI_Elements();

            MessageCreationService.create_message("waiting_for_input", null, 0);
        }

        private void init_data_context()
        {
            AppWindow.Instance.DataContext = LicenseTermsPageViewModel.Instance;
            instance = this;
        }

        private void init_UI_Elements()
        {
            DateTime dateTime = DateTime.Now;
            string thisYear = dateTime.ToString("yyyy");

            tb_copyright.Text = "Copyright (c) 2016 - " + thisYear;
        }

        private void LicenseTermsPage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!AppWindow.Instance.DONT_SAVE_BACK_ENTRY)
            {
                // Zurück-Eintrag hinzufügen
                AppController.Instance.BACKSTACK.Add(new PageEntry("LicenseTermsPage", null));
            }

            LicenseTermsPageViewModel.Instance = null;
        }

        private void LicenseTermsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}
