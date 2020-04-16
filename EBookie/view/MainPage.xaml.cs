using eBookie.model;
using eBookie.services;
using eBookie.viewmodel;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace eBookie.view
{
    /// <summary>
    /// Interaktionslogik für MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = EBookFolderList.Instance;
            lv_eBook_folders.ItemsSource = EBookFolderList.Instance;
        }

        private void Initialize()
        {
            Init_data_context();
        }

        private void Init_data_context()
        {
            AppWindow.Instance.DataContext = MainPageViewModel.Instance;
        }

        private void OpenEBookFolderPath(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            EBookFolder folder = button.DataContext as EBookFolder;
            string path = folder.Path;

            if (path.Length.Equals(0) || !Directory.Exists(path))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            }

            Process.Start("explorer.exe", @path);
        }

        private void RemoveEBookFolder(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            EBookFolder folder = button.DataContext as EBookFolder;
            EBookFolderList.Instance.Remove(folder);
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {

        }

        private void OpenFilePath(object sender, RoutedEventArgs e)
        {

        }

        private void MainPage_Unloaded(object sender, RoutedEventArgs e)
        {
            // Zurück-Eintrag hinzufügen
            NavigationController.Instance.Homepage = new PageEntry("MainPage", null);
            MainPageViewModel.Instance = null;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();

            NavigationController.Instance.Homepage = null;
        }

        private void lv_eBook_folders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            EBookFolder eBookFolder = listBox.SelectedItem as EBookFolder;
            lv_eBooks.ItemsSource = eBookFolder.EBookList;
        }
    }
}
