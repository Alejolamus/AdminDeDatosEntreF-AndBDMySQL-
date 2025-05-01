using BaseDeDatosMySql.Context;
using BaseDeDatosMySql.Models;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Agregado
{
    class AddVenta
    {
        public static void Ejecutar()
        {
            //toma los datos desde colector
            var DatosVenta = ColectorDatosVentas.Ejecutar();
            int iddeventa;
            int TotalPedido = 0;
            int SaldoCliente = 0;
            int lengtproductos = (DatosVenta.ProductosAdd).Length;
            int[] PreciosPorConjuntoProducto = new int[lengtproductos];
            //Agregamos venta
            using (var context = new RegistrosVentContext())
            {
                var ventaN = new Venta
                {
                    Cliente = DatosVenta.NombreCliente,
                    Recaudo = DatosVenta.Recaudo,
                    CodTransaccion = DatosVenta.CodigoTransaccion,
                    Fechadeventa = DatosVenta.FechaVenta
                };
                context.Ventas.Add(ventaN);
                context.SaveChanges();
                iddeventa = ventaN.Id;
                //agrego unidades vendidas
                for (int i = 0; i < lengtproductos; i++)
                {
                    var Productocosultante = context.Productos
                    .Where(r => r.Nombre == (DatosVenta.ProductosAdd)[i])
                    .Select(r => new { r.Id, r.Precio })
                    .FirstOrDefault();
                    var unidaesagregadas = new UnidadesVendidas
                    {
                        IdVenta = iddeventa,
                        IdProducto = Productocosultante.Id,
                        nProducto = (DatosVenta.ProductosAdd)[i],
                        CantidadVendida = (DatosVenta.UnidadesVendidas)[i],
                        PrecioUnitario = Productocosultante.Precio
                    };
                    context.UnidadesVendidas.Add(unidaesagregadas);
                    context.SaveChanges();
                }
                //Agrego pedido
                for (int h = 0; h < lengtproductos; h++)
                {
                    var ProducConsultar = context.Productos
                    .Where(r => r.Nombre == (DatosVenta.ProductosAdd)[h])
                    .Select(r => r.Precio)
                    .FirstOrDefault();
                    PreciosPorConjuntoProducto[h] = h * ProducConsultar;
                }
                foreach (int Precioconjunto in PreciosPorConjuntoProducto)
                {
                    TotalPedido += Precioconjunto;
                }
                SaldoCliente = TotalPedido - DatosVenta.Recaudo;
                var pedidoN = new Pedido
                {
                    IdVenta = iddeventa,
                    Direccion = DatosVenta.DireccionDomi,
                    Cliente = DatosVenta.NombreCliente,
                    SaldoFaltante = SaldoCliente,
                    Correo = DatosVenta.CorreoVen,
                    Tel = DatosVenta.Telefono,
                    FechaEntrega = DatosVenta.FechaEntregaVen,
                    Entregado = DatosVenta.EngtregaHoNH
                };

                context.Pedidos.Add(pedidoN);
                context.SaveChanges();
            }
        }
    }
}