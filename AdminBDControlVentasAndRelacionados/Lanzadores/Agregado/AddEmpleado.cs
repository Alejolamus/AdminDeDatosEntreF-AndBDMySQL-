using BaseDeDatosMySql.Context;
using BaseDeDatosMySql.Models;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Agregado
{
    public class AddEmpleado
    {
        public static void Ejecutar()
        {
            //Dado que se espera otro proyecto que permita asignasiion de cargos y permisos por ahora se dean 4 provicionales para el funcinamiento
            string[] CargosProv = { "Admin", "Coordinador", "Vendedor", "Repartidor" };
            //Recoje datos bascicos
            Console.Write("Nombre de empleado: ");
            string nombreEmpleado = Console.ReadLine();

            Console.Write("Tipo de documento:");
            string TipoDeDocumento = Console.ReadLine();

            Console.Write("Numero de documento");
            int NumeroDocumentoEmp = int.Parse(Console.ReadLine());
            foreach (string h in CargosProv)
            {
                Console.WriteLine(h);
            }
            Console.Write("Cargo (Seleccione uno de la lista anterior): ");
            string CargoEmpleado = Console.ReadLine();

            if (CargosProv.Contains(CargoEmpleado))
            {
                if (CargoEmpleado == "Admin")
                {
                    using (var context = new RegistrosVentContext())
                    {
                        string administradoR = context.Users
                            .Where(r => r.Cargo == "Admin")
                            .Select(r => r.Nombre)
                            .FirstOrDefault();

                        if (administradoR != null)
                        {
                            Console.WriteLine($"Ya hay un administrador: {administradoR}");
                            Console.Write("Seleccione otro cargo: ");
                            CargoEmpleado = Console.ReadLine();
                        }
                    }
                }
            }
            Console.Write("Contraseña: ");
            string Pass = Console.ReadLine();
            // Agrega registo de Users con los datos recolectrados
            using (var context = new RegistrosVentContext())
            {
                var Usuario = new User
                {
                    Nombre = nombreEmpleado,
                    Cargo = CargoEmpleado,
                    TipoDeDoc = TipoDeDocumento,
                    NumeroDeDocumento = NumeroDocumentoEmp,
                    Contraseña = Pass,
                    EstadoVacacional = false
                };

                context.Users.Add(Usuario);
                context.SaveChanges();

                Console.WriteLine("Se agregó nuevo empleado.");
            }
        }
    }
}