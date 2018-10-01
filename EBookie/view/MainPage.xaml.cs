using EBookie.model;
using EBookie.viewmodel;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EBookie.view
{
    /// <summary>
    /// Interaktionslogik für MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<EBookFolder> EBOOKFOLDERS = new List<EBookFolder>(new EBookFolder[] { new EBookFolder("[Alle E-Books anzeigen...]", "---"), new EBookFolder("D:/E-Books/","TEST"), new EBookFolder("Z:/Privat/Freizeit/E-Books/","KOBO GLO HD") });

        // Instanz der Page (Klasse)
        private static MainPage instance;

        public static MainPage Instance
        {
            get { return instance; }
        }

        public MainPage()
        {
            InitializeComponent();

            lv_eBookFolders.ItemsSource = EBOOKFOLDERS;
        }

        private void Initialize()
        {
            init_data_context();
        }

        private void init_data_context()
        {
            AppWindow.Instance.DataContext = MainPageViewModel.Instance;
            instance = this;
        }

        private void OpenEBookFolderPath(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveEBookFolder(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {

        }

        private void OpenPath(object sender, RoutedEventArgs e)
        {

        }

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            // Zurück-Eintrag hinzufügen
            AppController.Instance.HOMEPAGE = new PageEntry("MainPage", null);

            MainPageViewModel.Instance = null;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();

            AppController.Instance.HOMEPAGE = null;
        }
    }
}
