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

namespace _20250915_HelloWorldWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHola_Click(object sender, RoutedEventArgs e)
        {
            lblSalutacio.Content = "M'han fet clic !!!";
        }



        private void txtCognom_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;
            if (e.Key == Key.Return)
            {
                lblSalutacio.Content = txtCognom.Text;
            }
        }
    }
}
