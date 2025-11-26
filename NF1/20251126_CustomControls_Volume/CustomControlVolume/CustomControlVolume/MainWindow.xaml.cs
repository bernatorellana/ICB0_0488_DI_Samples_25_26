using CustomControlVolume.View;
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

namespace CustomControlVolume
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

        int[] valors;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            valors  = new int[200];
             
            for (int i = 0; i < valors.Length; i++)
            {
                valors[i] = (int)(30 * Math.Sin(2 * Math.PI * i / 20))+60;

                UCControlVolum c = new UCControlVolum();
                c.Width = 10;
                c.Height = 200;
                c.Value = valors[i];
                c.Margin = new Thickness(2);
                equalitzador.Children.Add(c);
            }
        }
    }
}