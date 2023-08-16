using Diary.Models.Domains;
using Diary.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Data.SqlClient;
using System.Windows;
using Diary.Commands;
using System.Windows.Input;


namespace Diary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var metroWindow = Current.MainWindow as MetroWindow;
            metroWindow.ShowMessageAsync("Nieoczekiwany wyjątek",
                "Wystąpił nieoczekiwany wyjątek." + Environment.NewLine + e.Exception.Message);

            e.Handled = true;
        }

        public SettingsData Settings { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            

            Settings = new SettingsData
            {
                ServerAddress = Diary.Properties.Settings.Default.serverAddress,
                ServerName = Diary.Properties.Settings.Default.serverName,
                DatabaseName = Diary.Properties.Settings.Default.databaseName,
                Username = Diary.Properties.Settings.Default.username,
                Password = Diary.Properties.Settings.Default.password
            };

            if (!IsValidSettings())
            {
                var result = MessageBox.Show("Nie można połączyć się z bazą danych za pomocą obecnych ustawień. Czy chcesz zmienić ustawienia?", "Błąd połączenia", MessageBoxButton.YesNo, MessageBoxImage.Error);

                if (result == MessageBoxResult.Yes)
                {
                    OpenSettingsWindow();
                }
                else
                {
                    Shutdown();
                }
            }
        }

        private bool IsValidSettings()
        {
            bool isValid = true;

            string connectionString = $"Data Source={Settings.ServerAddress}\\{Settings.ServerName};Initial Catalog={Settings.DatabaseName};User ID={Settings.Username};Password={Settings.Password};";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
            }
            catch (SqlException)
            {
                isValid = false;
            }

            return isValid;
        }

        private void OpenSettingsWindow()
        {
            // Otwórz okno ustawień, podobnie jak robisz to w innych miejscach w aplikacji
            var settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }
    }
}
