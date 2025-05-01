using BaseDeDatosMySql.Context;
using BaseDeDatosMySql.Models;
using System;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Agregado
{
    public class AddProducto
    {
        public static void Ejecutar()
        {
            //Recoje los datos basicos
            Console.Write("Nombre de producto: ");
            string nombreProducto = Console.ReadLine();

            Console.Write("Número en Bodega: ");
            int nuBodega = int.Parse(Console.ReadLine());

            Console.Write("Precio: ");
            int Valor = int.Parse(Console.ReadLine());

            // Registra producto nuevo con Cantidad min en 0

            using (var context = new RegistrosVentContext())
            {
                var productoN = new Producto
                {
                    Nombre = nombreProducto,
                    CantidadEnB = nuBodega,
                    CantidadMin = 0,
                    Precio = Valor
                };

                context.Productos.Add(productoN);
                context.SaveChanges();

                Console.WriteLine("Se agregó el producto correctamente.");
            }
        }
    }
}