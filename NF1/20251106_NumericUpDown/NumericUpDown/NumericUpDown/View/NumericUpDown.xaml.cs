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

namespace NumericUpDown.View
{
    /// <summary>
    /// Lógica de interacción para NumericUpDown.xaml
    /// </summary>
    /// 

    [DependencyProperty<int>("Min", DefaultValue = 0, Description = "Min value",OnChanged = "OnMinChanged")]
    [DependencyProperty<int>("Max", DefaultValue = 100, Description = "Max value",OnChanged = "OnMaxChanged")]
    [DependencyProperty<int>("Valor", DefaultValue = 0, Description = "El valor",OnChanged ="ValorChanged")]
    
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();
        }
        public void OnMinChanged(int old, int newValue)
        {
            if(Min>=Max)
            {
                Min = Max - 1;
            }
            ValorChanged();
        }
        public void OnMaxChanged(int old, int newValue)
        {
            if (Min >= Max)
            {
                Max = Min + 1;
            }
            ValorChanged();
        }
        public void ValorChanged()
        {
            Valor = Math.Clamp(Valor, Min, Max);
            btnMenys.IsEnabled = Valor != Min;
            btnMes.IsEnabled   = Valor != Max;
        }

        private void btnMenys_Click(object sender, RoutedEventArgs e)
        {
            Valor--;
        }

        private void btnMes_Click(object sender, RoutedEventArgs e)
        {
            Valor++;
        }

        /*   public int Valor
           {
               get { return (int)GetValue(ValorProperty); }
               set { SetValue(ValorProperty, value); }
           }

           // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
           public static readonly DependencyProperty ValorProperty =
               DependencyProperty.Register("Valor", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0,ValorChangedCallbackStatic));

           private static void ValorChangedCallbackStatic(
               DependencyObject d, DependencyPropertyChangedEventArgs e)
           {
               NumericUpDown obj = (NumericUpDown)d;
               obj.ValorChangedCallback(e);
           }

           private void ValorChangedCallback(DependencyPropertyChangedEventArgs e)
           {
               // Sóc un desgraciat per haver arribat fins aquí
               if(Valor>Max) Valor = Max;
           }
           */

        //-------------------------------------------

        //public int Min
        //{
        //    get { return (int)GetValue(MinProperty); }
        //    set { SetValue(MinProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Min.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MinProperty =
        //    DependencyProperty.Register("Min", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));




        //public int Max
        //{
        //    get { return (int)GetValue(MaxProperty); }
        //    set { SetValue(MaxProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Max.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MaxProperty =
        //    DependencyProperty.Register("Max", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0));



    }
}
