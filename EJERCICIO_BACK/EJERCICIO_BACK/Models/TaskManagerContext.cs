using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EJERCICIO_BACK.Models
{
    public partial class TaskManagerContext : DbContext
    {
        public TaskManagerContext()
            : base("name=TaskManagerContext")
        {
        }

        public virtual DbSet<TAREAS> TAREAS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
