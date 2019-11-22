namespace Practica5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Estudiantes
    {
        public int id { get; set; }

        [StringLength(30)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string materias { get; set; }

        public List<Estudiantes> Listar()
        {
            var estudiante = new List<Estudiantes>();
            try
            {
                using (var context = new Model2())
                {
                    estudiante = context.Estudiantes.ToList(); 
                }
            
            }
            catch (Exception)
            {
                throw;
            }
            return estudiante; 
        }
    }
}
