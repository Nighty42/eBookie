using eBookie.model;
using eBookie.services;
using eBookie.viewmodel;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace eBookie.view
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
            InitDataContext();

            InitUIElements();

            MessageCreationService.create_message("waiting_for_input", null, 0);
        }

        private void InitDataContext()
        {
            AppWindow.Instance.DataContext = AboutPageViewModel.Instance;
            instance = this;
        }

        private void InitUIElements()
        {
            lbl_version.Content = App.Instance.ProgramVersion;
            lbl_date.Content = App.Instance.LastModified;

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
            NavigationController.Instance.NavigateToPage("LicenseTermsPage", null);
        }

        private void AboutPage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!NavigationController.Instance.DontSaveBackEntry)
            {
                // Zurück-Eintrag hinzufügen
                NavigationController.Instance.PageStack.Add(new PageEntry("AboutPage", null));
            }

            AboutPageViewModel.Instance = null;
        }

        private void AboutPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}
