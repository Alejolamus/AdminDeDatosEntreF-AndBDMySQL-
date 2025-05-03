using BaseDeDatosMySql.Context;
using BaseDeDatosMySql.Models;
using System;
using System.Linq;
using TratadoresDeDataForAdminCSharp;

namespace AdminBDControlVentasAndRelacionados.BaseDePrueva
{
    public class ProductosBSTest
    {
        public static void Ejecutar()
        {
            //llamo las listas desde f#
            var productosTestBdProv = DataBDtest.ProductosAddTestBase;
            var cantidadesTestBdProv = DataBDtest.CantidadesEnBodegaTestBase;
            var preciosTestBdProv = DataBDtest.PreciosTestBase;
            //Las paso a array
            string[] productosTestBdProvArray = productosTestBdProv.ToArray();
            int[] cantidadesTestBdProvvArray = cantidadesTestBdProv.ToArray();
            int[] preciosTestBdProvArray = preciosTestBdProv.ToArray();
            //cilo para agregar usuarios
            using (var context = new RegistrosVentContext())
            {
                foreach (var x in productosTestBdProvArray)
                {
                    int xIndex = Array.IndexOf(productosTestBdProvArray, x);
                    int CantidadAddTest = cantidadesTestBdProvvArray[xIndex];
                    int precioAddTest = preciosTestBdProvArray[xIndex];
                    var NewProducto = new Producto
                    {
                        Nombre = x,
                        CantidadEnB = CantidadAddTest,
                        CantidadMin = 0,
                        Precio = precioAddTest
                    };

                    context.Productos.Add(NewProducto);
                    context.SaveChanges();
                }
                Console.WriteLine("Se agrego los primeros productos");

            }
        }
    }
}
