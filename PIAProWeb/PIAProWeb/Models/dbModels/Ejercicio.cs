using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    public partial class Ejercicio
    {
        public Ejercicio()
        {
            EjerciciosRutinas = new HashSet<EjerciciosRutina>();
        }

        [Key]
        [Column("ID_Ejercicio")]
        public int IdEjercicio { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(100)]
        public string Descripcion { get; set; } = null!;
        [Column("ID_GruposMusculares")]
        public int IdGruposMusculares { get; set; }

        [ForeignKey("IdGruposMusculares")]
        [InverseProperty("Ejercicios")]
        public virtual GruposMusculare IdGruposMuscularesNavigation { get; set; } = null!;
        [InverseProperty("IdEjercicioNavigation")]
        public virtual ICollection<EjerciciosRutina> EjerciciosRutinas { get; set; }
    }
}
