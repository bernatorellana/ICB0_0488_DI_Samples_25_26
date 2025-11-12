using GestioDequips.Model;
using Pages.View;
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

namespace Pages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public PageLlistaEquips PaginaLlistaEquips { get; set; }
        public PageJugadors PaginaLlistaJugadors { get; set; }
        public PageEdicioJugador PaginaEdicioJugador { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            PaginaLlistaEquips = new PageLlistaEquips();
            PaginaLlistaJugadors = new PageJugadors(this);
            PaginaEdicioJugador = new PageEdicioJugador();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            frmMain.Navigate(PaginaLlistaEquips);
        }

        private void mnuTeams_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(PaginaLlistaEquips);
        }

        private void mnuPlayers_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(PaginaLlistaJugadors);
        }

        internal void mostrarEdicioJugador(Jugador? jugador)
        {

            frmMain.LoadCompleted += PaginaEdicioJugador.NavigationService_LoadCompleted;
            frmMain.Navigate(PaginaEdicioJugador, jugador);
        }
    }
}