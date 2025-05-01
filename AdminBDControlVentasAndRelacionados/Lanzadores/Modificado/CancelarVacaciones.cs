using BaseDeDatosMySql.Context;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Modificado
{
    public class CancelarVacaciones
    {
        public static void Ejecutar()
        {
            //Datos empleado
            Console.WriteLine("Nombre de Empleado");
            string NombreEmpleado = Console.ReadLine();
            Console.WriteLine("Tipo de documento");
            string TD = Console.ReadLine();
            Console.WriteLine("Numero de documento");
            int DocEmp = int.Parse(Console.ReadLine());
            using (var context = new RegistrosVentContext())
            {
                //Cambia valor de vaciones a false
                var usermod = context.Users
                    .Where(w => w.Nombre == NombreEmpleado && w.TipoDeDoc == TD && w.NumeroDeDocumento == DocEmp)
                    .FirstOrDefault();
                if (usermod == null)
                {
                    Console.WriteLine("Empleado no encontrado");
                }
                else
                {
                    usermod.EstadoVacacional = false;
                    context.SaveChanges();
                }
            }

        }
    }
}