using System;
using System.Collections.Generic;
using System.IO;
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

            Persona p1 = new Persona(1, "11111111H", "Sara", "Connor");
            Persona p2 = new Persona(2, "22222222J", "Joe", "Salmon");
            Persona p3 = new Persona(3, "22222222J", "Juan", "Salero");

            persones.Add("1111111H", p1);
            persones["1111111H"] = p1;


            Persona p =  persones["1111111H"];
            if (persones.ContainsKey("1111666H"))
            {
                Persona px = persones["1111666H"];
            }



            //------------------------------
            String dracula = File.ReadAllText("Dracula.txt");
            String raj     = File.ReadAllText("RomeoAndJuliet.txt");
            string separadors = "\t\r|\" ;:.,-_`{}'* ?¿!$%&/()=\n";
            string[] draculaWords = dracula.Split(separadors.ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            string[] rajWords =         raj.Split(separadors.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // A) Buscar paraules comunes entre els dos llibres
            //      6420

            /* -------------------------------------------------------------
             * Versió ERRÒNIA: 
             * és molt lenta i conta els duplicats d'una mateixa paraula
            List<string> paraulesDracula = new List<string>();
            paraulesDracula.AddRange(draculaWords);

            List<string> paraulesRAJ = new List<string>();
            paraulesRAJ.AddRange(rajWords);

            int paraulesComunes = 0;
            foreach(string pr in paraulesDracula)
            {
                if(paraulesRAJ.Contains(pr)) paraulesComunes++;
            }
            txbLlibre.Text = "hi ha :" + paraulesComunes;
            ------------------------------------------------------------- */

            HashSet<String> paraulesUniquesRAJ = rajWords.ToHashSet<string>();
            HashSet<String> paraulesUniquesDracula = draculaWords.ToHashSet<string>();

            int paraulesCompartides = 0;
            foreach (string word in paraulesUniquesDracula)
            {
                if (paraulesUniquesRAJ.Contains(word)) paraulesCompartides++;
            }

            txbLlibre.Text = "Paraules compartides:" + paraulesCompartides;



            // B) Fer una estadística d'ocurrències de paraules de Dracula,
            //     i ordenar-la de més freqüent a menys freqüent. P.ex., un possible
            //     resultat seria:
            //       5324: the
            //       4532: and
            //       4352: why

            Dictionary<string, int> frequencia = new Dictionary<string, int>();
            foreach(string word in draculaWords)
            {
                if(frequencia.ContainsKey(word)) frequencia[word]++;
                else frequencia[word] = 1;
            }
            var ordenat = frequencia.OrderBy(x => -x.Value).ThenBy(x=>x.Key);
            lsbFreq.ItemsSource = ordenat;

        }
    }
}
