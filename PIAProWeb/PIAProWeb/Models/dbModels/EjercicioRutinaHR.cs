using System.ComponentModel.DataAnnotations.Schema;

namespace PIAProWeb.Models.dbModels
{
    public class EjercicioRutinaHR
    {
        public int IdEjercicio { get; set; }
        public int IdRutina { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public int IdPeso { get; set; }
    }
}
