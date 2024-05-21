using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PIAProWeb.Models.dbModels
{
    public class EjercicioHR
    {
        [Column("ID_Ejercicio")]
        public int IdEjercicio { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int IdGruposMusculares { get; set; }
    }
}
