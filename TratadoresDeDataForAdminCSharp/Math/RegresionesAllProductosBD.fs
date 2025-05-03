namespace RegresionesAllProductosBD

module CalculadorDeRegresiones =

    open Models
    open System
    open DataTypes.EstimadoresDeRegresionL
    open SumadoresDeVentasArray.SumadorVentasMismoDia
    open CreadorDeArrayProd.extractro
    open RegrecionLineaProdUnico.EstudioRegresion
    open EstimadoresDePredicionPorRegresionL.EstudioMAERMSER2
    open DataTypes.DatosParaEstimadorDeRegresion
    open DataTypes.DiferenciasPred
    open DataTypes.VentasSemanales
    open DataTypes.prediccion
 
    // crear array de array de RegistroVentaDia datapype f#
    let CrearRegresiones (datosprod: List<List<RegistroVenta>>) :ResizeArray<EstimadoresReg>*ResizeArray<Diferenciales>*ResizeArray<prediciones> =

        let listaTratada = CrearArregloProd datosprod // arregla la lista a un resizearray<resizearray<registroventadia>>
        let DifLastWeek = ResizeArray<Diferenciales>()
        let PedicNextWeek = ResizeArray<prediciones>()
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
            ListasDeEstimadores.Add(resultado)// para retornar
            //valores predichos 7 dias siguiente y anteriores
            let ultimaFecha = 
                arrayEstimadors
                |> Seq.maxBy (fun x -> x.Fecha)
                |> fun x -> x.Fecha
                //
            let ValuepredicNday (numDayE: int) : float =
                regresionProd.Pendiente * (float numDayE) + regresionProd.EjeY
            let predicPrevList = ResizeArray<float>()
            let PredicNextList = ResizeArray<float>()
            let ListDaysnexts = ResizeArray<DateTime>()
            let ListDaysPrev = ResizeArray<DateTime>()
            let NextPredis = ResizeArray<prediciones>() // ventas predecidas para la semana siguiente
            let PrevPredis = ResizeArray<prediciones>() // ventas predecidas para la semana ant
            for sumDays in 1..7 do
                let valuepreducnext = ValuepredicNday (regresionProd.NDias+sumDays)
                let diapredic = ultimaFecha.AddDays((float sumDays))
                PredicNextList.Add(valuepreducnext)
                ListDaysnexts.Add(diapredic)
                let datapredic ={
                    Dia = diapredic
                    Cantidades = valuepreducnext
                }
                NextPredis.Add(datapredic)
            for resDays in 1..7 do
                let valuepreducant = ValuepredicNday (regresionProd.NDias+(7 - resDays))
                let DiapreV = ultimaFecha.AddDays((float (7-resDays)))
                predicPrevList.Add(valuepreducant)
                ListDaysPrev.Add(DiapreV)
                let datospredic = {
                    Dia = DiapreV
                    Cantidades = valuepreducant
                }
                PrevPredis.Add(datospredic)
                //en list tratada sum extraigo registros de ventas por dia en predicPrevList, asignar datatype para siguientes
            let Cantidaesanteriores = ResizeArray<ventassemana>() // ventas reales de la semana pasada
            for ii in ListDaysPrev do 
                let CantodadFechaOpt =
                    ListaTratadaSum
                    |> Seq.tryFind (fun xx -> xx.Fecha = ii)
                    |> Option.map (fun xx -> xx.Cantidad)
                
                let cantidadFinal = 
                    match CantodadFechaOpt with
                    | Some c -> c
                    | None -> 0
            
                let ventadia = {
                    Dia = ii
                    Cantidad = cantidadFinal
                }
                
                Cantidaesanteriores.Add(ventadia)
            //Ordeno las linas de cantidades de menor a mayor
            let cantantorder =
                Cantidaesanteriores
                |> Seq.sortBy (fun x -> x.Dia)
                |> ResizeArray
            let pedicantorder =
                PrevPredis
                |> Seq.sortBy (fun x -> x.Dia)
                |> ResizeArray
            let pedicactorder = //valor a retornar
                NextPredis
                |> Seq.sortBy (fun x -> x.Dia)
                |> ResizeArray
            //calculo de deferenciales anteriores 
            let DiferencialesAnteriores = ResizeArray<Diferenciales>() // valor a retornar
            for uuu in 0..6 do 
                let diaregistrar = cantantorder.[uuu].Dia
                let difregistar = abs ((float cantantorder.[uuu].Cantidad) - (pedicantorder.[uuu].Cantidades))
                let regDif = {
                    Dia = diaregistrar
                    DiferenciaProdReal = difregistar
                }
                DiferencialesAnteriores.Add(regDif)
            //aca retorno DiferencialesAnteriores, pedicactorder y ListasDeEstimadores
            DifLastWeek = DiferencialesAnteriores
            PedicNextWeek = pedicactorder
        
        (ListasDeEstimadores, DifLastWeek, PedicNextWeek)

        //agregarproducto en predicionesNextweer con nuevo atributo en prediccion (producto)