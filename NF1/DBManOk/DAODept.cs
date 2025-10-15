using IDB;
using Microsoft.EntityFrameworkCore;
using Model;
using System;


namespace DBManOk
{
    public class DAODept:IDAODept
    {
        /// <summary>
        /// Funció que retorna un llistat de departaments
        /// </summary>
        /// <returns></returns>
        public  List<Dept> GetDepts()
        {
            List<Dept> resultat = new List<Dept>();
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
                                                from dept ";
                        var reader = consulta.ExecuteReader();
                        while (reader.Read()) // per cada Read() avancem una fila en els resultats de la consulta.
                        {
                            int dept_no = reader.GetInt32(reader.GetOrdinal("DEPT_NO"));
                            string dnom = reader.GetString(reader.GetOrdinal("DNOM"));
                            string loc = reader.GetString(reader.GetOrdinal("LOC"));

                            Dept d = new Dept(dept_no, dnom, loc);

                            resultat.Add(d);
                        }

                        //consulta.CommandText = @"select count(1) from dept";
                        //int? comptatge = (int?)consulta.ExecuteScalar();




                    }

                }
            }
            return resultat;

        }
    }
}
