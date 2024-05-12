using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    public partial class GruposMusculare
    {
        public GruposMusculare()
        {
            Ejercicios = new HashSet<Ejercicio>();
        }

        [Key]
        [Column("ID_GruposMusculares")]
        public int IdGruposMusculares { get; set; }
        [StringLength(15)]
        public string Musculo { get; set; } = null!;

        [InverseProperty("IdGruposMuscularesNavigation")]
        public virtual ICollection<Ejercicio> Ejercicios { get; set; }
    }
}
