namespace EJERCICIO_BACK.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    public partial class TAREAS
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TITULO { get; set; }

        [StringLength(500)]
        public string DESCRIPCION { get; set; }

        [Required]
        public DateTime FECHA_CREACION { get; set; }

        [Required]
        public bool ESTADO { get; set; }
    }

}
