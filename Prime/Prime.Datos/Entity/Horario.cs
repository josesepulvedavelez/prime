//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prime.Datos.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Horario
    {
        public string Dia { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public string Aula { get; set; }
        public int HorarioId { get; set; }
        public Nullable<int> EstudianteId { get; set; }
        public Nullable<int> Curso { get; set; }
    
        public virtual Curso Curso1 { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}