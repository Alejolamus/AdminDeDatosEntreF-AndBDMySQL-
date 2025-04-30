using System;

namespace Models
{
    public class DatosVenta
    {
        public string NombreCliente { get; set; }
        public int Recaudo { get; set; }
        public int CodigoTransaccion { get; set; }
        public DateTime FechaVenta { get; set; }
        public string[] ProductosAdd { get; set; }
        public int[] UnidadesVendidas { get; set; }
        public string CorreoVen { get; set; }
        public string Telefono { get; set; }
        public string DireccionDomi { get; set; }
        public DateTime FechaEntregaVen { get; set; }
        public bool EngtregaHoNH { get; set; }
    }
}