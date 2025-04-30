module DataTypes.DatosVentaDiariaUniProd
open System

type RegistroVentaDia = {
    Fecha: DateTime
    Cantidad: int
    Nombre: string
}