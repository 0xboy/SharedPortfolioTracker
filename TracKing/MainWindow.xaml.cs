using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TracKing.Infrastructure.Command;
using TracKing.Infrastructure.Context;
using TracKing.Infrastructure.IoC;
using TracKing.Infrastructure.Query;
using TracKing.Infrastructure;
using TracKing.Infrastructure.Aggregate;

namespace TracKing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}