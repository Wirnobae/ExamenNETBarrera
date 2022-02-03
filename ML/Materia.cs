using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        [Required(ErrorMessage = "Ingrese el Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese el Costo")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public decimal Costo { get; set; }
        public decimal Creditos { get; set; }
        public List<object> Materias { get; set; }
    }
}
