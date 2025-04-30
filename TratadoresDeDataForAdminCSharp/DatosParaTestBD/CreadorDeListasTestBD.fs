module DatosParaTestBD.CreadorDeListasTestBD
open System
let rnd = System.Random()
// Productos
let productosvendidos = ["Sombreros";"Pañuelos";"Pantalones";"Camisas"]
let cantidadbodecabdtest = [123456;123546;78541;36541]
let preciosbdtest =[30000;12000;27000;20000]
//Datos para Users
let nombresempleadosbdtest = ["Jonh Russell,";"Sara Quevedo";"Alejandro Garcia";"Julian Rodriguez";"Karol Roncancio"]
let TiposDeDocBDtest = ["CC";"CC";"CC";"CC";"CC"]
let documetosbdtest = [1234567;7896542;7458922;1231231]
let Cargosbftest = ["Admin";"Coordinador";"Vendedor";"Vendedor";"Repartidor"]
let Contraseñastest = ["as578dwasd52";"asd1w8ghydf";"85dyht0a34";"asd4415asdwtc";"ytgckk82512"]
//datos ventas 700 dias
//fechasbdtest contienelas 700 fechas en un array [day1,day2,...]
let hoy = System.DateTime.Today
let fechasbdtest = ResizeArray<DateTime>()
for tim in 0..699 do
    let newdia =  hoy.AddDays(float -tim)
    fechasbdtest.Add(newdia)
    // 700 dias registo de ventas
    //ventasdiariasbdtest contiene los 700 registros como ventas en un array [12,35,...]
let ventasdiariasbdtest = ResizeArray<int>()
for i in 0..699 do
    let ventasrandom = rnd.Next(30, 80)
    ventasdiariasbdtest.Add(ventasrandom)
let sumaventasdiariasbdtest = ventasdiariasbdtest |> Seq.sum
let antsumaventasdiariasbdtest = sumaventasdiariasbdtest-1
    //Ventas por producto cada una en un arreglo con 700 registos [a_1,a_2,a_3,...,a_700]
let vendiasombrero = ResizeArray<int>()
let vendiaspañuelo = ResizeArray<int>()
let vendiacamisa = ResizeArray<int>()
let vendiapantalon = ResizeArray<int>()
for h in 0..antsumaventasdiariasbdtest do
    
        let ventarandomsombreo = rnd.Next(0, 21)
        let ventarandompañuelo = rnd.Next(0, 21)
        let ventarandomcamisa = rnd.Next(0, 21)
        let ventarandompantalon = rnd.Next(0, 21)
        vendiasombrero.Add(ventarandomsombreo)
        vendiaspañuelo.Add(ventarandompañuelo)
        vendiacamisa.Add(ventarandomcamisa)
        vendiapantalon.Add(ventarandompantalon)
//generadoreslistas de ventas nombre correo tel. se necesitan 700*(suma de las ventasdiarias
        //Declaro arreglos
let correosbstest = ResizeArray<string>()
let Telefonosbstest = ResizeArray<int>()
let codigostranasionesbstest = ResizeArray<int>()
let nombresclientesbdtest = ResizeArray<string>()
    //Nombres y apellidos base y un generador de duplas nombres apellidos
let nombres = [
    "Juan"; "Pedro"; "José"; "Luis"; "Carlos"; "Antonio"; "Miguel"; "Francisco"; "David"; "Jorge"; 
    "Manuel"; "Daniel"; "Fernando"; "Sergio"; "Rafael"; "Alberto"; "Juan Carlos"; "Alejandro"; "Víctor"; "Diego";
    "Lucía"; "María"; "Carmen"; "Ana"; "Isabel"; "Laura"; "Patricia"; "Marta"; "Clara"; "Raquel"; 
    "Elena"; "Sara"; "Victoria"; "Paula"; "Beatriz"; "Verónica"; "Inés"; "Rebeca"; "Cristina"; "Montserrat";
    "Joaquín"; "Esteban"; "Eduardo"; "Héctor"; "Marta"; "Valeria"; "Ángel"; "Ricardo"; "Emilia"; "Teresa";
    "Lorenzo"; "Santiago"; "Valentina"; "Ignacio"; "Guillermo"; "Renata"; "Sofía"; "Lola"; "Carlos Alberto"; "Martín"
]

let apellidos = [
    "Gómez"; "Martínez"; "Rodríguez"; "López"; "Pérez"; "Sánchez"; "González"; "Fernández"; "López"; 
    "Díaz"; "Moreno"; "Álvarez"; "Romero"; "Muñoz"; "Jiménez"; "Vázquez"; "Morales"; "Molina"; "Ruiz"; 
    "Navarro"; "Castro"; "Torres"; "Ríos"; "Silva"; "Hernández"; "Garcia"; "Ramírez"; "Vega"; "Serrano";
    "Santos"; "Cordero"; "Bravo"; "Domínguez"; "Carrasco"; "Escobar"; "Ortega"; "Núñez"; "Serrano"; "Campos";
    "Luna"; "Salazar"; "Méndez"; "Medina"; "Castaño"; "Paredes"; "Cordero"; "Garrido"; "Ríos"; "Acevedo";
    "Sánchez"; "Pineda"; "Ávila"; "Jaramillo"; "Figueroa"; "Sierra"; "Torralba"; "Vidal"; "Fuentes"; "Alvarado"
]
let generarNombre () =
    let nombre = nombres.[rnd.Next(nombres.Length)]
    let apellido = apellidos.[rnd.Next(apellidos.Length)]
    $"{nombre} {apellido}"
    //Ciclo para agregar datos a codigos, nombres, tel y correos
for k in 00..antsumaventasdiariasbdtest do
    let nombreAleatorio = generarNombre ()
    let correoAletorio = $"%d{k}%d{2*k}@Correo.pruevasdeBD.com.co"
    let TelAletorio =30000000+k
    let codtransaccionAleatorio = 1000000+k
    codigostranasionesbstest.Add(codtransaccionAleatorio)
    nombresclientesbdtest.Add(nombreAleatorio)
    Telefonosbstest.Add(TelAletorio)
    correosbstest.Add(correoAletorio)
//Calculo recaudos y ventas
    //listas de precios por articulo en venta y lista de recaudos por llenar
let recaudosbstest = ResizeArray<int>() 
let Totalescomprasbstest = ResizeArray<int>() 
let Totalescomprasbstestsaldos = ResizeArray<int>()
let totalesventassombreros =Seq.map (fun x -> x * 30000) vendiasombrero
let totalvendiaspañuelo = Seq.map (fun x -> x * 12000) vendiaspañuelo
let totalvendiacamisa = Seq.map (fun x -> x * 27000) vendiacamisa
let totalvendiapantalon = Seq.map (fun x -> x * 20000) vendiapantalon
    //llenado de listas
for gb in 0..antsumaventasdiariasbdtest do
    let valorsombreros = Seq.item gb totalesventassombreros
    let valorpañuelos = Seq.item gb totalvendiaspañuelo
    let valorcamisas = Seq.item gb totalvendiacamisa
    let valorpantalones = Seq.item gb totalvendiapantalon
    let valorcompragenral = valorsombreros+valorcamisas+valorpañuelos+valorpantalones
    Totalescomprasbstest.Add(valorcompragenral)
for tt in 0..antsumaventasdiariasbdtest do
    let maxlimite = Seq.item tt Totalescomprasbstest
    let recaudoramdomm =  rnd.Next(0, maxlimite)
    recaudosbstest.Add(recaudoramdomm)
for ytu in 0..antsumaventasdiariasbdtest do 
    let valorcompra = Seq.item ytu Totalescomprasbstest
    let valorrecaudo = Seq.item ytu recaudosbstest
    let valorsaldo = valorcompra-valorrecaudo
    Totalescomprasbstestsaldos.Add(valorsaldo)
//fechas de entrega y venta listas se repiten fechas tantas veces como venta se hizo en ese dia
let ListadoFechasventas = ResizeArray<DateTime>()
for russ in ventasdiariasbdtest do
    let capcontador = russ-1
    for russseg in 0..capcontador do
        let indiceruss = ventasdiariasbdtest.IndexOf(russ)
        let indicetomar = 699-indiceruss
        let fechaventaddbd = Seq.item indicetomar fechasbdtest
        ListadoFechasventas.Add(fechaventaddbd)
let ListadoFechasEntregas = ResizeArray<DateTime>()
for asd in ListadoFechasEntregas do
    let nufechaentrega = asd.AddDays(7.0)
    ListadoFechasEntregas.Add(nufechaentrega)
//direciones
let CllKR = ["calle";"carrera"]
let numeralesplacas = [0..99]
let surnorte = ["norte";"sur"]
let direcionesventasbdtets = ResizeArray<string>()
let generarDireccion () =
    let orientacion = CllKR.[rnd.Next(CllKR.Length)]
    let numeroorientacion = numeralesplacas.[rnd.Next(numeralesplacas.Length)]
    let placauno = numeralesplacas.[rnd.Next(numeralesplacas.Length)]
    let placados = numeralesplacas.[rnd.Next(numeralesplacas.Length)]
    let polaridadbarial =  surnorte.[rnd.Next(surnorte.Length)]
    $"{orientacion} {numeroorientacion} #{placauno}- {placados} {polaridadbarial}"
for gbt in 0..antsumaventasdiariasbdtest do
    let newdirection = generarDireccion ()
    direcionesventasbdtets.Add(newdirection)