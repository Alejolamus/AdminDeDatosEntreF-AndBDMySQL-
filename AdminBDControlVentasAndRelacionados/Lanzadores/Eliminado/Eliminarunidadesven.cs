using BaseDeDatosMySql.Context;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Eliminado
{
    public class Eliminarunidadesven
    {
        public static void Ejecutar()
        {
            using (var context = new RegistrosVentContext())
            {
                // Solicitar datos al usuario de venta
                Console.Write("Ingrese el nombre del cliente: ");
                string Nombreclient = Console.ReadLine();

                Console.Write("Ingrese la fecha de venta con formato dd/MM/yyyy HH:mm:ss: ");
                string fechaven = Console.ReadLine();

                DateTime Fechaventaquit;
                bool sirvecomofecha = false;

                do
                {
                    Console.Write("Fecha: (dd/MM/yyyy HH:mm:ss): ");
                    string fechaventarep = Console.ReadLine();

                    sirvecomofecha = DateTime.TryParseExact(
                        fechaventarep,
                        "dd/MM/yyyy HH:mm:ss",
                        null,
                        System.Globalization.DateTimeStyles.None,
                        out Fechaventaquit
                    );
                } while (!sirvecomofecha);

                // Buscar ID de la venta
                var ventar = context.Ventas
                    .Where(p => p.Cliente == Nombreclient && p.Fechadeventa == Fechaventaquit)
                    .FirstOrDefault();

                if (ventar == null)
                {
                    Console.WriteLine("No se encontró una venta con los datos ingresados.");
                    return;
                }
                int IdvenMod = ventar.Id;
                // Consulta de productos en una venta e imprime
                var unidadesvendidas = context.UnidadesVendidas
                    .Where(uv => uv.IdVenta == IdvenMod)
                    .Select(uv => new { uv.Id, uv.nProducto, uv.CantidadVendida })
                    .ToArray();
                if (unidadesvendidas.Any())
                {
                    Console.WriteLine("No hay productos registrados en la venta.");
                    return;
                }

                Console.WriteLine("Lista de productos disponibles:");
                foreach (var producinvent in unidadesvendidas)
                // Solicita numero de productos a cambiar ( nombre y cantidad a restar)
                {
                    Console.WriteLine($"producto {producinvent.nProducto}, con un total de {producinvent.CantidadVendida}");
                }
                Console.WriteLine("numero de productos a modificar");
                int numamod = int.Parse(Console.ReadLine());
                // ciclo for para cambiar cada producto 1 a 1
                for (int i = 0; i < numamod; i++)
                {
                    Console.WriteLine("Producto a modificar");
                    string promod = Console.ReadLine();
                    bool producvent = false;
                    int nuevaCantidad = 0;
                    var numares = 0;
                    string unidadx = "";
                    //ciclo foreach para idenficar si el prodecto esta registrado en la venta
                    foreach (var unidad in unidadesvendidas)
                    {
                        if (unidad.nProducto == promod)// tipos de variable incompatible
                        {
                            producvent = true;
                            Console.WriteLine("Unidades vendidas a restar");
                            int numaresn = int.Parse(Console.ReadLine());
                            nuevaCantidad = unidad.CantidadVendida - numaresn;
                            numares = numares + numaresn;
                            unidadx = unidad.nProducto;//re eval(no necesario"")
                            break;
                        }
                    }
                    var unidadEliminar = context.UnidadesVendidas
                        .FirstOrDefault(uv => uv.nProducto == unidadx);
                    // condicional index elimina registro por id en caso de que sea 0 el numero final de unidades vendidas
                    // en caso contrario modifica unicamente el valor de unidades vendidas
                    if (producvent)
                        if (nuevaCantidad == 0)
                        {
                            context.UnidadesVendidas.Remove(unidadEliminar);
                            context.SaveChanges();
                            Console.WriteLine("Se elimino el registro del producto asociado a la venta");
                        }
                        else if (nuevaCantidad != 0)
                        {
                            unidadEliminar.CantidadVendida = nuevaCantidad;
                            context.SaveChanges();
                            Console.WriteLine($"Se modifico el numero de unidades vendidas de '{unidadx}: unidades vendidas '{nuevaCantidad}'");
                        }
                        else
                        {
                            Console.WriteLine($"El producto '{promod}' no está en la venta.");
                        }
                }
            }
        }
    }
}