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

namespace _20250922_Classes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            String[] noms = { "Paco", "Maria", "Cristina" };

            List<String> nomsEnLlista = new List<String>();
            nomsEnLlista.Add("Paco");
            nomsEnLlista.Add("Maria");
            nomsEnLlista.Add("Cristina");
            nomsEnLlista.Remove("Paco");
            //nomsEnLlista.RemoveAt(0);
            nomsEnLlista.AddRange(noms);
            nomsEnLlista.Insert(0, "Paquita");

            cboPersones.ItemsSource = nomsEnLlista;
            lsbPersones.ItemsSource = nomsEnLlista;


            Persona p = new Persona(12, "1111111H", "Paco", "Martínez");
            p.NIF1 = "11111111H";
        }
    }
}
