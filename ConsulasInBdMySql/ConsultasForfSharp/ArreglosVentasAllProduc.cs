using BaseDeDatosMySql.Context;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsulasInBdMySql.ConsultasForfSharp
{
    public class ArreglosVentasAllProduc
    {
        public static List<List<RegistroVenta>> ListaGlobalVentasProductos { get; private set; }

        public static List<List<RegistroVenta>> ObtenerListaVentas()
        {
            return ListaGlobalVentasProductos;
        }

        public static void Ejecutar()
        {
            using (var context = new RegistrosVentContext())
            {
                // Crea Array con productos existentes
                var ProductosExistentes = context.Productos
                    .Select(v => v.Nombre)
                    .ToArray();

                // Listas de registros (cantidades, IDs, fechas) de los productos
                List<List<RegistroVenta>> listaDeListasVentasProductos = new List<List<RegistroVenta>>();

                foreach (var nombreProducto in ProductosExistentes)
                {
                    List<RegistroVenta> listaDeVentas = new List<RegistroVenta>();

                    var ventasProducto = context.UnidadesVendidas
                        .Where(f => f.nProducto == nombreProducto)
                        .Select(f => new { f.CantidadVendida, f.IdVenta })
                        .ToList();

                    foreach (var unidad in ventasProducto)
                    {
                        var fechaVenta = context.Ventas
                            .Where(v => v.Id == unidad.IdVenta)
                            .Select(v => v.Fechadeventa)
                            .FirstOrDefault(); // Para obtener una sola fecha DateTime

                        listaDeVentas.Add(new RegistroVenta
                        {
                            Fecha = fechaVenta,
                            Cantidad = unidad.CantidadVendida,
                            Nombre = nombreProducto
                        });
                    }
                    listaDeListasVentasProductos.Add(listaDeVentas);
                }

                ListaGlobalVentasProductos = listaDeListasVentasProductos;
            }
        }
    }
}
