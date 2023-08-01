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
        public int TotalAntel => EquiposAntel;
        public int TotalMovistar => EquiposMovistar;
        public int TotalClaro => EquiposClaro;
        public int TotalETH => EquiposETH;
        public int Total => TotalAntel + TotalMovistar + TotalClaro + TotalETH;
        public int Pendientes { get; set; }
        public int EntregadosAntel { get; set; }
        public int EntregadosMovistar { get; set; }
        public int EntregadosClaro { get; set; }
        public int EntregadosETH { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaFinalizado { get; set; }
    }
}
