using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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

namespace _20250924_Formulari_Ping_Pong
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {


        private ObservableCollection<String> left,right;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lsbLeft.ItemsSource = left; 
            lsbRight.ItemsSource = right;
            actualitzaBotons();

            // TRUQUI
            lsbLeft.Tag = lsbRight;
            lsbRight.Tag = lsbLeft;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nomCorrecte())
            {
                left.Add(txbName.Text);
                actualitzaBotons();
            }
        }

        private bool nomCorrecte()
        {
            return txbName.Text.Trim().Length > 0 &&
                            !left.Contains(txbName.Text);
        }

        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualitzaBotons();
        }

        private void actualitzaBotons()
        {
            btnAdd.IsEnabled = nomCorrecte();
            btnLeft.IsEnabled = lsbRight.SelectedItem != null;
            btnRight.IsEnabled = lsbLeft.SelectedItem != null;
        }

        private void lsbLeft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualitzaBotons();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            intercanvi(lsbRight);
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            intercanvi(lsbLeft);
        }

        private void intercanvi( ListBox origen )
        {
            ListBox desti = origen.Tag as ListBox;
            ObservableCollection<String> llistaOrigen =
                (ObservableCollection<String>)origen.ItemsSource;

            ObservableCollection<String> llistaDesti =
                    (ObservableCollection<String>)desti.ItemsSource;

            String nomSeleccionat = (string)origen.SelectedItem;
            if (nomSeleccionat != null &&
                !llistaDesti.Contains(nomSeleccionat))
            {
                llistaDesti.Add(nomSeleccionat);
                llistaOrigen.Remove(nomSeleccionat);
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            left = new ObservableCollection<string>();
            right = new ObservableCollection<string>();
        }
    }
}
