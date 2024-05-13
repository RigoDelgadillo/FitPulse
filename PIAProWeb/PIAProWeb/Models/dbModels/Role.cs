using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    public partial class Role
    {
        public Role()
        {
            Usuarios = new HashSet<ApplicationUser>();
        }

        [Key]
        [Column("ID_Rol")]
        public int IdRol { get; set; }
        [StringLength(20)]
        public string Rol { get; set; } = null!;
        [StringLength(100)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdRolNavigation")]
        public virtual ICollection<ApplicationUser> Usuarios { get; set; }
    }
}
