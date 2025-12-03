using EF_data_first.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

namespace EF_data_first
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AppDbContext context = new AppDbContext();

            // Consulta "select * from"
            departaments.ItemsSource = context.Depts.ToList<Dept>();

    
        }

        private void empleats_Selected(object sender, RoutedEventArgs e)
        {
            Emp em = empleats.SelectedItem as Emp;
            if (em != null)
            {
                clients.ItemsSource = em.Clients;
            }
        }
    }
}