using BaseDeDatosMySql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulasInBdMySql.ConsultasForCSharpAdmin
{
    public class ConsultaPedParticular
    {
        public static void Ejecutar()
        {
            using (var context = new RegistrosVentContext())
            {
                // Solicitar datos al usuario
                Console.Write("Ingrese el nombre del cliente: ");
                string Nombreclient = Console.ReadLine();
                DateTime fechavencons;
                bool pedfecha;
                do
                {
                    Console.Write("Fecha: (dd/MM/yyyy HH:mm:ss): ");
                    string fechavencon = Console.ReadLine();

                    pedfecha = DateTime.TryParseExact(
                        fechavencon,
                        "dd/MM/yyyy HH:mm:ss",
                        null,
                        System.Globalization.DateTimeStyles.None,
                        out fechavencons
                    );
                } while (!pedfecha);
                // Buscar venta y su id
                var ventare = context.Ventas
                    .Where(p => p.Cliente == Nombreclient && p.Fechadeventa == fechavencons)
                    .FirstOrDefault();

                int IdvenConsul = ventare.Id;
                if (ventare == null)
                {
                    Console.WriteLine("No se encontró una venta con los datos ingresados.");
                    return;
                }
                //entrega detalles de pedido
                var Pedidoconsul = context.Pedidos
                    .Where(h => h.IdVenta == IdvenConsul)
                    .FirstOrDefault();
                var CantidadesProd = context.UnidadesVendidas
                    .Where(r => r.IdVenta == IdvenConsul)
                    .Select(r => new { r.nProducto, r.CantidadVendida })
                    .ToList();
                if (Pedidoconsul.Entregado == true)
                {
                    Console.WriteLine($"El pedido ha sido entregado el dia {Pedidoconsul.FechaEntrega} con los siguientes productos:");
                    foreach (var ProdCant in CantidadesProd)
                    {
                        Console.WriteLine($" Producto: {ProdCant.nProducto} y {ProdCant.CantidadVendida}");

                    }
                }
                else
                {
                    Console.WriteLine($"El pedido programado para el dia {Pedidoconsul.FechaEntrega} con los siguientes productos:");
                    foreach (var ProdCant in CantidadesProd)
                    {
                        Console.WriteLine($" Producto: {ProdCant.nProducto} y {ProdCant.CantidadVendida}");

                    }
                }
            }
        }
    }
}