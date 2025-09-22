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

namespace _250918_1_conversions
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInt_Click(object sender, RoutedEventArgs e)
        {
            String numeroS = txbInt.Text;
            /*try
            {
                int i = Int32.Parse(numeroS); //Int32.Parse() transforma un string en un numero.
                lblInt.Content = "El número és: " + i;
                txbInt.Background = new SolidColorBrush(Colors.Lime);
            } 
            catch (Exception ex)
            {
                txbInt.Background = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Posa un número, RUC!");
            }*/
            int resultat = 0;
            bool numeroOk = Int32.TryParse(numeroS, out resultat);
            mostraError(numeroOk, txbInt, lblInt, "El número és " + resultat, "Número erroni");

        }

        private void btnMoney_Click(object sender, RoutedEventArgs e)
        {
            String numeroS = txbMoney.Text;
            decimal resultat = 0;
            bool numeroOk = Decimal.TryParse(numeroS, out resultat);
            mostraError(numeroOk, txbMoney, lblMoney, "L'import és " + resultat, "Import erroni");


            /* String numeroS = txbMoney.Text;
             try
             {
                 Decimal i = Decimal.Parse(numeroS);
                 lblMoney.Content = "El número és: " + i.ToString("0.00");
                 txbMoney.Background = new SolidColorBrush(Colors.Lime);
             }
             catch (Exception ex)
             {
                 txbMoney.Background = new SolidColorBrush(Colors.Red);
                 MessageBox.Show("Posa un número, RUC!");
             }*/
            /*
             * Altre manera de fer-ho amb una funció que no peta perque té integrat el try
            decimal d;
            bool isOk = Decimal.TryParse(numeroS, out d);

            if (isOk)
            {
                lblMoney.Content = "El número és: " + i.ToString("0.00");
                txbMoney.Background = new SolidColorBrush(Colors.Lime);
            }
            else
            {
                txbMoney.Background = new SolidColorBrush(Colors.Red);
                MessageBox.Show("Posa un número, RUC!");
            }
            */
        }

        private void btnDate_Click(object sender, RoutedEventArgs e)
        {
            String dataD = txbDate.Text;
            String[] formatsValids = { "dd-MM-yyyy", "dd/MM/yyyy" };

            bool dataOk = false;
            DateTime dataParsejada1 = DateTime.Now;
            foreach (string format in formatsValids)
            {
                try
                {
                    // Here comes la conversió a data....

                    dataParsejada1 =
                        DateTime.ParseExact(dataD, format,
                            System.Globalization.CultureInfo.InvariantCulture);
                    dataOk = true;
                    break;
                }
                catch (Exception ex)
                {

                }
            }
            mostraError(dataOk, txbDate, lblDate, "La data és " + dataParsejada1,
                "Data erronia");
        }

        void mostraError(bool correcte, TextBox textbox, Label label,
            String missatgeOk, String missatgeError)
        {
            if (correcte)
            {
                label.Content = missatgeOk;
                textbox.Background = new SolidColorBrush(Colors.Lime);
            }
            else
            {
                label.Content = missatgeError;
                textbox.Background = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
