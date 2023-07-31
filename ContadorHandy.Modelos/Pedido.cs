using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContadorHandy.Modelos
{
    public enum TipoPedido
    { 
        Normal,
        PosLink
    }
    public class Pedido
    {
       [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public TipoPedido Tipo { get; set; }
        public int EquiposETH { get; set; }
        public int Equipos3G { get; set; }
        public int Total => EquiposETH + Equipos3G;
        public int Pendientes => Total - (EquiposETH + Equipos3G);
        public int EntregadosETH { get; set; }
        public int Entregados3G { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaFinalizado { get; set; }

    }
}
