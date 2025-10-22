using _20251001_Controls_Senders.model;
using DAO;
using IDAO;
using System.Collections.ObjectModel;
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

namespace Aplicacio
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

        /// <summary>
        /// El client seleccionat actualment
        /// </summary>
        private Client clientActual;

        /// <summary>
        /// Modes que té la pantalla d'edició de clients
        /// </summary>
        public enum TipusMode
        {
            EDICIO,
            NOU,
            EN_ESPERA
        }


        private TipusMode _mode;


        /// <summary>
        /// La propietat Mode controla el mode del formulari, i manté la coherència
        /// de l'estat dels botons, i realitza les accions necessàries per canviar
        /// de mode (netejar camps, validar forms, etc. ) 
        /// </summary>
        public TipusMode Mode
        {
            get { return _mode; }

            set
            {
                if (_mode != value)
                {
                    _mode = value;

                    /// Actualitza l'estat dels botons
                    btnNew.IsEnabled = (Mode != TipusMode.NOU);
                    btnSave.IsEnabled = (Mode != TipusMode.EN_ESPERA);
                    btnDelete.IsEnabled = (Mode == TipusMode.EDICIO);

                    switch (Mode)
                    {
                        case TipusMode.EDICIO:
                            {
                                bloquejarForm(false);
                                validaForm();
                            }
                            break;
                        case TipusMode.NOU:
                            {
                                bloquejarForm(false);
                                buidarFormulari();
                            }
                            break;
                        case TipusMode.EN_ESPERA:
                            {
                                bloquejarForm(true);
                                buidarFormulari();
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Bloqueja/desbloqueja tots els controls del formulari
        /// </summary>
        /// <param name="v">True per bloquejar el form</param>
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



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            filtrar();
            
            // Carreguem la llista de províncies al ComboBox
            cboProvincia.DisplayMemberPath = "Nom";
            cboProvincia.ItemsSource = Provincia.GetProvincies();
            /*
            rdoAutonom.Tag = TipusEmpresa.AUTONOM;
            rdoPublica.Tag = TipusEmpresa.PUBLICA;
            rdoPrivada.Tag = TipusEmpresa.PRIVADA;
            */
            foreach (TipusEmpresa t in Enum.GetValues(typeof(TipusEmpresa)))
            {
                RadioButton rb = new RadioButton();
                stpRadios.Children.Add(rb);
                rb.Tag = t;
                rb.Content = Enum.GetName(typeof(TipusEmpresa), t);
            }
            Mode = TipusMode.EN_ESPERA;
        }




        /// <summary>
        /// L'Event salta quan seleccionem un client al DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clientActual = (Client)dtgClients.SelectedItem;

            if (clientActual == null)
            {
                Mode = TipusMode.EN_ESPERA;
                return;
            }

            //     Omplim les dades del formulari
            //----------------------------------------
            //
            txtCIF.Text = clientActual.CIF1;
            txtId.Text = clientActual.Id + "";
            txtRaoSocial.Text = clientActual.RaoSocial;
            // Seleccionar la província
            cboProvincia.SelectedItem = clientActual.Provincia;

            foreach (RadioButton rb in stpRadios.Children)
            {
                rb.IsChecked = (clientActual.Tipus == (TipusEmpresa)rb.Tag);
            }

            /*
            rdoAutonom.IsChecked = (c.Tipus==TipusEmpresa.AUTONOM); 
            rdoPublica.IsChecked = (c.Tipus==TipusEmpresa.PUBLICA); 
            rdoPrivada.IsChecked = (c.Tipus==TipusEmpresa.PRIVADA); 
            */

            chkActiva.IsChecked = clientActual.EsActiva;

            Mode = TipusMode.EDICIO;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validaForm())
            {

                //int id = Int32.Parse(txtId.Text);
                string rs = txtRaoSocial.Text;
                string cif = txtCIF.Text;
                Provincia p = (Provincia)cboProvincia.SelectedItem;
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
                bool esActiva = chkActiva.IsChecked.Value;

                if (Mode == TipusMode.NOU)
                {
                    //int max = Client.GetClients().Max(x => x.Id) + 1;
                    clientActual = new Client(-1, cif, rs, esActiva, te, p);
                    //Client.GetClients().Add(clientActual);
                    clientsActuals.Add(clientActual);
                    Mode = TipusMode.EN_ESPERA;

                    UnitOfWork uow = MySQLFactory.getUOW();
                    uow.DAOClients.InsertClient(clientActual);

                    filtrar();
                }
                else // actualitzant el cient
                {
                    //clientActual.Id = id;
                    clientActual.CIF1 = cif;
                    clientActual.RaoSocial = rs;
                    clientActual.Provincia = p;
                    clientActual.EsActiva = esActiva;
                    clientActual.Tipus = te;

                    UnitOfWork uow = MySQLFactory.getUOW();
                    uow.DAOClients.UpdateClient(clientActual);
                    

                }

            }

        }

        private void txtCIF_LostFocus(object sender, RoutedEventArgs e)
        {
            validaForm();
        }

        private void mostraError(Control txt, Label lblError, bool campValid, string error)
        {
            if (campValid)
            {
                txt.Background = new SolidColorBrush(Colors.Transparent);
                lblError.Content = "";
            }
            else
            {
                txt.Background = new SolidColorBrush(Colors.Red);
                lblError.Content = error;
            }
        }

        /// <summary>
        /// Funció genèrica per mostrar errors al formulari
        /// </summary>
        /// <param name="txt">El textbox que conté el valor erroni.</param>
        /// <param name="lblError">El label on cal mostra l'error.</param>
        /// <param name="campValid">Inidica si el valor és correcte.</param>
        /// <param name="error">Text d'error.</param>
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

        /// <summary>
        /// Valida el form, mostrant missatges en els camps que contenen valors erronis
        /// </summary>
        /// <returns></returns>
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
        Thickness original;

        /// <summary>
        /// Nou client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Mode = TipusMode.NOU;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Client.GetClients().Remove(clientActual);
            Mode = TipusMode.EN_ESPERA;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {

            filtrar();
        }


        private ObservableCollection<Client> clientsActuals;

        private void filtrar()
        {
            UnitOfWork uow = MySQLFactory.getUOW();
            IDAOClient dao = uow.DAOClients;

            clientsActuals = dao.GetClients(txtCercaId.Text, txtCercaRaoSocial.Text); //Client.GetClients();

            dtgClients.ItemsSource = clientsActuals;


            //dtgClients.ItemsSource = filtraClients(txtCercaId.Text, txtCercaRaoSocial.Text);
        }

        private OC<Client> clientsFiltrats;

        private OC<Client> filtraClients(string id, string rs)
        {
            clientsFiltrats = new OC<Client>();

            Client.GetClients().Where(c =>
                            (id == "" || c.Id + "" == id)
                            &&
                            (rs == "" || c.RaoSocial.ToLower().Contains(rs.ToLower()))).ToList().ForEach(clientsFiltrats.Add);


            /*foreach (Client c in Client.GetClients())
            {
                if(id.Length==0 || id == c.Id.ToString())
                {
                    if (rs.Length == 0 || rs == c.RaoSocial.ToString())
                    {
                        clientsFiltrats.Add(c);
                    }
                }                
            }*/
            return clientsFiltrats;
        }
    }
}