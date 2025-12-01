using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Cartes.Model;
using DependencyPropertyGenerator; 

namespace Cartes.View
{


    [DependencyProperty<Pal>("DasPal", DefaultValue  = Pal.COR , OnChanged ="OnPalChanged")]
    [DependencyProperty<Rang>("DerRang", DefaultValue = Rang.A, OnChanged ="OnRangChanged")]
    [DependencyProperty<bool>("Girada", DefaultValue = false, OnChanged ="OnGiradaChanged")]

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
    
        private String RangToString(Rang rang)
        {
            String desc = rang.ToString();
            if (desc.StartsWith("N")) desc = desc.Substring(1);
            return desc;
        }

        public UCCarta()
        {
            InitializeComponent();
        }

        public void OnPalChanged()
        {
            foreach (var t in new TextBlock[] { txtPal1, txtPal2 })
            {
                t.Text = PalStrings[DasPal];
                t.Foreground = new SolidColorBrush(PalColors[DasPal]);
            }
            OnRangChanged();
        }

        public void OnRangChanged()
        {
            foreach (var t in new TextBlock[] { txtRang1, txtRang2 })
            {
                t.Text = RangToString(DerRang);
                t.Foreground = new SolidColorBrush(PalColors[DasPal]);
            }
        }

        public void OnGiradaChanged()  
        {
            imgBack.Visibility = this.Girada ? 
                    System.Windows.Visibility.Visible : System.Windows.Visibility.Hidden;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
        
        }

        private void UserControl_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            double aspectRatio = 5 / 7.0; 
            if (this.ActualWidth > this.ActualHeight)
            {
                /*
                    *    ----------------------------                           
                    *    |                           |
                    *    |                           |
                    *    |                           |
                    *    |                           |
                    *    |                           |
                    *    -----------------------------
                    */
                borde.Width = this.ActualHeight * aspectRatio;
                borde.Height = this.ActualHeight;
            }
            else
            {
                /*
                   *    -------                           
                   *    |      |
                   *    |      |
                   *    |      |
                   *    |      |
                   *    |      |
                   *    --------
                   */
                borde.Height = this.ActualWidth / aspectRatio;
                borde.Width = this.ActualWidth;
            }

        }


        private void UserControl_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Girada = !Girada;
        }
    }
}
