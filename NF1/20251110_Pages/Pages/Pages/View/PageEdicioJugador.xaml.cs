using GestioDequips.Model;
using Pages.ViewModel;
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

        private Jugador j;
        private PageEdicioJugador_ViewModel viewModel;

        public PageEdicioJugador()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            // Aquest és el paràmetre que m'estan passant des de la navegació !!!!!!
            object parametre = e.ExtraData;
            if (parametre != null && !(parametre is Jugador)) throw new Exception("Paràmetre invàlid");

            j = (Jugador)parametre;
            // Creem el ViewModel
            viewModel = new PageEdicioJugador_ViewModel(j);

            // IMPORTANT !!!!! 
            this.DataContext = viewModel;

            
            //txtCognoms.Text = j.Cognoms;
            //txtDorsal.Text = j.Dorsal+"";
            ////imgFoto.Source = j.UrlFoto;

            if (NavigationService != null) NavigationService.LoadCompleted -= NavigationService_LoadCompleted;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            viewModel.save();
            NavigationService.GoBack();
        }


    }
}
