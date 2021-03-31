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
using System.Windows.Shapes;
using Currency;
namespace WPF_Currency_Midterm_DavidNichol.Windows
{
    /// <summary>
    /// Interaction logic for MakeChange.xaml
    /// </summary>
    public partial class MakeChange : Window
    {
        USCurrencyRepo repo;
        CurrencyRepoViewModel viewModel;
        public MakeChange()
        {
            InitializeComponent();
            repo = new USCurrencyRepo();
            viewModel = new CurrencyRepoViewModel(repo);
            this.DataContext = viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = viewModel;
        }
    }
}
