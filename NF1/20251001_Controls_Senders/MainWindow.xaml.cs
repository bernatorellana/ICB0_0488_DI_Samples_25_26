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

        public enum TipusMode
        {
            EDICIO,
            NOU,
            EN_ESPERA
        }


        private TipusMode _mode;

        public TipusMode Mode
        {
            get { return _mode; }

            set
            {
                if (_mode != value)
                {
                    _mode = value;


                    btnNew.IsEnabled = (Mode != TipusMode.NOU);
                    btnSave.IsEnabled = (Mode != TipusMode.EN_ESPERA);

                    switch (Mode)
                    {
                        case TipusMode.EDICIO: {
                                bloquejarForm(false);
                                validaForm();
                        } break;
                        case TipusMode.NOU: {
                                bloquejarForm(false);
                                buidarFormulari();    
                        } break;
                        case TipusMode.EN_ESPERA:
                        {
                            bloquejarForm(true);
                        }break;
                    }
                }
            }
        }

        private void bloquejarForm(bool v)
        {
            txtCIF.IsEnabled = !v;
            txtId.IsEnabled = !v;
            txtRaoSocial.IsEnabled = !v;
            cboProvincia.IsEnabled = !v;
            foreach (RadioButton rb in stpRadios.Children)
            {
                rb.IsEnabled = !v;
            }
            chkActiva.IsEnabled = !v;
        }

        /// <summary>
        /// Buidem tot el formulari per posar dades per un nou registre
        /// </summary>
        private void buidarFormulari()
        {
            txtCIF.Text = "";
            txtId.Text = "<>";
            txtRaoSocial.Text = "";
            cboProvincia.SelectedItem = null;

            foreach (RadioButton rb in stpRadios.Children)
            {
                rb.IsChecked = false;
            }
            chkActiva.IsChecked = false;
        }

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
            Mode = TipusMode.EN_ESPERA;
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

            Mode = TipusMode.EDICIO;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validaForm())
            {
                c.Id = Int32.Parse(txtId.Text);
                c.RaoSocial = txtRaoSocial.Text;
                c.CIF1 = txtCIF.Text;
                c.Provincia = (Provincia)cboProvincia.SelectedItem;

                TipusEmpresa te = TipusEmpresa.YONKI;
                //int i = 0;
                foreach (RadioButton rb in stpRadios.Children)
                {
                    if (rb.IsChecked.Value)
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

        }

        private void txtCIF_LostFocus(object sender, RoutedEventArgs e)
        {
            validaForm();
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

        private void mostraError(Control txt, TextBlock lblError, bool campValid, string error)
        {
            if (campValid)
            {
                txt.Background = new SolidColorBrush(Colors.Transparent);
                lblError.Text = "";
            }
            else
            {
                txt.Background = new SolidColorBrush(Colors.Red);
                lblError.Text = error;
            }
        }

        private void txtRaoSocial_LostFocus(object sender, RoutedEventArgs e)
        {
            validaForm();
        }


        private bool validaForm()
        {

            string error;
            bool isFormOk = true;
            bool isOk;

            isOk = Client.ValidaRaoSocial(txtRaoSocial.Text, out error);
            isFormOk = isFormOk && isOk;
            mostraError(txtRaoSocial, lblErrorRao, isOk, error);


            isOk = Client.ValidaCIF(txtCIF.Text, out error);
            isFormOk = isFormOk && isOk;
            mostraError(txtCIF, lblErrorCIF, isOk, error);

            btnSave.IsEnabled = isFormOk; //activem o desactivem el Save si el form està correcte o no

            return isFormOk;
        }
        Thickness original ;

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Mode = TipusMode.NOU;
        }
    }
}











