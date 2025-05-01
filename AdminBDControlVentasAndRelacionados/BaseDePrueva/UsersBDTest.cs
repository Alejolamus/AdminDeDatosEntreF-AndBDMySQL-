using BaseDeDatosMySql.Context;
using BaseDeDatosMySql.Models;
using System;
using System.Linq;
using TratadoresDeDataForAdminCSharp;

namespace AdminBDControlVentasAndRelacionados.BaseDePrueva
{
    public class UsersBDTest
    {
        public static void Ejecutar()
        {
            //llamo laslistas desde f#
            var usersTestBdProv = DataBDtest.EmpleadosCuatroCargos;
            var tipoDocTestBdProv = DataBDtest.TipoDeDocEmpleadosOrdenados;
            var documentsTestBdProv = DataBDtest.DocEmpleadosOrdenados;
            var cargosTestBdProv = DataBDtest.CargosEmpleadosOrdenados;
            var contraseñasTestBdProv = DataBDtest.ContraseñasEmpleadoOrdenados;
            //Las paso a array
            string[] usersTestBdProvArray = usersTestBdProv.ToArray();
            string[] tipoDocTestBdProvArray = tipoDocTestBdProv.ToArray();
            int[] documentsTestBdProvArray = documentsTestBdProv.ToArray();
            string[] cargosTestBdProvArray = cargosTestBdProv.ToArray();
            string[] contraseñasTestBdProvArray = contraseñasTestBdProv.ToArray();
            //cilo para agregar usuarios
            using (var context = new RegistrosVentContext())
            {
                foreach (var x in usersTestBdProvArray)
                {
                    int xIndex = Array.IndexOf(usersTestBdProvArray, x);
                    string CargoAddTest = cargosTestBdProvArray[xIndex];
                    int DocuAddTest = documentsTestBdProvArray[xIndex];
                    string TiDocAddTest = tipoDocTestBdProvArray[xIndex];
                    string PaddAddTest = contraseñasTestBdProvArray[xIndex];
                    var Usernew = new User
                    {
                        Nombre = x,
                        Cargo = CargoAddTest,
                        TipoDeDoc = TiDocAddTest,
                        NumeroDeDocumento = DocuAddTest,
                        Contraseña = PaddAddTest,
                        EstadoVacacional = false
                    };

                    context.Users.Add(Usernew);
                    context.SaveChanges();

                }
                Console.WriteLine("Se agrego los primeros usuarios recuerde:");
                Console.WriteLine("Admin: Jonh Russell Pass: as578dwasd52 ");
            }
        }
    }
}