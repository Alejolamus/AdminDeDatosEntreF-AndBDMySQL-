namespace EstimadoresDePredicionPorRegresionL
module EstudioMAERMSER2 =

    open DataTypes.DatosParaEstimadorDeRegresion
    open DataTypes.EstimadoresDeRegresionL
    
    let calcularEstimadoresR (datosRegProd: ResizeArray<RegistroMXByVentas>) : EstimadoresReg =
        // Datos básicos para estudio
        let pendienteReg = datosRegProd.[0].Pendiente
        let ejeYReg = datosRegProd.[0].EjeY
        let productoEstudio = datosRegProd.[0].Producto
        let ecuacionEstudio = datosRegProd.[0].Ecuacion
        let listVentas = ResizeArray<int>()
        let lenDatosReg = datosRegProd.Count
    
        for i in 0..(lenDatosReg - 1) do 
            let ventas = datosRegProd.[i].Cantidad
            listVentas.Add(ventas)
        let listPedic = ResizeArray<float>()
        for t in 1..lenDatosReg do 
            let ValorPredicho = pendienteReg*(float t)+ejeYReg
            listPedic.Add(ValorPredicho)
            
        //Calculo MAE
        let ListDifRealPred = ResizeArray<float>()
        for u in 0..(lenDatosReg - 1) do 
            let ValorReal = listVentas.[u]
            let ValorPrediccion = listPedic.[u]
            let DifComparativo = abs ((float ValorReal)-ValorPrediccion)
            ListDifRealPred.Add(DifComparativo)
        let SumListDifRealPred = Seq.fold (fun acc dif -> acc+dif) 0.0 ListDifRealPred
        let MAEReg = SumListDifRealPred / (float lenDatosReg)
        //Calculo RMSE
        let CuadListDifRealPred = Seq.map (fun x -> x*x) ListDifRealPred
        let SumCuadListDifRealPred = Seq.fold (fun acc dif ->  acc+dif) 0.0 CuadListDifRealPred
        let PromCuadradosDif = SumCuadListDifRealPred / (float lenDatosReg)
        let RMSEReg = sqrt PromCuadradosDif
        //calculo Coeficiente de determinacion
        let SumVentas = Seq.fold (fun acc r -> acc + r) 0 listVentas
        let promedioVentas = (float SumVentas) / (float lenDatosReg)
        let  ListCuadDifMedReal = Seq.map (fun g -> ((float g)-promedioVentas)**2.0) listVentas
        let SSTReg = Seq.fold (fun acc e -> acc + e) 0.0 ListCuadDifMedReal
        let CocienteSSE_SST = SumCuadListDifRealPred / SSTReg
        let CocienteDeterminacionReg = 1.0 - CocienteSSE_SST
        //llenamos un tipo Estimadores de regresion
        let resultado = {
            Producto = productoEstudio
            Ecuacion = ecuacionEstudio
            Pendiente = pendienteReg
            EjeY = ejeYReg  
            MAE = MAEReg
            RMSE = RMSEReg
            CoeficienteDeDeterminacion = CocienteDeterminacionReg
        }
        resultado