using ListViews.Model;
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

namespace ListViews.View
{
    /// <summary>
    /// Lógica de interacción para FilaJugador.xaml
    /// </summary>
    public partial class FilaJugador : UserControl
    {
        public FilaJugador()
        {
            InitializeComponent();
        }


        public Jugador TheJugador
        {
            get { return (Jugador)GetValue(TheJugadorProperty); }
            set { SetValue(TheJugadorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TheJugador.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheJugadorProperty =
            DependencyProperty.Register("TheJugador", typeof(Jugador), typeof(FilaJugador), new PropertyMetadata(null));





    }
}
