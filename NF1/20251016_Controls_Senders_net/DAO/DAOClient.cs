using _20251001_Controls_Senders.model;
using IDAO;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOClient : IDAOClient
    {
        public Client GetClient(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetClients(string id_filtre, string rao_social_filtre)
        {
            List<Client> resultat = new List<Client>();
            using (MyDBContext context = new MyDBContext())
            {
                using (var connexio = context.Database.GetDbConnection()) // <== NOTA IMPORTANT: requereix ==>using Microsoft.EntityFrameworkCore;
                {
                    // Obrir la connexió a la BD
                    connexio.Open();

                    // Crear una consulta SQL
                    using (var consulta = connexio.CreateCommand())
                    {

                        // query SQL
                        consulta.CommandText = @"select *  
                                                from client";
                        var reader = consulta.ExecuteReader();
                        while (reader.Read()) // per cada Read() avancem una fila en els resultats de la consulta.
                        {

                            // Descarreguem les dades de cada columna de la taula
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string CIF = reader.GetString(reader.GetOrdinal("CIF"));
                            string raoSocial = reader.GetString(reader.GetOrdinal("raoSocial"));
                            bool esActiva = reader.GetInt32(reader.GetOrdinal("esActiva"))==1;
                            int tipus = reader.GetInt32(reader.GetOrdinal("tipus"));
                            int provincia_id = reader.GetInt32(reader.GetOrdinal("provincia_id"));
                            string imatge_url = reader.GetString(reader.GetOrdinal("imatge_url"));

                            Client c = new Client(id, CIF, raoSocial, esActiva, (TipusEmpresa)tipus,
                                Provincia.GetProvincies().Where(x => x.Id == provincia_id).First());

                            resultat.Add(c);
                        }

                    }

                }
            }
            return resultat;
        }

        public bool InsertClient(Client c)
        {
            throw new NotImplementedException();
        }

        public bool UpdateClient(Client c)
        {
            throw new NotImplementedException();
        }
    }
}
