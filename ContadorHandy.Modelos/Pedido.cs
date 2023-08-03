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
        public int EquiposAntel { get; set; }
        public int EquiposMovistar { get; set; }
        public int EquiposClaro { get; set; }

        // Propiedades para obtener los valores entregados de cada compañía
        public int EntregadosAntel { get; set; }
        public int EntregadosMovistar { get; set; }
        public int EntregadosClaro { get; set; }
        public int EntregadosETH { get; set; }

        // Total de equipos pedidos sin tener en cuenta los entregados
        public int Total => EquiposAntel + EquiposMovistar + EquiposClaro + EquiposETH;

        // Pendientes son los equipos totales menos los entregados
        public int Pendientes => Total - (EntregadosAntel + EntregadosMovistar + EntregadosClaro + EntregadosETH);

        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaFinalizado { get; set; }
    }
}
