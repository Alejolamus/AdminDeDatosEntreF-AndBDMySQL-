using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseDeDatosMySql.Models
{
     public class PredicDifRealFaltante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdRegistroFal { get; set; }
        [ForeignKey("IdRegistroFal")]
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public float PredLunes { get; set; }
        [Required]
        public float PredMartes { get; set; }
        [Required]
        public float PredMiercoles { get; set; }
        [Required]
        public float PredJueves { get; set; }
        [Required]
        public float PredViernes { get; set; }
        [Required]
        public float PredSabado { get; set; }
        [Required]
        public float PredDomigo { get; set; }

    }
}