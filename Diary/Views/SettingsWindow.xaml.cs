using MahApps.Metro.Controls;
using Diary.ViewModels;

namespace Diary.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : MetroWindow
    {
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = new SettingsWindowViewModel();

        }
    }
}
