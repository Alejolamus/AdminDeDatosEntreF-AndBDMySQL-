using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosMySql.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int CantidadEnB { get; set; }

        [Required]
        public int CantidadMin { get; set; }
        [Required]
        public int Precio { get; set; }
        public List<UnidadesVendidas> UnidadesVendidas { get; set; } = new List<UnidadesVendidas>();
        public List<RegresionLineal> RegresionesLineaes { get; set; } = new List<RegresionLineal>();
        public List<DatosComparativosDiasAnteriores> DatosComparativosDiasAnteriore { get; set; } = new List<DatosComparativosDiasAnteriores>();
        public List<DatosComparativosDiasSiguientes> DatosComparativosDiasSiguientes { get; set; } = new List<DatosComparativosDiasSiguientes>();
    }
}