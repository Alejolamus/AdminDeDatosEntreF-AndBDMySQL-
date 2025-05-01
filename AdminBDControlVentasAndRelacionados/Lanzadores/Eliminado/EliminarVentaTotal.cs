using BaseDeDatosMySql.Context;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Eliminado
{
    public class EliminarVentaTotal
    {
        public static void Ejecutar()
        {
            using (var context = new RegistrosVentContext())
            {
                // Solicitar datos al usuario
                Console.Write("Ingrese el nombre del cliente: ");
                string nombreclient = Console.ReadLine();
                DateTime fechav;
                bool correccionfecha;
                do
                {
                    Console.Write("Fecha: (dd/MM/yyyy HH:mm:ss): ");
                    string fechaven = Console.ReadLine();

                    correccionfecha = DateTime.TryParseExact(
                        fechaven,
                        "dd/MM/yyyy HH:mm:ss",
                        null,
                        System.Globalization.DateTimeStyles.None,
                        out fechav
                    );
                } while (!correccionfecha);
                // Buscar ID de la venta
                var venta = context.Ventas
                    .Where(p => p.Cliente == nombreclient && p.Fechadeventa == fechav)
                    .FirstOrDefault();

                if (venta == null)
                {
                    Console.WriteLine("No se encontró una venta con los datos ingresados.");
                    return;
                }

                int Idvendelete = venta.Id;

                // Eliminar la venta
                context.Ventas.Remove(venta);
                context.SaveChanges();
                Console.WriteLine($"Venta con ID {Idvendelete} eliminada correctamente.");

                // Eliminar registros de UnidadesVendidas asociados
                var unidadesVendidas = context.UnidadesVendidas.Where(uv => uv.IdVenta == Idvendelete).ToList();
                if (unidadesVendidas.Any())
                {
                    context.UnidadesVendidas.RemoveRange(unidadesVendidas);
                    context.SaveChanges();
                    Console.WriteLine("Se eliminaron las unidades vendidas asociadas a la venta.");
                }

                // Eliminar registros de Pedidos asociados
                var pedidos = context.Pedidos.Where(p => p.IdVenta == Idvendelete).ToList();
                if (pedidos.Any())
                {
                    context.Pedidos.RemoveRange(pedidos);
                    context.SaveChanges();
                    Console.WriteLine("Se eliminaron los pedidos asociados a la venta.");
                }
            }
        }
    }
}