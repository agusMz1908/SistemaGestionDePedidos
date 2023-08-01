using ContadorHandy.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorHandy.AccesoDatos.Repository.IRepository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        void Update(Pedido pedido);
    }
}
