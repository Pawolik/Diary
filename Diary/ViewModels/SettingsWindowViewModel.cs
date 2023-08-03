using Diary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Diary.ViewModels
{
    public class SettingsWindowViewModel :ViewModelBase
    {
        public SettingsWindowViewModel()
        {
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
            // Tutaj możesz dodać logikę zapisywania ustawień (odczytaj wartości z TextBoxów itp.)
            // Następnie zamknij okno
            if (parameter is Window window)
            {
                // Pamiętaj, żeby upewnić się, że wprowadzone dane są poprawne, zanim zapiszesz ustawienia
                // Możesz również wyświetlić komunikat o błędzie, jeśli coś jest nieprawidłowe.
                // Zostawiam to Tobie jako zadanie do zaimplementowania.

                // Zapisujemy wartości do ustawień użytkownika
                // (Zakładając, że masz te wartości dostępne jako właściwości w ViewModelu)
                /*Properties.Settings.Default.serverAddress = ServerAddress;
                Properties.Settings.Default.serverName = ServerName;
                Properties.Settings.Default.databaseName = DatabaseName;
                Properties.Settings.Default.username = Username;
                Properties.Settings.Default.password = Password;*/

                // Zapisujemy zmiany w ustawieniach
                Properties.Settings.Default.Save();

                // Zamknięcie okna
                window.Close();


                RestartApplication();
            }
        }

        private void RestartApplication()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        // Reszta kodu klasy, włącznie z OnPropertyChanged itp.
    }
}
