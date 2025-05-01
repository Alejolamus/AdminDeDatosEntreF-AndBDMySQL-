namespace RegresionesAllProductosBD

module CalculadorDeRegresiones =

    open Models
    open DataTypes.EstimadoresDeRegresionL
    open SumadoresDeVentasArray.SumadorVentasMismoDia
    open CreadorDeArrayProd.extractro
    open RegrecionLineaProdUnico.EstudioRegresion
    open EstimadoresDePredicionPorRegresionL.EstudioMAERMSER2
    open DataTypes.DatosParaEstimadorDeRegresion

 
    // crear array de array de RegistroVentaDia datapype f#
    let CrearRegresiones (datosprod: List<List<RegistroVenta>>) :ResizeArray<EstimadoresReg> =
       
        let listaTratada = CrearArregloProd datosprod // arregla la lista a un resizearray<resizearray<registroventadia>>
        let ListasDeEstimadores = ResizeArray<EstimadoresReg>()
        for i in listaTratada do   
            let ListaTratadaSum = SumVentDay i // suma las cantidasdes dejando solo un registro por fecha y su total
            let regresionProd = calcularRegresion ListaTratadaSum // arroja un RegistroDeRegresion
            let arrayEstimadors = ResizeArray<RegistroMXByVentas>() // se crea array para estimadores
            for k in i do //  se llama array de estimadores
                let objetoparestimar = {
                    Producto = k.Nombre 
                    Ecuacion = regresionProd.Ecuacion   
                    Pendiente = regresionProd.Pendiente
                    EjeY = regresionProd.EjeY
                    Fecha = k.Fecha
                    Cantidad =k.Cantidad
                    DiasUsed = regresionProd.NDias
                }
                arrayEstimadors.Add(objetoparestimar)
            let estimadoresProd = calcularEstimadoresR arrayEstimadors// arroja un EstimadoresReg
            let resultado = {
                Producto = i.[0].Nombre
                Ecuacion = regresionProd.Ecuacion
                Pendiente = regresionProd.Pendiente
                EjeY = regresionProd.EjeY
                MAE = estimadoresProd.MAE
                RMSE = estimadoresProd.RMSE
                CoeficienteDeDeterminacion = estimadoresProd.CoeficienteDeDeterminacion
                Ndias = regresionProd.NDias
            }
            ListasDeEstimadores.Add(resultado)
        ListasDeEstimadores