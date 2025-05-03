using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosMySql.Models
{
    public class DatosComparativosDiasSiguientes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        [Required]
        public int IdRegresionAct { get; set; }
        [ForeignKey("IdreGresionAct")]
        [Required]
        public float CoeficienteDet { get; set; }
        [Required]
        public float DifLunesAct { get; set; }
        [Required]
        public float DifMartesAct { get; set; }
        [Required]
        public float DifMiercolesAct { get; set; }
        [Required]
        public float DifJuevesAct { get; set; }
        [Required]
        public float DifViernesAct { get; set; }
        [Required]
        public float DifSabadoAct { get; set; }
        [Required]
        public float DifDomigoAct { get; set; }
        public List<PredicDifRealFaltante> PredicDifRealFaltantes { get; set; } = new List<PredicDifRealFaltante>();
    }
}