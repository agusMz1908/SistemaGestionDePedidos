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

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad entregada no puede ser negativa.")]
        public int EntregadosAntel { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad entregada no puede ser negativa.")]
        public int EntregadosMovistar { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad entregada no puede ser negativa.")]
        public int EntregadosClaro { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad entregada no puede ser negativa.")]
        public int EntregadosETH { get; set; }
        public int Total => EquiposAntel + EquiposMovistar + EquiposClaro + EquiposETH;
        public int Pendientes => Total - (EntregadosAntel + EntregadosMovistar + EntregadosClaro + EntregadosETH);
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaFinalizado { get; set; }
    }
}
