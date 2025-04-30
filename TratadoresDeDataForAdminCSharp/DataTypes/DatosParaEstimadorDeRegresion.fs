module DataTypes.DatosParaEstimadorDeRegresion
open System

type RegistroMXByVentas = {
    Producto: string
    Ecuacion: string
    Pendiente: float
    EjeY: float
    Fecha: DateTime
    Cantidad: int
}