using _20251001_Controls_Senders.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace _20251001_Controls_Senders
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dtgClients.ItemsSource = Client.GetClients();
            // Carreguem la llista de províncies al ComboBox
            cboProvincia.DisplayMemberPath = "Nom";
            cboProvincia.ItemsSource = Provincia.GetProvincies();
            /*
            rdoAutonom.Tag = TipusEmpresa.AUTONOM;
            rdoPublica.Tag = TipusEmpresa.PUBLICA;
            rdoPrivada.Tag = TipusEmpresa.PRIVADA;
            */
            foreach( TipusEmpresa t in Enum.GetValues( typeof(TipusEmpresa))){
                RadioButton rb = new RadioButton();
                stpRadios.Children.Add(rb);
                rb.Tag = t;
                rb.Content = Enum.GetName(typeof(TipusEmpresa), t);
            }
        }


        private Client c;


        private void dtgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            c = (Client)dtgClients.SelectedItem;

            //     Omplim les dades del formulari
            //----------------------------------------
            //
            txtCIF.Text = c.CIF1;
            txtId.Text = c.Id+"";
            txtRaoSocial.Text = c.RaoSocial;
            // Seleccionar la província
            cboProvincia.SelectedItem = c.Provincia;

            foreach (RadioButton rb in stpRadios.Children)
            {
                rb.IsChecked = (c.Tipus == (TipusEmpresa)rb.Tag);
            }

            /*
            rdoAutonom.IsChecked = (c.Tipus==TipusEmpresa.AUTONOM); 
            rdoPublica.IsChecked = (c.Tipus==TipusEmpresa.PUBLICA); 
            rdoPrivada.IsChecked = (c.Tipus==TipusEmpresa.PRIVADA); 
            */

            chkActiva.IsChecked = c.EsActiva;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            c.Id = Int32.Parse( txtId.Text );

            c.RaoSocial = txtRaoSocial.Text;
            c.CIF1 = txtCIF.Text;

            c.Provincia = (Provincia)cboProvincia.SelectedItem;



            TipusEmpresa te = TipusEmpresa.YONKI;
            //int i = 0;
            foreach (RadioButton rb in stpRadios.Children)
            {
                if(rb.IsChecked.Value)
                {
                    te = (TipusEmpresa)rb.Tag;                    
                    //te = (TipusEmpresa) Enum.GetValues(typeof(TipusEmpresa)).GetValue(i);
                    break;
                }
                //i++;
            }
            c.Tipus = te;

            c.EsActiva = chkActiva.IsChecked.Value;


        }

        private void txtCIF_LostFocus(object sender, RoutedEventArgs e)
        {
            string error;
            bool campCIFValid = Client.ValidaCIF(txtCIF.Text,out error);

            mostraError(txtCIF, lblErrorCIF, campCIFValid, error);
        }

        private void mostraError(Control txt, Label lblError, bool campValid, string error)
        {
            if(campValid)
            {
                txt.Background = new SolidColorBrush(Colors.Transparent);
                lblError.Content = "";
            } else
            {
                txt.Background = new SolidColorBrush(Colors.Red);
                lblError.Content = error;
            }
        }
    }
}











