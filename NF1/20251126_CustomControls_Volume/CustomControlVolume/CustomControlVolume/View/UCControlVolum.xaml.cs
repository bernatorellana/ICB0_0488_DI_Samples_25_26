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
using DependencyPropertyGenerator;

namespace CustomControlVolume.View
{
    /// <summary>
    /// Lógica de interacción para UCControlVolum.xaml
    /// </summary>
    /// 

    [DependencyProperty<Int32>("Value", DefaultValue = 0, Description = "The value", OnChanged = "OnValueChanged")]

        public partial class UCControlVolum : UserControl
        {

            private int minValue = 0, maxValue = 100;
            private int numeroMaximBarres = 10;
            private int separacioPixels = 3;
            public UCControlVolum()
            {
                InitializeComponent();
            }

            public void OnValueChanged(Int32 old, Int32 newValue) {

                cnv.Children.Clear();
                if (!double.IsNaN(this.Height))
                {

                    double height = this.Height; // alçada del control sencer
                    double barSeparacio = height / numeroMaximBarres;
                    double barHeight = barSeparacio - separacioPixels;
                    //------------------------------------------------------------
                    double valorEnTantPerU = (Value - minValue) / (double)(maxValue - minValue);
                    int numeroDeBarres = (int)(numeroMaximBarres * valorEnTantPerU);
                    //-------------------------------------------------------------
                    for (int i = 0; i < numeroDeBarres; i++)
                    {
                        // <Rectangle Canvas.Bottom="20" Fill="Red" Width="100" Height="10" Stroke="Black"></Rectangle>
                        Rectangle r = new Rectangle();
                        r.Fill = new SolidColorBrush(Colors.Red);
                        r.Width = this.Width;
                        r.Height = barHeight;
                        Canvas.SetBottom(r, barSeparacio * i); //Canvas.Bottom="20"
                        cnv.Children.Add(r);
                    }
                }
            }

            private void UserControl_Loaded(object sender, RoutedEventArgs e)
            {
                OnValueChanged(0, 0);
            }
    }
}
