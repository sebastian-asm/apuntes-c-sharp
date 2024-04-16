try
{
    // string file = File.ReadAllText("C:\\Users\\sebas\\source\\repos\\CursoCSharp\\demo.txt");
    string file = File.ReadAllText(@"C:\Users\sebas\source\repos\CursoCSharp\demo.txt");
    Console.WriteLine(file);
    // simulando una ruta inválida
    string file2 = File.ReadAllText(@"C:\Users\sebas\source\repos\CursoCSharp\demo2.txt");
    Console.WriteLine(file2);
}
// se puede ser más específico del error que se va a capturar
// catch (FileNotFoundException ex)
// o ser más generales
catch (Exception ex)
{
    Console.WriteLine("El archivo no existe: " + ex.Message);
}
finally
{
    Console.WriteLine("Se ejecuta pase lo que pase");
}

Console.WriteLine("El programa sigue adelante...");

try
{
    Beer beer = new Beer()
    {
        Name = "London Porter",
        // Brand = "Fuller"
    };
    Console.WriteLine(beer.ToString());
}
catch (InvalidBeerException ex)
{
    Console.WriteLine(ex.Message);
}


class Beer
{
    public string Name { get; set; }
    public string Brand { get; set; }

    public override string ToString()
    {
        // lanzar la excepción
        if (Name == null || Brand == null) throw new InvalidBeerException();
        return $"Cerveza: {Name}, Marca: {Brand}";
    }
}

// crear una excepción personalizada
class InvalidBeerException : Exception
{
    public InvalidBeerException() : base("Falta el nombre o marca de la cerveza") { }
}