using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


            Persona p1 = new Persona(12, "11111111H", "Paco", "Martínez");
            Persona p2 = new Persona(13, "12345678Z", "Maria", "Sánchez");
            Persona p3 = new Persona(14, "22222222J", "Cristina", "Rius");

            ObservableCollection<Persona> persones = new ObservableCollection<Persona>();
            persones.Add(p1);
            persones.Add(p2);
            persones.Add(p3);

            string nc = persones[0].NomComplet;

            persones.Contains(p1); //cert
            bool existeix = persones.Contains(new Persona(0, "11111111H", "xxx", "xxx")); //cert?

            cboPersones.ItemsSource = persones;
            lsbPersones.ItemsSource = persones;

            persones.Add(p1);

        



        }


        private void cboPersones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona personaSeleccionada = (Persona)cboPersones.SelectedItem;
            MessageBox.Show(personaSeleccionada + "");

            
        }
    }
}
