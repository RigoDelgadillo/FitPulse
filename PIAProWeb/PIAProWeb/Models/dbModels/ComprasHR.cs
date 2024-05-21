using System.ComponentModel.DataAnnotations.Schema;

namespace PIAProWeb.Models.dbModels
{
    public class ComprasHR
    {
        [Column("ID_Compra")]
        public int IdCompra { get; set; }
        public int IdMetodoPago { get; set; }
        public DateTime FechaCompra { get; set; }
        public double PrecioTotal { get; set; }
        public int IdUsuario { get; set; }
        public int IdPaquete { get; set; }
    }
}
