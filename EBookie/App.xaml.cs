using eBookie.services;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Threading;

namespace eBookie
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public static App Instance { get; set; }

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
            Instance = this;

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
                GetAppInfo();

                // Einstellungen auslesen
                ReadWriteService.Instance.ReadSettings();

                // Sprache der Anwendung setzen
                LanguageController.Instance.InitLanguage();

                // Anwendung erzeugen
                new AppWindow();

                NavigationController.Instance.NavigateToPage("MainPage", null);

                Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => { })).Wait();

                AppWindow.Instance.Show();
                AppWindow.Instance.Activate();
            }
        }

        public string ProgramVersion { get; set; }
        public string LastModified { get; set; }
        public bool HasChanged { get; set; } = false;

        public void PrepareExit()
        {
            // Settings speichern
            ReadWriteService.Instance.WriteSettings();
        }

        public new void Exit(bool restart)
        {
            // Daten speichern und Taskbar abbauen
            PrepareExit();

            // Anwendung neustarten
            if (restart)
            {
                Process.Start(ResourceAssembly.Location);
            }

            // Anwendung beenden
            Current.Shutdown();
        }

        public void GetAppInfo()
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            ProgramVersion = string.Format(CultureInfo.InvariantCulture, @"{0}.{1}.{2} (Alpha)", v.Major, v.Minor, v.Build);

            DateTime dt = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            LastModified = dt.ToString("dd.MM.yyyy");
        }
    }
}
