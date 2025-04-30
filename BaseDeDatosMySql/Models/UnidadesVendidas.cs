using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatosMySql.Models
{
    public class UnidadesVendidas
    {
        [Key]
        public int Id { get; set; }

        public int IdVenta { get; set; }
        [ForeignKey("IdVenta")]
        public Venta Ventas { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public Producto Productos { get; set; }
        public string nProducto { get; set; }

        [Required]
        public int CantidadVendida { get; set; }
        [Required]
        public int PrecioUnitario { get; set; }

    }
}