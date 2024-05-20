using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PIAProWeb.Models.dbModels
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            Compras = new HashSet<Compra>();
        }

        
        public string? Apellidos { get; set; } = null;
        [StringLength(320)]
        public int IdRol { get; set; }
        [Column("Fecha_Inscripcion", TypeName = "datetime")]
        public DateTime? Fecha_Inscripcion { get; set; } = null;
        public bool? EstadoMembresia { get; set; } = null;

        [ForeignKey("IdRol")]
        [InverseProperty("Usuarios")]
        public virtual Role IdRolNavigation { get; set; } = null!;
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
