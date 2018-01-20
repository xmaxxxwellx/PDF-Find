using Model;
using System.Windows;
using ViewModel;

using System.Windows.Threading;

namespace View {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void Application_Startup(object sender, StartupEventArgs e) {
            // Global exception handling  
            Current.DispatcherUnhandledException +=
                new DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);

            if (e.Args.Length == 0) {
                SettingsWindow settingsWindow = new SettingsWindow();
                settingsWindow.Show();
            }
            else {
                ReportDataModel reportDataModel = new ReportDataModel(new RegistryApplicationConfigurator());
                string path = e.Args[0].ToString();
                ReportConfiguration report = reportDataModel.FindReport(path);
                if (report == null) {
                    if (reportDataModel.FindGroup(path) != null) {
                        PrinterSettingsWindow settingsWindow = new PrinterSettingsWindow();
                        settingsWindow.Show();
                    }
                    else {
                        reportDataModel.OpenInReader(path);
                    }
                }
                else {
                    reportDataModel.OpenForPrint(path, report);
                }
            }

            
        }

        public void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {

#if DEBUG   // In debug mode do not custom-handle the exception, let Visual Studio handle it

            e.Handled = false;

#else 
            ShowUnhandledException(e);    
            
#endif
        }

        public void ShowUnhandledException(DispatcherUnhandledExceptionEventArgs e) {

            e.Handled = true;

            var message = e.Exception.InnerException ?? e.Exception;

            string errorMessage = "An \"PDF Find\"-application error occurred.\n" +
            "Please check whether your data is correct and repeat the action. " +
            "If this error occurs again, there seems to be a more serious malfunction in the application, " +
            $"and you better close it.\n\nError: {message.Message}\n\n" +
            "The application will be closed now.";

            MessageBox.Show(errorMessage, "Application Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            Current.Shutdown();
        }
    }
}
