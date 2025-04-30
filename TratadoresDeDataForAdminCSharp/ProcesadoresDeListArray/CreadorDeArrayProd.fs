namespace CreadorDeArrayProd

module extractro =
    open Models
    open DataTypes.DatosVentaDiariaUniProd

    let CrearArregloProd (listCsharp: List<List<RegistroVenta>>): ResizeArray<ResizeArray<RegistroVentaDia>> =
        let ArraysAllProd = ResizeArray<ResizeArray<RegistroVentaDia>>()
        for i in listCsharp do 
            let ArrayProducto = ResizeArray<RegistroVentaDia>()
            for h in i do
                let registroforadd = {
                    Fecha = h.Fecha
                    Cantidad = h.Cantidad
                    Nombre = h.Nombre
                }
                ArrayProducto.Add(registroforadd)
            ArraysAllProd.Add(ArrayProducto) 
        ArraysAllProd