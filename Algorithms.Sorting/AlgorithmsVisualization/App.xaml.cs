using AlgorithmsVisualization.ViewModels;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace AlgorithmsVisualization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly string WaitHandleName = "Algoritms" + Environment.UserName;
        private static EventWaitHandle waitHandle;
        private volatile bool disposed;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool created;
            waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, WaitHandleName, out created);

            if (created)
            {
                CultureInfo info = new CultureInfo("ru-Ru");
                Thread.CurrentThread.CurrentCulture = info;
                Thread.CurrentThread.CurrentUICulture = info;

                var mainWindow = new MainWindow { DataContext = new MainWindowViewModel() };

                mainWindow.Closed += (sender, e) =>
                {
                    Application.Current.Shutdown();
                };
                mainWindow.Show();
            }
            else
            {
                try
                {
                    waitHandle = EventWaitHandle.OpenExisting(WaitHandleName);
                    waitHandle.Set();
                }
                finally
                {
                    Shutdown();
                }
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if (!disposed)
            {
                disposed = true;
            }

            if (!disposed)
            {
                disposed = true;
                waitHandle.Dispose();
            }
                Process.GetCurrentProcess().Kill();
        }
    }
}
