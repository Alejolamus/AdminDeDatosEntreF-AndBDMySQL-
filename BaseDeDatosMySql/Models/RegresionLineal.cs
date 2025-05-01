using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosMySql.Models
{
    public class RegresionLineal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        [Required]
        public string Ecuacion { get; set; }

        [Required]
        public float Pendiente { get; set; }
        [Required]
        public float Ejey { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int CantidadDay { get; set; }
        public List<DatosComparativosDiasAnteriores> DatosComparativosDiasAnteriore { get; set; } = new List<DatosComparativosDiasAnteriores>();
        public List<DatosComparativosDiasSiguientes> DatosComparativosDiasSiguientes { get; set; } = new List<DatosComparativosDiasSiguientes>();
    }
}