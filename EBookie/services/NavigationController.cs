using eBookie.model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace eBookie.services
{
    public class NavigationController
    {
        public bool DontSaveBackEntry = false;
        public string PathToProgram;
        public string PathToSettings;
        public PageEntry Homepage;
        public ObservableCollection<PageEntry> PageStack = new ObservableCollection<PageEntry>();

        public static NavigationController Instance { get; set; } = new NavigationController();

        private NavigationController()
        {
            PathToProgram = AppDomain.CurrentDomain.BaseDirectory;
            PathToSettings = PathToProgram + "settings.xml";
        }

        public void Back()
        {
            int backStack_index = PageStack.Count - 1;

            // Seite, die aufgerufen werden soll, ermitteln und aufrufen
            PageEntry backEntry;

            if (PageStack.Count > 0)
            {
                backEntry = PageStack.ElementAt(backStack_index);
                PageStack.RemoveAt(PageStack.Count - 1);
            }
            else
            {
                backEntry = Homepage;
                Homepage = null;
            }

            NavigateToPage(backEntry.Page, backEntry.Args);

            DontSaveBackEntry = true;
        }

        public void Home()
        {
            NavigateToPage(Homepage.Page, Homepage.Args);

            PageStack.Clear();
            Homepage = null;

            DontSaveBackEntry = true;
        }

        public void NavigateToPage(string pagename, object[] args)
        {
            Type type = Type.GetType("eBookie.view." + pagename);
            Page page = Activator.CreateInstance(type, args) as Page;

            AppWindow.Instance.Frame.Navigate(page);
        }
    }
}
