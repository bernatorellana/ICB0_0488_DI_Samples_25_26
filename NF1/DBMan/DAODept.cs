using Microsoft.EntityFrameworkCore;
using System;


namespace DBMan
{
    public class DAODept
    {
        /// <summary>
        /// Funció que retorna un llistat de departaments
        /// </summary>
        /// <returns></returns>
        public static string GetDepts()
        {
            String resultat = "";
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

                            resultat = $"{dept_no} \t\t {dnom} \t\t {loc} \n";
                        }
                    }

                }
            }
            return resultat;

        }
    }
}
