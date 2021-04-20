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
    public partial class CleanOperativeUserControl : UserControl
    {
        CleanOperativeViewModel viewModel = new CleanOperativeViewModel();

        public CleanOperativeUserControl()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AutoCloseProcessesBtn_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AutoCloseProcesses();
        }
    }
}
