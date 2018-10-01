using EBookie.model;
using EBookie.services;
using EBookie.viewmodel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EBookie.view
{
    /// <summary>
    /// Interaktionslogik für AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        public ObservableCollection<PicSource> PicSources { get; set; }

        // Instanz der Page (Klasse)
        static AboutPage instance;

        public static AboutPage Instance
        {
            get { return instance; }
        }

        public AboutPage()
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
            AppWindow.Instance.DataContext = AboutPageViewModel.Instance;
            instance = this;
        }

        private void init_UI_Elements()
        {
            lbl_version.Content = App.PROGRAM_VERSION;
            lbl_date.Content = App.LAST_CHANGE_DATE;

            DateTime dateTime = DateTime.Now;
            string thisYear = dateTime.ToString("yyyy");

            tb_footnote_1.Text = "\u00a9 2016-" + thisYear;

            dg_pic_sources.ItemsSource = PicSource.List;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            }
            catch { }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            AppController.Instance.navigate_to_page("LicenseTermsPage", null);
        }

        private void AboutPage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!AppWindow.Instance.DONT_SAVE_BACK_ENTRY)
            {
                // Zurück-Eintrag hinzufügen
                AppController.Instance.BACKSTACK.Add(new PageEntry("AboutPage", null));
            }

            AboutPageViewModel.Instance = null;
        }

        private void AboutPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}
