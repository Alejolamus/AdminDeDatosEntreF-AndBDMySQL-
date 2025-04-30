namespace ProcesadorDeDatosParaBDVentas

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
