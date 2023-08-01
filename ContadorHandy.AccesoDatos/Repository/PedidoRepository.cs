using ContadorHandy.AccesoDatos.Repository.IRepository;
using ContadorHandy.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorHandy.AccesoDatos.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private ApplicationDbContext _db;

        public PedidoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Pedido pedido)
        { 
            _db.Pedidos.Update(pedido);
        }
    }
}
