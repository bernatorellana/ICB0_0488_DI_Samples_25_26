using System;
using System.Collections.Generic;

using System.Windows.Controls;
using System.Windows.Media;
using Cartes.Model;
using DependencyPropertyGenerator; 

namespace Cartes.View
{


    [DependencyProperty<Pal>("DasPal", DefaultValue  = Pal.COR , OnChanged ="OnPalChanged")]
    [DependencyProperty<Rang>("DerRang", DefaultValue = Rang.A, OnChanged ="OnRangChanged")]
    [DependencyProperty<bool>("Visible", DefaultValue = true, OnChanged ="OnVisibleChanged")]

    /// <summary>
    /// Lógica de interacción para UCCarta.xaml
    /// </summary>
    public partial class UCCarta : UserControl
    {


     
        private Dictionary<Pal,String> PalStrings = new Dictionary<Pal, String> 
        { 
            { Pal.COR,"♥" },
            { Pal.DIAMANT,"♦" },
            { Pal.TREBOL,"♣" },
            { Pal.PICA,"♠" },
        };
        private Dictionary<Pal, Color> PalColors = new Dictionary<Pal, Color>
        {
            { Pal.COR,Colors.Red },
            { Pal.DIAMANT,Colors.Red  },
            { Pal.TREBOL,Colors.Black },
            { Pal.PICA,Colors.Black }
        };



        public UCCarta()
        {
            InitializeComponent();
        }

        public void OnPalChanged()
        {
            txtPal1.Text = PalStrings[DasPal];
            txtPal1.Foreground = new SolidColorBrush( PalColors[DasPal] );

        }

        public void OnRangChanged()
        {

        }

        public void OnVisibleChanged()
        {

        }

    }
}
