using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    public partial class Rutina
    {
        public Rutina()
        {
            Compras = new HashSet<Compra>();
            EjerciciosRutinas = new HashSet<EjerciciosRutina>();
        }

        [Key]
        [Column("ID_Rutina")]
        public int IdRutina { get; set; }
        [StringLength(15)]
        public string Nombre { get; set; } = null!;
        [StringLength(150)]
        public string Descripcion { get; set; } = null!;
        public double Precio { get; set; }

        [InverseProperty("IdPaqueteNavigation")]
        public virtual ICollection<Compra> Compras { get; set; }
        [InverseProperty("IdRutinaNavigation")]
        public virtual ICollection<EjerciciosRutina> EjerciciosRutinas { get; set; }
    }
}
