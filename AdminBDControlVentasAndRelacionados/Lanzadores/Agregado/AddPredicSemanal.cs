using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TratadoresDeDataForAdminCSharp;
using BaseDeDatosMySql.Context;
using BaseDeDatosMySql.Models;

namespace AdminBDControlVentasAndRelacionados.Lanzadores.Agregado
{
     public class AddPredicSemanal
    {
        public static void Ejecutar()
        {
            //llamamos las predicciones de F#
            // (espacio para productos) de paso optimizar f#

            var DiasPredichos = DataTratadaForCSharp.DiasPredichoS;
            var ValoresPredichos = DataTratadaForCSharp.PredicCalculados;
            //consulta por fechas producto


                // if consutla null no agrega, != agrega primero



            //Eliminar consulta de la tabla para no tener dos veces el mismo producto y ahora memorya en BD

        }
        
    }
}
