using BaseDeDatosMySql.Context;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Eliminado
{
    public class EliminarEmpleado
    {
        public static void Ejecutar()
        {
            using (var context = new RegistrosVentContext())
            {
                //Lista los empleados
                var Empleados = context.Users.ToArray();

                if (Empleados.Length == 0)
                {
                    Console.WriteLine("No hay Empleados registrados.");
                    return;
                }

                Console.WriteLine("Lista de empleados:");
                foreach (var Empleado in Empleados)
                {
                    Console.WriteLine($"- {Empleado.Nombre} con cargo {Empleado.Cargo}");
                }
                //Toma datos del empleado
                Console.Write("Ingrese el nombre del Empleado: ");
                string DelEmpleado = Console.ReadLine();
                Console.Write("Tipo de documento");
                string TD = Console.ReadLine();
                Console.Write("Numero de documento");
                int NumDoc = int.Parse(Console.ReadLine());
                // Buscar y eliminar el empreado por nombre y documento
                var NoEmpleado = context.Users.FirstOrDefault(e => e.Nombre == DelEmpleado && e.TipoDeDoc == TD && e.NumeroDeDocumento == NumDoc);

                if (NoEmpleado != null)
                {
                    context.Users.Remove(NoEmpleado);
                    context.SaveChanges();
                    Console.WriteLine($"El Empleado '{DelEmpleado}' ha sido eliminado correctamente de la BD.");
                }
                else
                {
                    Console.WriteLine($"No se encontró un empleado con los datos suministrados.");
                }
            }
        }
    }
}
// ojo que no elimite admin. crear clase de cambio de admin