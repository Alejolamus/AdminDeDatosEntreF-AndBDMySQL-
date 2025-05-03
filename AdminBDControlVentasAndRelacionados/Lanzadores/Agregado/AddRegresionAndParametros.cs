using BaseDeDatosMySql.Context;
using BaseDeDatosMySql.Models;
using System;
using System.Linq;
using TratadoresDeDataForAdminCSharp;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Agregado
{
    public class AddRegresionAndParametros
    {
        public static void Ejecutar()
        {
            var ArregloProducto = DataTratadaForCSharp.Listproductos;
            var ArregloEcu = DataTratadaForCSharp.Listecuaciones;
            var ArregloPend = DataTratadaForCSharp.Listpendientes;
            var ArregloY = DataTratadaForCSharp.ListejeY;
            var ArregloMAE = DataTratadaForCSharp.ListMAE;
            var ArregloRMSE = DataTratadaForCSharp.ListRMSE;
            var ArregloCoeDet = DataTratadaForCSharp.ListCoeDeterminacion;
            var ArregloDays = DataTratadaForCSharp.ListCantidadDays;
            int countgeneral = ArregloMAE.Count;
            for (int i = 0; i < countgeneral; i++)
            {
                using (var context = new RegistrosVentContext())
                {
                    var idprod = context.Productos
                    .Where(p => p.Nombre == ArregloProducto[i])
                    .Select(p => p.Id)
                    .FirstOrDefault();
                    var ProdEstudiado = new RegresionLineal
                    {
                        IdProducto =idprod,
                        Ecuacion = ArregloEcu[i],
                        Pendiente = (float)ArregloPend[i],
                        Ejey = (float)ArregloY[i],
                        Fecha = DateTime.Now,
                        CantidadDay = ArregloDays[i]
                    };
                    // crea los registros provicionales de comparativos (Se cambian en otra clase que se encarga de esto segun el caso)
                    //Dias siguientes se ejecuta 7 dias despues, dias anteriores el mismo dia que se lanza este proceso
                    context.RegresionesLineales.Add(ProdEstudiado);
                    context.SaveChanges();
                    int idactualreg = ProdEstudiado.Id;
                    var DataNextsDays = new DatosComparativosDiasSiguientes
                    {
                        IdProducto = idprod,
                        IdRegresionAct = idactualreg,
                        CoeficienteDet = (float) ArregloCoeDet[i],
                        DifLunesAct = 0,
                        DifMartesAct = 0,
                        DifMiercolesAct = 0,
                        DifJuevesAct = 0,
                        DifViernesAct = 0,
                        DifSabadoAct = 0,
                        DifDomigoAct = 0
                    };
                    context.DatosComparativosDiasSiguientes.Add(DataNextsDays);
                    context.SaveChanges();
                    int? yaExisteAnterior = context.RegresionesLineales
                        .Where(r => r.IdProducto == idprod && r.Fecha < DateTime.Now )
                        .Select(r => r.Id)
                        .FirstOrDefault();
                    if (yaExisteAnterior == null)
                    {
                        var DataPrevDays = new DatosComparativosDiasAnteriores
                        {
                            IdProducto = idprod,
                            IdRegresionAct = idactualreg,
                            IdRegresionAnt = null,
                            CoeficienteDet = (float)ArregloCoeDet[i],
                            DifLunesAnt = 0,
                            DifMartesAnt = 0,
                            DifMiercolesAnt = 0,
                            DifJuevesAnt = 0,
                            DifViernesAnt = 0,
                            DifSabadoAnt = 0,
                            DifDomigoAnt = 0
                        };
                        context.DatosComparativosDiasAnteriores.Add(DataPrevDays);
                        context.SaveChanges();
                    }
                    else
                    {
                        if (yaExisteAnterior == null)
                        {
                            var DataPrevDays = new DatosComparativosDiasAnteriores
                            {
                                IdProducto = idprod,
                                IdRegresionAct = idactualreg,
                                IdRegresionAnt = yaExisteAnterior,
                                CoeficienteDet = (float)ArregloCoeDet[i],
                                DifLunesAnt = 0,
                                DifMartesAnt = 0,
                                DifMiercolesAnt = 0,
                                DifJuevesAnt = 0,
                                DifViernesAnt = 0,
                                DifSabadoAnt = 0,
                                DifDomigoAnt = 0
                            };
                            context.DatosComparativosDiasAnteriores.Add(DataPrevDays);
                            context.SaveChanges();
                            // llamado metodo a crear (PreidDefFaltante) trae data para atosComparativosDiasSiguientes 
                            //con consulta fecha = datetime.now -7 days, if null no ejecuta metodo fecha x

                            //con if Si existe regrecion anterior se ejecuta metodo de actalizar datos en 
                            //DatosComparativosDiasSiguientes

                            //revisar metodos que se ejecuten con dos parametos (Fecha x y idregresion)

                            // llamos AddPredicSemana.ejecurtar(Fecha x y producto en clico)

                        }
                    }
                }
            }

        }
    }
}