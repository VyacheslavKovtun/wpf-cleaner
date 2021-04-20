using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFCleaner.ViewModels.View;

namespace WPFCleaner.UserControls
{
    public partial class CleanMemoryUserControl : UserControl
    {
        CleanMemoryViewModel viewModel;
        public CleanMemoryUserControl()
        {
            InitializeComponent();
            viewModel = new CleanMemoryViewModel(this);
            viewModel.RefreshCleanUC += ViewModel_RefreshCleanUC;
            DataContext = viewModel;
        }

        private void ViewModel_RefreshCleanUC(bool start)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (start)
                {
                    CleanMemoryPB.Maximum = viewModel.tmpFiles.Count + viewModel.cookies.Count;
                    CleanMemoryPB.Value = 0;
                }
                else
                {
                    CleanMemoryPB.Maximum = 0;
                    CleanBtnTextLbl.Content = "Clean";
                    LoadingIcon.Visibility = Visibility.Hidden;
                }
            }));
        }

        private void CleanMemoryBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadingIcon.Visibility = Visibility.Visible;
            viewModel.Clean();
        }
    }
}
