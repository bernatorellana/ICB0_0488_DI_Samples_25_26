using GestioDequips.Model;
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

namespace Pages
{
    /// <summary>
    /// Lógica de interacción para PageJugadors.xaml
    /// </summary>
    public partial class PageJugadors : Page
    {
        private MainWindow mainWindow;

        public PageJugadors(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvJugadors.ItemsSource = null;
            lsvJugadors.ItemsSource = Equip.getLlistaEquips()[0].Jugador;
        }

        private void lsvJugadors_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // navegar cap a PageEdicioJugador passant el jugador seleccionat
            mainWindow.mostrarEdicioJugador(lsvJugadors.SelectedItem as Jugador);
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mostrarEdicioJugador(null);
        }
    }
}
