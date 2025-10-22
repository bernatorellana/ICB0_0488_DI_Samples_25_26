using IDAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UnitOfWork : IDisposable
    {
        private readonly MyDBContext _context;

        public IDAOClient Clients { get; }
        

        public UnitOfWork(MyDBContext context)
        {
            _context = context;
            Clients = new DAOClient(_context);
         }

        public void Commit() => _context.Database.CurrentTransaction?.Commit();

        public void Rollback() => _context.Database.CurrentTransaction?.Rollback();

        public void Dispose()
        {
         }
    }



}
