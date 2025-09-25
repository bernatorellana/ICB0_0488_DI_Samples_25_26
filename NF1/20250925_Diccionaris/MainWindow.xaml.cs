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

namespace _20250925_Diccionaris
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<String, Persona> persones = 
                new Dictionary<string, Persona>();

            Persona p1 = new Persona(1, "1111111H", "Sara", "Connor");
            Persona p2 = new Persona(2, "2222222J", "Joe", "Salmon");
            Persona p3 = new Persona(3, "2222222J", "Juan", "Salero");

            persones.Add("1111111H", p1);
            persones["1111111H"] = p1;

        }
    }
}
