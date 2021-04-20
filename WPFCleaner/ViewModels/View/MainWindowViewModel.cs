using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFCleaner.ViewModels.View
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        MainWindow mainWindow;

        private ListViewItem selectedMainMenuItem;

        public ListViewItem SelectedMainMenuItem
        {
            get => selectedMainMenuItem;
            set
            {
                selectedMainMenuItem = value;
                OnPropertyChanged(nameof(SelectedMainMenuItem));
                SwitchScreen(selectedMainMenuItem.Tag);
            }
        }

        public void SwitchScreen(object name)
        {
            switch ((string)name)
            {
                case "Memory":
                    LoadMemory();
                    mainWindow.CleanMemoryGrid.Visibility = Visibility.Visible;
                    mainWindow.CleanOperativeGrid.Visibility = Visibility.Hidden;
                    mainWindow.CleaningHistoryGrid.Visibility = Visibility.Hidden;
                    break;
                case "Operative":
                    LoadOperative();
                    mainWindow.CleanMemoryGrid.Visibility = Visibility.Hidden;
                    mainWindow.CleanOperativeGrid.Visibility = Visibility.Visible;
                    mainWindow.CleaningHistoryGrid.Visibility = Visibility.Hidden;
                    break;
                case "History":
                    LoadHistory();
                    mainWindow.CleanMemoryGrid.Visibility = Visibility.Hidden;
                    mainWindow.CleanOperativeGrid.Visibility = Visibility.Hidden;
                    mainWindow.CleaningHistoryGrid.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void LoadHistory()
        {
            mainWindow.CleaningHistoryUC.DataContext = new CleaningHistoryViewModel();
        }

        private void LoadOperative()
        {
            mainWindow.CleanOperativeUC.DataContext = new CleanOperativeViewModel();
        }

        private void LoadMemory()
        {
            mainWindow.CleanMemoryUC.DataContext = new CleanMemoryViewModel();
        }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
