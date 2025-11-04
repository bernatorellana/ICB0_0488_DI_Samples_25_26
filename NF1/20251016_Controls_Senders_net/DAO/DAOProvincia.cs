using _20251001_Controls_Senders.model;
using IDAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DAO
{
    public class DAOProvincia : IDAOProvincia
    {

        private readonly MyDBContext _context;


        public DAOProvincia(MyDBContext c)
        {
            _context = c;
        }


        public Provincia GetProvincia(int id)
        {
            var connexio = _context.Database.GetDbConnection();
            // Obrir la connexió a la BD
            if (connexio.State == System.Data.ConnectionState.Closed)
            {
                connexio.Open();
            }
            // Crear una consulta SQL
            using (var consulta = connexio.CreateCommand())
            {

                // query SQL
                consulta.CommandText = @"select * from provincia
                                where id = @ID";

                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction(); // IMPORTANT !!! NO us ho deixeu <--------------------!!!!!!!

                Utils.CrearParametre(consulta, id, "ID", System.Data.DbType.Int32);


                consulta.Transaction = _context.Database.CurrentTransaction?.GetDbTransaction(); // IMPORTANT !!! NO us ho deixeu <--------------------!!!!!!!


                using (var reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nom = reader.GetString(reader.GetOrdinal("nom"));
                        return new Provincia(id, nom);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

    }

}
