using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace _20250917_sintaxis
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
            String cadena = "Hola\n";
            txtSortida.Text = cadena;

            txtSortida.AppendText("Adeu !");

            // Tipus primitius de dades
            // 
            float preu = 0.0f;
            double preuDouble = 0.0;
            // number(10,2)
            decimal preus = 100.23m;
            char c = 'A';
            bool haArribat = false;

            String nom = "Paco";
            nom = nom.ToUpper();
            mostra(nom);
            nom = "Maria Pérez Montes";
            string[] trocets = nom.Split(' ');
            mostra(trocets[0]);
            mostra(trocets[1]);
            mostra(trocets[2]);


            string cadenaBuida = "";
            if (cadenaBuida.Equals(""))
            {
                mostra("La cadena està buida");
            }
            // ==================================
            // Treballant amb dates
            DateTime dateTime = DateTime.Now;
            DateTime avui = DateTime.Today;
            if (avui < dateTime)
            {
                mostra("BINGO!");
            }
            DateTime dataPersonalitzada = new DateTime(2010, 10, 10, 10, 10, 10, DateTimeKind.Utc);
            mostra(dataPersonalitzada.ToString("dd/MM/yy"));
            mostra(dataPersonalitzada.ToString("dddd, dd  MMMM \\de yyyy"));

            //=====================0
            // Dies de la setmana en català
            DateTime d = new DateTime(2000, 1, 1);
            for(int i = 0; i < 12; i++)
            {
                mostra(d.ToString("MMMM", new CultureInfo("de")));
                d=d.AddMonths(1);

            }
            // V2
            for (int i = 0; i < 12; i++)
            {
                String nomMes = (new DateTime(2000, i + 1, 1)).ToString("MMMM");
                mostra(nomMes);

                cboMesos.Items.Add(nomMes);
            }
        }

        private void mostra(string nom)
        {
            txtSortida.AppendText(nom + "\n");
        }
    }
}
