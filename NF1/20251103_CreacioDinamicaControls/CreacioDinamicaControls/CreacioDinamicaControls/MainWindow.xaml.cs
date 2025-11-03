using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreacioDinamicaControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                
                Button b = new Button();
                b.Content= i.ToString();
                b.Tag = i;
                b.Width = 100;
                b.Height = 100;
                b.Margin = new Thickness(5);
                stpPanell.Children.Add(b);
                b.Click += Button_Click;
                // assignem fila i columna de la graella
                if (i == 0)
                {
                    Grid.SetColumn(b, 1);
                    Grid.SetRow(b, 4);
                }
                else
                {
                    int k = i - 1;
                    Grid.SetColumn(b, k % 3);
                    Grid.SetRow(b, 3 - k / 3 );
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           int numero = (int)(sender as Button).Tag;
           txbNumero.Text = numero.ToString();
        }
    }
}