using ContadorHandy.AccesoDatos.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorHandy.AccesoDatos.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db;
        public IPedidoRepository Pedido { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Pedido = new PedidoRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
