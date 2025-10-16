using DAO;
using IDAO;
using System.Windows;

namespace Aplicacio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            IDAODept d = MySQLFactory.getDAODept();

            dtgDepartaments.ItemsSource = d.GetDepts();
        }
    }
}