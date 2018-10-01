using EBookie.model;
using EBookie.services;
using EBookie.view;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace EBookie
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static string PROGRAM_VERSION;
        public static string LAST_CHANGE_DATE;

        /// <summary>
        /// Brings window to foreground
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Shows ionic given window
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);

        /// <summary>
        /// Check, given window is ionic
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);

        [STAThread]
        protected override void OnStartup(StartupEventArgs e)
        {
            // Restore-Mode
            const int SwRestore = 9;

            // Prüfen, ob Prozess bereits läuft
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                // try to find process by name
                Process[] localByName = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

                // get handle of first process
                IntPtr handle = localByName[0].MainWindowHandle;

                // check iconic status
                if (IsIconic(handle))
                {
                    // show window
                    ShowWindow(handle, SwRestore);
                }

                // bring to front
                SetForegroundWindow(handle);

                Environment.Exit(0);
            }
            else
            {
                // Letztes Build-Datum und Programmversion ermitteln
                get_app_info();

                // Globale Variablen initialisieren
                declare_globals();

                // Einstellungen auslesen
                ReadWriteService.Instance.read_out_settings_xml();

                // Sprache der Anwendung setzen
                AppController.Instance.init_language();

                // Anwendung erzeugen
                new AppWindow();

                AppController.Instance.navigate_to_page("MainPage", null);

                Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();

                AppWindow.Instance.Show();
                AppWindow.Instance.Activate();
            }
        }

        private void get_app_info()
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            PROGRAM_VERSION = string.Format(CultureInfo.InvariantCulture, @"{0}.{1}.{2} (Alpha)", v.Major, v.Minor, v.Build);

            DateTime dt = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            LAST_CHANGE_DATE = dt.ToString("dd.MM.yyyy");
        }

        private void declare_globals()
        {
            AppController.Instance.BACKSTACK = new ObservableCollection<PageEntry>();

            AppController.Instance.SUPPORTED_LANGUAGES = new List<Language>();

            AppController.Instance.SUPPORTED_LANGUAGES.Add(new Language("Deutsch", "de-DE"));
            AppController.Instance.SUPPORTED_LANGUAGES.Add(new Language("English", "en-GB"));

            AppController.Instance.PATH_TO_PROGRAM = AppDomain.CurrentDomain.BaseDirectory;
            AppController.Instance.PATH_TO_SETTINGS = AppController.Instance.PATH_TO_PROGRAM + "settings.xml";

            // Einstellungen aufbauen
            AppController.Instance.SETTINGS = new Settings();

            // PicSources erzeugen
            PicSource.init_PicSources();

            // Standard-Anwendungssprache anhand Systemsprache setzen
            AppController.Instance.SETTINGS.STD_LANGUAGE = AppController.Instance.SUPPORTED_LANGUAGES.Find(x => x.CODE == CultureInfo.CurrentCulture.Name);

            if (AppController.Instance.SETTINGS.STD_LANGUAGE == null)
            {
                AppController.Instance.SETTINGS.STD_LANGUAGE = AppController.Instance.SUPPORTED_LANGUAGES.Find(x => x.CODE == "en-GB");
            }
        }
    }
}
