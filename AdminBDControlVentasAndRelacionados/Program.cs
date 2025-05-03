using AdminBDControlVentasAndRelacionados.BaseDePrueva;
using AdminBDControlVentasAndRelacionados.Lanzadores.LanzadoresCargosProb;
using BaseDeDatosMySql.Context;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados
{
    class Program
    {
        static void Main()
        {
            using (var context = new RegistrosVentContext())
            {
                var RecUsersr = context.Users.ToArray();
                if (RecUsersr.Length == 0)
                {
                    Console.WriteLine("No se encuentran datos en users");
                    Console.WriteLine("Desea lanzar Users de prueba? (S/N)");
                    string RespuesBdUsers = Console.ReadLine();
                    if (RespuesBdUsers.ToUpper() == "S")
                    {
                        UsersBDTest.Ejecutar();
                    }
                }
                var RecProductos = context.Productos.ToArray();
                if (RecProductos.Length == 0)
                {
                    Console.WriteLine("No se encuentran datos en users");
                    Console.WriteLine("Desea lanzar Productos de prueba? (S/N)");
                    string RespuesBdUsers = Console.ReadLine();
                    if (RespuesBdUsers.ToUpper() == "S")
                    {
                        ProductosBSTest.Ejecutar();
                    }
                }
                var RecVentas = context.Ventas.ToArray();
                if (RecVentas.Length == 0)
                {
                    Console.WriteLine("No se encuentran datos en users");
                    Console.WriteLine("Desea lanzar Ventas y mas registros de prueba? (S/N)");
                    string RespuesBdUsers = Console.ReadLine();
                    if (RespuesBdUsers.ToUpper() == "S")
                    {
                        VentasBDTest.Ejecutar();
                    }
                }
            }
            LanzadorUsers.Ejecutar();
        }
    }
}