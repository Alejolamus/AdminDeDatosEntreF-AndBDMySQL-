namespace RegrecionLineaProdUnico
module EstudioRegresion =
    open DataTypes.DatosVentaDiariaUniProd
    open DataTypes.RegistroRegresion
    
    // Función para calcular la regresión y devolver el registro
    let calcularRegresion (datosprod: ResizeArray<RegistroVentaDia>) : RegistroDeRegresion =
        //producto
        let nombreproducto = datosprod.[0].Nombre
        // Número de elementos (n)
        let n = datosprod.Count
    
        // Suma de los índices (sum x)
        let sumaUnoAN = (n * (n - 1)) / 2
    
        // Obtener las cantidades de ventas
        let cantidades = 
            datosprod
            |> Seq.map (fun registro -> registro.Cantidad)
            |> Seq.toList
    
        // Sumar las cantidades (sum y)
        let sumCantidades = List.sum cantidades
    
        // Calcular la suma de las cantidades multiplicadas por su índice + 1 (sum xy)
        let cantidadesMultiplicadas = 
            cantidades
            |> List.mapi (fun indice cantidad -> cantidad * (indice + 1)) // Nota: indice + 1
        let sumCantMul = List.sum cantidadesMultiplicadas
    
        // Calcular la suma de los cuadrados de los índices (sum xx)
        let sumCuadradosLenDatos = ((n - 1) * n * (2 * n - 1)) / 6 // Formula de suma de los cuadrados de los primeros n enteros
    
        // Calcular la pendiente (b)
        let pendienteRegresion = 
            (float n * float sumCantMul - float sumaUnoAN * float sumCantidades) / 
            (float n * float sumCuadradosLenDatos - float sumaUnoAN * float sumaUnoAN)
    
        // Calcular el intercepto (a)
        let intercepto = 
            (float sumCantidades - pendienteRegresion * float sumaUnoAN) / float n
    
        // Crear la ecuación en formato "mx + b"
        let ecuacion = sprintf "y = %.2fx + %.2f" pendienteRegresion intercepto
    
        // Crear y retornar el registro con la ecuación, pendiente e intercepto
        let resultado = {
            Producto = nombreproducto
            Ecuacion = ecuacion
            Pendiente = pendienteRegresion
            EjeY = intercepto
            NDias = n
        }
        resultado