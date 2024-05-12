using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    public partial class EjerciciosRutina
    {
        [Key]
        [Column("ID_Ejercicio")]
        public int IdEjercicio { get; set; }
        [Key]
        [Column("ID_Rutina")]
        public int IdRutina { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        [Column("ID_Peso")]
        public int IdPeso { get; set; }

        [ForeignKey("IdEjercicio")]
        [InverseProperty("EjerciciosRutinas")]
        public virtual Ejercicio IdEjercicioNavigation { get; set; } = null!;
        [ForeignKey("IdPeso")]
        [InverseProperty("EjerciciosRutinas")]
        public virtual Peso IdPesoNavigation { get; set; } = null!;
        [ForeignKey("IdRutina")]
        [InverseProperty("EjerciciosRutinas")]
        public virtual Rutina IdRutinaNavigation { get; set; } = null!;
    }
}
