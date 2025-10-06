using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace _20251001_Controls_Senders.model
{
    public class Client : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private String CIF;
        private String raoSocial;
        private Boolean esActiva;
        private TipusEmpresa tipus;
        private Provincia provincia;
        private Dictionary<String, bool> opcions = 
            new Dictionary<String, bool>();

        public Client(int id, string cIF, string raoSocial, bool esActiva, TipusEmpresa tipus, Provincia provincia)
        {
            this.Id = id;
            CIF1 = cIF;
            this.RaoSocial = raoSocial;
            this.EsActiva = esActiva;
            this.Tipus = tipus;
            this.Provincia = provincia;
        }

        #region Properties

        public int Id { get => id; set
            {
                id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Foto"));
            }
        }
        public string CIF1 { get => CIF; set => CIF = value; }
        public string RaoSocial { 
            get => raoSocial;
            set
            {
                if (value != raoSocial)
                {
                    raoSocial = value;
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RaoSocial)));
                }
            }
        }
        public bool EsActiva { get => esActiva; set => esActiva = value; }
        public Dictionary<string, bool> Opcions { get => opcions; set => opcions = value; }
        public TipusEmpresa Tipus { get => tipus; set => tipus = value; }
        public Provincia Provincia { get => provincia; set => provincia = value; }

    
        [DependsOn("Id")]
        public String Foto
        {
            get => "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/" + id+".png";
     
        }

        #endregion


        #region singleton

        private static OC<Client> _clients;

     

        public static OC<Client> GetClients()
        {
            if( _clients == null)
            {
                _clients = new OC<Client>();
                Client pep = new Client(12, "J7677666T", "Camping S.A.", false, 
                                            TipusEmpresa.PRIVADA, Provincia.GetProvincies()[0]);

                _clients.Add(pep);

                Client maria = new Client(34, "1111111H", "Enginyeria AKT", true, TipusEmpresa.AUTONOM,
                                           Provincia.GetProvincies().Where( p => p.Id==2 ).First());
                _clients.Add(maria);
            }

            return _clients;
        }



        #endregion




    }
}
