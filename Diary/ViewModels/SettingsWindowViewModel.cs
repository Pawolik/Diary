using Diary.Commands;
using System.Windows.Input;
using System.Windows;
using Diary.Models.Domains;

namespace Diary.ViewModels
{
    public class SettingsWindowViewModel :ViewModelBase
    {
        public SettingsData Settings { get; set; }

        public SettingsWindowViewModel()
        {
            Settings = new SettingsData
            {
                ServerAddress = Properties.Settings.Default.serverAddress,
                ServerName = Properties.Settings.Default.serverName,
                DatabaseName = Properties.Settings.Default.databaseName,
                Username = Properties.Settings.Default.username,
                Password = Properties.Settings.Default.password
            };

            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(SaveSettingsAndClose);
        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }



        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private void SaveSettingsAndClose(object parameter)
        {
            if (parameter is Window window)
            {
                Properties.Settings.Default.serverAddress = Settings.ServerAddress;
                Properties.Settings.Default.serverName = Settings.ServerName;
                Properties.Settings.Default.databaseName = Settings.DatabaseName;
                Properties.Settings.Default.username = Settings.Username;
                Properties.Settings.Default.password = Settings.Password;

                Properties.Settings.Default.Save();

                window.Close();
                RestartApplication();
            }
        }

        private void RestartApplication()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

    }
}
