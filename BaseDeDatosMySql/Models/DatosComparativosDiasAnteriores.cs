using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosMySql.Models
{
    public class DatosComparativosDiasAnteriores
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
        public int IdRegresionAnt { get; set; }
        [ForeignKey("IdreGresionAnt")]
        [Required]
        public float CoeficienteDet { get; set; }
        [Required]
        public float DifLunesAnt { get; set; }
        [Required]
        public float DifMartesAnt { get; set; }
        [Required]
        public float DifMiercolesAnt { get; set; }
        [Required]
        public float DifJuevesAnt { get; set; }
        [Required]
        public float DifViernesAnt { get; set; }
        [Required]
        public float DifSabadoAnt { get; set; }
        [Required]
        public float DifDomigoAnt { get; set; }

    }
}