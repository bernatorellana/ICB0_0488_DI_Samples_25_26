using IDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManOk
{
    public class MySQLFactory
    {
        public static IDAODept getDAODept()
        {
            return new DAODept();
        }
    }
}
