using EBookie.model;
using EBookie.viewmodel;
using System.Windows;
using System.Windows.Controls;

namespace EBookie.view
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
            if (!AppWindow.Instance.DONT_SAVE_BACK_ENTRY)
            {
                // Zurück-Eintrag hinzufügen
                AppController.Instance.BACKSTACK.Add(new PageEntry("SettingsPage", null));
            }

            SettingsPageViewModel.Instance = null;
        }

        private void SettingsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}
