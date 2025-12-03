
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
        private AppDbContext context;

        public MainWindow()
        {
            InitializeComponent();

            context = new AppDbContext();

            dtgDepartaments.ItemsSource = context.Depts.Include(d => d.Emps).ToList();


         }

         private void dtgDepartaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
            Dept deptSeleccionat = dtgDepartaments.SelectedItem as Dept;
            if (deptSeleccionat != null)
            {
                List<Emp> empleatsDelDepartament = context.Emps.Where(e => e.DeptNo == deptSeleccionat.DeptNo).ToList<Emp>();

                dtgEmpleats.ItemsSource = empleatsDelDepartament;
            }
         }

        /*private void dtgDepartaments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dept deptSeleccionat = dtgDepartaments.SelectedItem as Dept;

            dtgEmpleats.ItemsSource = deptSeleccionat.Emps;
            
        }*/


        private void empleats_Selected(object sender, RoutedEventArgs e)
        {
           /* Emp em = empleats.SelectedItem as Emp;
            if (em != null)
            {
                clients.ItemsSource = em.Clients;
            }*/
        }


    }
}