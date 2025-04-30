using BaseDeDatosMySql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulasInBdMySql.ConsultasForCSharpAdmin
{
    public class ConsultaPedidos
    {
        public static void Ejecutar()
        {
            Boolean Conparaentrega = true;
            using (var context = new RegistrosVentContext())
            {
                // lista las ventas
                var idsventas = context.Ventas
                    .ToArray();
                foreach (var iddeventa in idsventas)
                {//revisar la coomparacion entre idventa y iddeventa
                    var domicilios = context.Pedidos
                        .Where(v => v.IdVenta == iddeventa.Id & v.Entregado == Conparaentrega)
                        .ToArray();
                    //Lista los pedidos sin entregar
                    if (domicilios.Length == 0)
                    {
                        Console.WriteLine("No se encontraron pedidos por entregar");
                    }
                    {
                        Console.WriteLine("Lista de entregas pendientes");
                        foreach (var domici in domicilios)
                        {
                            Console.WriteLine($"El cliente: {domici.Cliente} tiene un pedido para entregar el {domici.FechaEntrega} a la direccion: {domici.Direccion}");
                        }
                    }

                }
            }

        }
    }
}