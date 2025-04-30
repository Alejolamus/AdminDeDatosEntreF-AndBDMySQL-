using BaseDeDatosMySql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulasInBdMySql.ConsultasForCSharpAdmin
{
    public class ConsultaProducto
    {
        public static void Ejecutar()
        {
            // Lista los productos con sus atributos
            using (var context = new RegistrosVentContext())
            {
                var productos = context.Productos.ToArray();
                if (productos.Length == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return;
                }

                Console.WriteLine("Lista de productos disponibles:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"- Nombre: {producto.Nombre}, Precio: {producto.Precio}, se cuenta con un total de {producto.CantidadEnB} unidades para venta");
                }
            }

        }
    }
}