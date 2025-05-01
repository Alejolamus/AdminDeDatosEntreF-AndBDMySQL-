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

        }
    }
}