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

namespace Pages.View
{
    /// <summary>
    /// Lógica de interacción para PageEdicioJugador.xaml
    /// </summary>
    public partial class PageEdicioJugador : Page
    {
        public PageEdicioJugador()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.LoadCompleted += NavigationService_LoadCompleted;
        }

        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            // Aquest és el paràmetre que m'estan passant des de la navegació !!!!!!
            object parametre = e.ExtraData;
            if (parametre == null || !(parametre is Jugador)) throw new Exception("Paràmetre invàlid");
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if(NavigationService!=null) NavigationService.LoadCompleted -= NavigationService_LoadCompleted;
        }
    }
}
