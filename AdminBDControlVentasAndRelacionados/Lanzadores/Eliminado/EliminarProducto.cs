using BaseDeDatosMySql.Context;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Eliminado
{
    public class EliminarProducto
    {
        public static void Ejecutar()
        {
            using (var context = new RegistrosVentContext())
            {
                //Lista productos
                var productos = context.Productos.ToArray();

                if (productos.Length == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                Console.WriteLine("Lista de productos disponibles:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"- {producto.Nombre}");
                }
                //Selecciona producto a eliminar
                Console.Write("Ingrese el nombre del producto a eliminar: ");
                string nombreProElim = Console.ReadLine();

                // Buscar y eliminar el producto
                var entidad = context.Productos.FirstOrDefault(e => e.Nombre == nombreProElim);

                if (entidad != null)
                {
                    context.Productos.Remove(entidad);
                    context.SaveChanges();
                    Console.WriteLine($"El producto '{nombreProElim}' ha sido eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine($"No se encontró un producto con el nombre '{nombreProElim}'.");
                }
            }
        }
    }
}