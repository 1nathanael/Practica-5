//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AsignaturaEstudiante
    {
        public int id { get; set; }
        public Nullable<int> Asignatura_id { get; set; }
        public Nullable<int> Estudiante_id { get; set; }
    
        public virtual Asignaturas Asignaturas { get; set; }
        public virtual Estudiantes Estudiantes { get; set; }
    }
}
