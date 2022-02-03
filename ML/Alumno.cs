using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
       [Required(ErrorMessage = "Ingrese el Nombre")]
        public string Nombre { get; set; }
        public string ApellidoPaterno{get; set;}
        public string ApellidoMaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public int IdRol { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ML.Roles Roles { get; set; }
        public List<object> Alumnos { get; set; }
    }
}
