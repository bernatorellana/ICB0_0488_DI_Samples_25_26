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


    public partial class FitxaEquip : UserControl
    {


        public event EventHandler SelectedPlayerChanged;

        public FitxaEquip()
        {
            InitializeComponent();
            
        }

        #region Dependency_Properties 

        public Equip TheEquip
        {
            get { return (Equip)GetValue(TheEquipProperty); }
            set { SetValue(TheEquipProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TheEquip.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheEquipProperty =
            DependencyProperty.Register("TheEquip", typeof(Equip), typeof(FitxaEquip), new PropertyMetadata(null));

        //=================================================

        public Jugador TheJugador
        {
            get { return (Jugador)GetValue(TheJugadorProperty); }
            set { SetValue(TheJugadorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TheJugador.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TheJugadorProperty =
            DependencyProperty.Register("TheJugador", typeof(Jugador), typeof(FitxaEquip), new PropertyMetadata(null));

        #endregion

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TheJugador = lsvJugadors.SelectedItem as Jugador;

            SelectedPlayerChanged?.Invoke(this,new EventArgs());
        }


        //--------------------------------------




        public int Valor
        {
            get { return (int)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorProperty =
            DependencyProperty.Register("Valor", typeof(int), typeof(Fi), new PropertyMetadata(0));





    }
}
