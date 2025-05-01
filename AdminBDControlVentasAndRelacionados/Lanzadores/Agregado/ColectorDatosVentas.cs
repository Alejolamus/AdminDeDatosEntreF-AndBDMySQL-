using BaseDeDatosMySql.Context;
using Models;
using System;
using System.Linq;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Agregado
{
    public class ColectorDatosVentas
    {
        public static DatosVenta Ejecutar()
        {
            //Datos iniciales
            bool valordeentrega;
            Console.Write("Nombre del cliente: ");
            string nombrecliente = Console.ReadLine();

            Console.Write("Recaudo: ");
            int recaudo = int.Parse(Console.ReadLine());

            Console.Write("Código de transacción: ");
            int Codigotransaccion = int.Parse(Console.ReadLine());

            // Opción para agregar la fecha manualmente o usar la fecha actual
            DateTime FechaventaAdd;
            bool esFormatoValido = false;

            Console.Write("¿Quieres ingresar la fecha manualmente? (S/N): ");
            string respuesta = Console.ReadLine();

            if (respuesta.ToUpper() == "S")
            {
                do
                {
                    Console.Write("Fecha: (dd/MM/yyyy HH:mm:ss): ");
                    string fechaventaresg = Console.ReadLine();

                    esFormatoValido = DateTime.TryParseExact(
                        fechaventaresg,
                        "dd/MM/yyyy HH:mm:ss",
                        null,
                        System.Globalization.DateTimeStyles.None,
                        out FechaventaAdd
                    );
                } while (!esFormatoValido);
            }
            else
            {
                FechaventaAdd = DateTime.Now;
            }

            Console.WriteLine($"Fecha de venta: {FechaventaAdd}");

            // Variables que debes declarar antes del using
            int cantidadadd;
            string[] ProductosAdd = null;
            int[] NumeroProductosUni = null;
            string correo = "", telefono = "", direccion = "";
            DateTime fechadeentrega;

            // Acceso a DB y productos
            using (var context = new RegistrosVentContext())
            {
                var productos = context.Productos.ToArray();
                if (productos.Length == 0)
                {
                    Console.WriteLine("No hay productos registrados.");
                    return null;
                }

                Console.WriteLine("Lista de productos disponibles:");
                foreach (var producto in productos)
                {
                    Console.WriteLine($"{producto.Nombre}");
                }

                do
                {
                    Console.Write("Cantidad de tipos de productos diferentes: ");
                    string Nprodu = Console.ReadLine();
                    bool esIntValido = int.TryParse(Nprodu, out cantidadadd);

                    if (!esIntValido || cantidadadd <= 0)
                    {
                        Console.WriteLine("Ingresa un número de productos diferentes.");
                    }
                } while (cantidadadd <= 0);

                ProductosAdd = new string[cantidadadd];
                NumeroProductosUni = new int[cantidadadd];

                for (int i = 0; i < cantidadadd; i++)
                {
                    Console.Write($"Nombre del producto {i + 1}: ");
                    ProductosAdd[i] = Console.ReadLine();

                    int NuUnidadesVend;
                    bool esNVenValido;
                    do
                    {
                        Console.WriteLine("Número de productos:");
                        string NVen = Console.ReadLine();
                        esNVenValido = int.TryParse(NVen, out NuUnidadesVend);

                        if (!esNVenValido || NuUnidadesVend <= 0)
                        {
                            Console.WriteLine("Ingresa un número de unidades vendidas.");
                        }
                    } while (!esNVenValido || NuUnidadesVend <= 0);

                    NumeroProductosUni[i] = NuUnidadesVend;
                }

                // Datos complementarios
                Console.Write("Correo: ");
                correo = Console.ReadLine();

                Console.Write("Teléfono: ");
                telefono = Console.ReadLine();

                Console.Write("Dirección: ");
                direccion = Console.ReadLine();

                Console.Write("Ingrese la fecha de entrega (formato: dd/MM/yyyy): ");
                string input = Console.ReadLine();
                while (!DateTime.TryParse(input, out fechadeentrega))
                {
                    Console.Write("Formato incorrecto. Intente nuevamente (dd/MM/yyyy): ");
                    input = Console.ReadLine();
                }
            }
            Console.Write("Se realizo entrega deproductos al registro (S/N)");
            string Entregafisica = Console.ReadLine();
            if (respuesta.ToUpper() == "S")
            {
                valordeentrega = true;
            }
            else
            {
                valordeentrega = false;
            }

            // Crear y devolver objeto DatosVenta
            var datosVenta = new DatosVenta
            {
                NombreCliente = nombrecliente,
                Recaudo = recaudo,
                CodigoTransaccion = Codigotransaccion,
                FechaVenta = FechaventaAdd,
                ProductosAdd = ProductosAdd,
                UnidadesVendidas = NumeroProductosUni,
                CorreoVen = correo,
                Telefono = telefono,
                DireccionDomi = direccion,
                FechaEntregaVen = fechadeentrega,
                EngtregaHoNH = valordeentrega
            };

            return datosVenta;
        }
    }
}
