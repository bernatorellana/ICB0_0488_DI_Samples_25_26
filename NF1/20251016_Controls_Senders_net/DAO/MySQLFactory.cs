using IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class MySQLFactory
    {
        public static IDAOClient getDAOClient()
        {
            return new DAOClient();
        }

        public static IDAODept getDAODept()
        {
            return new DAODept();
        }
    }
}
