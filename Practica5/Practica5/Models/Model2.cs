namespace Practica5.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<Estudiantes> Estudiantes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiantes>()
                .Property(e => e.materias)
                .IsUnicode(false);
        }
    }
}
