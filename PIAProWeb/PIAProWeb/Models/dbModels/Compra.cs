using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    public partial class Compra
    {
        [Key]
        [Column("ID_Compra")]
        public int IdCompra { get; set; }
        [Column("ID_MetodoPago")]
        public int IdMetodoPago { get; set; }
        [Column("Fecha_Compra", TypeName = "datetime")]
        public DateTime FechaCompra { get; set; }
        [Column("Precio_Total")]
        public double PrecioTotal { get; set; }
        [Column("ID_Usuario")]
        public int IdUsuario { get; set; }
        [Column("ID_Paquete")]
        public int IdPaquete { get; set; }

        [ForeignKey("IdMetodoPago")]
        [InverseProperty("Compras")]
        public virtual MetodoPago IdMetodoPagoNavigation { get; set; } = null!;
        [ForeignKey("IdPaquete")]
        [InverseProperty("Compras")]
        public virtual Rutina IdPaqueteNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Compras")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
