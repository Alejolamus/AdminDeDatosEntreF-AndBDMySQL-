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
    open System
    // Ejecutar método que llena lista global de ventas por producto
    ArreglosVentasAllProduc.Ejecutar()
    
    // Convertimos la lista a un formato usable
    let lista = ArreglosVentasAllProduc.ListaGlobalVentasProductos
    let listaConvertida = List.ofSeq lista |> List.map List.ofSeq
    // Dado que CrearRegresiones retorna (a,b,c) List defino fun para extraer la lista decesada
    let fst3 (a, _, _) = a
    let snd3 (_, b, _) = b
    let trd3 (_, _, c) = c
    // Calculamos estimadores para todos los productos
    let DataForTablesAnalytics = CrearRegresiones listaConvertida // ojoaca ya retorna 3 listas rev code
    let ListasEstimadoresP = fst3 DataForTablesAnalytics
    // Creamos listas públicas accesibles desde C#
    let public Listproductos = ResizeArray<string>()
    let public Listecuaciones = ResizeArray<string>()
    let public Listpendientes = ResizeArray<float>()
    let public ListejeY = ResizeArray<float>()
    let public ListMAE = ResizeArray<float>()
    let public ListRMSE = ResizeArray<float>()
    let public ListCoeDeterminacion = ResizeArray<float>()
    let public ListCantidadDays = ResizeArray<int>()
    
    // Rellenamos listas de estimadores
    for i in ListasEstimadoresP do  // A element
        Listproductos.Add(i.Producto)
        Listecuaciones.Add(i.Ecuacion)
        Listpendientes.Add(i.Pendiente)
        ListejeY.Add(i.EjeY)
        ListMAE.Add(i.MAE)
        ListRMSE.Add(i.RMSE)
        ListCoeDeterminacion.Add(i.CoeficienteDeDeterminacion)
        ListCantidadDays.Add(i.Ndias)
    //  Para Diferenciales con semana pasada use b element
    let DifInLastWeek = snd3 DataForTablesAnalytics
    let DiferencialesCalculados = ResizeArray<float>()
    let DiaPredichoS = ResizeArray<DateTime>()
    for h in DifInLastWeek do
        DiferencialesCalculados.Add(h.DiferenciaProdReal)
        DiaPredichoS.Add(h.Dia)
    // para pedictores (new tabala, use data para pensar la nuw tabla dondese se copnsta con DateTime.Now.AddDays+7) c element
    let PredicForNextWeek = trd3 DataForTablesAnalytics
    let PredicCalculados = ResizeArray<float>()
    let DiasPredichoS = ResizeArray<DateTime>()
    for j in PredicForNextWeek do
        PredicCalculados.Add(j.Cantidades)
        DiasPredichoS.Add(j.Dia)
    
    
        