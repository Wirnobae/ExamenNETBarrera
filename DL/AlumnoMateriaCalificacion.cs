//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlumnoMateriaCalificacion
    {
        public int IdAlumnoMateriaCalificacion { get; set; }
        public Nullable<int> IdAlumno { get; set; }
        public Nullable<int> IdMateria { get; set; }
        public Nullable<decimal> Calificacion { get; set; }
    
        public virtual Profesor Profesor { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
