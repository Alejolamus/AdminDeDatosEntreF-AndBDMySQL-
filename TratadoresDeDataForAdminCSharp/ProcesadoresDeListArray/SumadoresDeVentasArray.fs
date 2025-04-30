namespace SumadoresDeVentasArray

module SumadorVentasMismoDia =
    open System
    open DataTypes.DatosVentaDiariaUniProd

    let SumVentDay (ventasProducto: ResizeArray<RegistroVentaDia>): ResizeArray<RegistroVentaDia> =
        let RegistrosSumados = ResizeArray<RegistroVentaDia>()
        let FechasNoRep = ResizeArray<DateTime>()

        for i in ventasProducto do 
            if not (FechasNoRep.Contains(i.Fecha)) then
                FechasNoRep.Add(i.Fecha)

        for fecha in FechasNoRep do
            let ventasMismoDia =
                ventasProducto
                |> Seq.filter (fun r -> r.Fecha = fecha)

            let sumaCantidad =
                ventasMismoDia
                |> Seq.sumBy (fun r -> r.Cantidad)

            let nuevoRegistro = {
                Fecha = fecha
                Cantidad = sumaCantidad
                Nombre = ventasProducto.[0].Nombre
            }

            RegistrosSumados.Add(nuevoRegistro)

        RegistrosSumados