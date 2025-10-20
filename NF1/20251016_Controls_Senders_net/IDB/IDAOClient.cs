using _20251001_Controls_Senders.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAO
{
    public interface IDAOClient
    {
        public List<Client> GetClients(string id, string rao_social);

        public Client GetClient(int id);

        public bool UpdateClient(Client c);

        public bool InsertClient(Client c);



    }
}
