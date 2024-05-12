using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PIAProWeb.Models.dbModels
{
    public partial class Usuario
    {
        public Usuario()
        {
            Compras = new HashSet<Compra>();
        }

        [Key]
        [Column("ID_Usuario")]
        public int IdUsuario { get; set; }
        [StringLength(30)]
        public string Nombre { get; set; } = null!;
        [StringLength(50)]
        public string Apellidos { get; set; } = null!;
        [StringLength(320)]
        public string Email { get; set; } = null!;
        [StringLength(50)]
        public string Contraseña { get; set; } = null!;
        public int Telefono { get; set; }
        [Column("ID_Rol")]
        public int IdRol { get; set; }
        [Column("Fecha_Inscripcion", TypeName = "datetime")]
        public DateTime FechaInscripcion { get; set; }
        public bool EstadoMembresia { get; set; }

        [ForeignKey("IdRol")]
        [InverseProperty("Usuarios")]
        public virtual Role IdRolNavigation { get; set; } = null!;
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
