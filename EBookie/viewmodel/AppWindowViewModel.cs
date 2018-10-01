using System.Windows;
using System.Windows.Media;
using System.Linq;
using EBookie.model;
using EBookie.services;
using EBookie.view;

// ToDo:
// - Nachricht mit Placeholder wird doppelt angezeigt

namespace EBookie.viewmodel
{
    public class AppWindowViewModel
    {
        static AppWindowViewModel instance;

        public static AppWindowViewModel Instance
        {
            get { return instance ?? (instance = new AppWindowViewModel()); }
        }

        public void btn_Home_Clicked()
        {
            AppController.Instance.navigate_to_page(AppController.Instance.HOMEPAGE.PAGE, AppController.Instance.HOMEPAGE.ARGS);

            AppController.Instance.BACKSTACK.Clear();
            AppController.Instance.HOMEPAGE = null;

            AppWindow.Instance.DONT_SAVE_BACK_ENTRY = true;
        }

        public void btn_Back_Clicked()
        {
            int backStack_index = AppController.Instance.BACKSTACK.Count - 1;

            // Seite, die aufgerufen werden soll, ermitteln und aufrufen
            PageEntry backEntry;

            if (AppController.Instance.BACKSTACK.Count > 0)
            {
                backEntry = AppController.Instance.BACKSTACK.ElementAt(backStack_index);
                AppController.Instance.BACKSTACK.RemoveAt(AppController.Instance.BACKSTACK.Count - 1);
            }
            else
            {
                backEntry = AppController.Instance.HOMEPAGE;
                AppController.Instance.HOMEPAGE = null;
            }

            AppController.Instance.navigate_to_page(backEntry.PAGE, backEntry.ARGS);

            AppWindow.Instance.DONT_SAVE_BACK_ENTRY = true;
        }

        //public void btn_Reset_Clicked()
        //{

        //}

        //public void btn_Delete_Clicked()
        //{

        //}

        //public void btn_New_Clicked()
        //{

        //}

        //public void btn_Apply_Clicked()
        //{

        //}

        public void btn_Language_Clicked()
        {
            MessageBoxResult answer = MessageBox.Show(languages.Resources.mbx_q_restart_app_1 + "\n\n" + languages.Resources.mbx_q_restart_app_2, languages.Resources.change_language, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (answer != MessageBoxResult.Cancel)
            {
                AppController.Instance.change_language();

                if (answer == MessageBoxResult.Yes)
                {
                    // Settings speichern und Anwendung neustarten
                    AppController.Instance.exit_app(true);
                }
            }
        }

        public void btn_Exit_Clicked()
        {
            AppController.Instance.exit_app(false);
        }
    }
}
