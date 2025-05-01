


namespace TratadoresDeDataForAdminCSharp

module DataBDtest =
    open DatosParaTestBD.CreadorDeListasTestBD
    //Listas de usuarios provisionales
    let EmpleadosCuatroCargos = nombresempleadosbdtest
    let CargosEmpleadosOrdenados = Cargosbftest 
    let TipoDeDocEmpleadosOrdenados = TiposDeDocBDtest
    let DocEmpleadosOrdenados = documetosbdtest
    let ContraseñasEmpleadoOrdenados = Contraseñastest
    //Listas de productos
    let ProductosAddTestBase = productosvendidos
    let CantidadesEnBodegaTestBase = cantidadbodecabdtest
    let PreciosTestBase = preciosbdtest
    //listas para ventas y relacionados
        // registros de todas las ventas por producto si no llevaron queda como 0
    let VentasSombrerosBdTst = vendiasombrero
    let VentasPañuelosBdTst = vendiaspañuelo 
    let VentasCamisasBdTst = vendiacamisa
    let VentasPantalonesBdTst = vendiapantalon
        //fechas venta entreta
    let FechasVentasBdTst = ListadoFechasventas 
    let FechaEntregaBdTst = ListadoFechasEntregas 
        //recaudos y totales
    let RecaudosBdTst = recaudosbstest 
    let TotalCompraBdTst = Totalescomprasbstest 
    let TotalSaldosComprasBdTst = Totalescomprasbstestsaldos 
        //nombres ,direcciones, codigo, tel y correos
    let CorreosBdTst = correosbstest 
    let TelsBdTst = Telefonosbstest 
    let CodigosTranBdTst = codigostranasionesbstest 
    let NombresClientesBdTst = nombresclientesbdtest 
    let DireccionesBdTst = direcionesventasbdtets 

module DataTratadaForCSharp =
    open ConsulasInBdMySql.ConsultasForfSharp
    open RegresionesAllProductosBD.CalculadorDeRegresiones
    open DataTypes.EstimadoresDeRegresionL
    // Ejecutar el método estático
    ArreglosVentasAllProduc.Ejecutar()
    
    // Obtener la lista
    let lista = ArreglosVentasAllProduc.ListaGlobalVentasProductos
    let listaConvertida = List.ofSeq lista |> List.map List.ofSeq
    let ListasEstimadoresP = CrearRegresiones listaConvertida
    let Listproductos = ResizeArray<string>()
    let Listecuaciones = ResizeArray<string>()
    let Listpendientes = ResizeArray<float>()
    let ListejeY= ResizeArray<float>()
    let ListMAE = ResizeArray<float>()
    let ListRMSE = ResizeArray<float>()
    let ListCoeDeterminacion = ResizeArray<float>()
    let ListCantidadDays =ResizeArray<int>()
    for i in ListasEstimadoresP do 
        let prod = i.Producto
        let ecuacion = i.Ecuacion
        let pendiente = i.Pendiente
        let ejey = i.EjeY
        let mae = i.MAE
        let rmse = i.RMSE
        let coe = i.CoeficienteDeDeterminacion
        let NumDay = i.Ndias
        Listproductos.Add(prod)
        Listecuaciones.Add(ecuacion) 
        Listpendientes.Add(pendiente)
        ListejeY.Add(ejey)
        ListMAE.Add(mae)
        ListRMSE.Add(rmse)
        ListCoeDeterminacion.Add(coe)
        ListCantidadDays.Add(NumDay)
