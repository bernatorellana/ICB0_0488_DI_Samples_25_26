using System;
using System.Collections.Generic;

using System.Windows.Controls;
using Cartes.Model;
using DependencyPropertyGenerator;

namespace Cartes.View
{


    [DependencyProperty<Pal>("DasPal", DefaultValue  = Pal.COR )]
    [DependencyProperty<Rang>("DerRang", DefaultValue = Rang.A)]
    [DependencyProperty<bool>("Visible", DefaultValue = true)]

    /// <summary>
    /// Lógica de interacción para UCCarta.xaml
    /// </summary>
    public partial class UCCarta : UserControl
    {
        public UCCarta()
        {
            InitializeComponent();
        }
    }
}
