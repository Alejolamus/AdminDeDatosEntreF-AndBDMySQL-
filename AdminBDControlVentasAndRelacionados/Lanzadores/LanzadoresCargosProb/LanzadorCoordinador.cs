using AdminBDControlVentasAndRelacionados.Lanzadores.Agregado;
using AdminBDControlVentasAndRelacionados.Lanzadores.Eliminado;
using AdminBDControlVentasAndRelacionados.Lanzadores.Modificado;
using ConsulasInBdMySql.ConsultasForCSharpAdmin;
using System;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.LanzadoresCargosProb
{
    public class LanzadorCoordinador
    {
        public static void Ejecutar()
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar: (Producto, Venta y Entrega)");
            Console.WriteLine("2. Eliminar: (Producto, Venta y Producto en Venta)");
            Console.WriteLine("3. Consultas: (Empleados, Pedidos, Pedido individual, Productos y Ventas)");

            string opcion = Console.ReadLine();
            //Primer if para definicir el tiempo de accion agregar, elminar, o consultar
            if (opcion == "1")
            {
                Console.WriteLine("Seleccione lo que desea agregar:");
                Console.WriteLine("1. Producto");
                Console.WriteLine("2. Venta");
                Console.WriteLine("3. Entrega");
                int optiononet = int.Parse(Console.ReadLine());
                // if de agregado
                if (optiononet == 1)
                {
                    AddProducto.Ejecutar();
                }
                else if (optiononet == 2)
                {
                    AddVenta.Ejecutar();
                }
                else if (optiononet == 3)
                {
                    ActualizadorEstadoEntregas.Ejecutar();
                }
            }
            else if (opcion == "2")
            {
                Console.WriteLine("Seleccione lo que desea eliminar:");
                Console.WriteLine("1. Producto");
                Console.WriteLine("2. Venta");
                Console.WriteLine("3. Producto de una venta");
                int optiontwot = int.Parse(Console.ReadLine());
                // if de eliminado
                if (optiontwot == 1)
                {
                    EliminarProducto.Ejecutar();
                }
                else if (optiontwot == 2)
                {
                    EliminarVentaTotal.Ejecutar();
                }
                else if (optiontwot == 3)
                {
                    EliminarVentaTotal.Ejecutar();
                }
            }
            //if de consultas
            else if (opcion == "3")
            {
                Console.WriteLine("Seleccione el tipo de consulta:");
                Console.WriteLine("1. Empleados");
                Console.WriteLine("2. Pedidos");
                Console.WriteLine("3. Pedido individual");
                Console.WriteLine("4. Productos");
                Console.WriteLine("5. Ventas");
                int optiotrhee = int.Parse(Console.ReadLine());
                if (optiotrhee == 1)
                {
                    ConsultaEmpleados.Ejecutar();
                }
                else if (optiotrhee == 2)
                {
                    ConsultaPedidos.Ejecutar();
                }
                else if (optiotrhee == 3)
                {
                    ConsultaPedParticular.Ejecutar();
                }
                else if (optiotrhee == 4)
                {
                    ConsultaProducto.Ejecutar();
                }
                else if (optiotrhee == 5)
                {
                    ConsultaVentas.Ejecutar();
                }
            }
        }
    }
}