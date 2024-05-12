using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("MetodoPago")]
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            Compras = new HashSet<Compra>();
        }

        [Key]
        [Column("ID_MetodoPago")]
        public int IdMetodoPago { get; set; }
        [StringLength(15)]
        public string Metodo { get; set; } = null!;

        [InverseProperty("IdMetodoPagoNavigation")]
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
