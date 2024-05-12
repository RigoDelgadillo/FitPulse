using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    [Table("Peso")]
    public partial class Peso
    {
        public Peso()
        {
            EjerciciosRutinas = new HashSet<EjerciciosRutina>();
        }

        [Key]
        [Column("ID_Peso")]
        public int IdPeso { get; set; }
        [Column("Peso")]
        [StringLength(15)]
        public string Peso1 { get; set; } = null!;

        [InverseProperty("IdPesoNavigation")]
        public virtual ICollection<EjerciciosRutina> EjerciciosRutinas { get; set; }
    }
}
