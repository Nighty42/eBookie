using eBookie.model;
using eBookie.services;
using eBookie.viewmodel;
using System.Windows;
using System.Windows.Controls;

namespace eBookie.view
{
    /// <summary>
    /// Interaktionslogik für SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        // Instanz der Page (Klasse)
        private static SettingsPage instance;

        public static SettingsPage Instance
        {
            get { return instance; }
        }

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Initialize()
        {

        }

        private void init_data_context()
        {
            DataContext = this;
            AppWindow.Instance.DataContext = SettingsPageViewModel.Instance;
            instance = this;
        }

        private void SettingsPage_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!NavigationController.Instance.DontSaveBackEntry)
            {
                // Zurück-Eintrag hinzufügen
                NavigationController.Instance.PageStack.Add(new PageEntry("SettingsPage", null));
            }

            SettingsPageViewModel.Instance = null;
        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}
