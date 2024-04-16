(int id, string name) product = (1, "Cerveza Stout");
Console.WriteLine($"{product.id} - {product.name}");
product.name = "Cerveza Porter";
Console.WriteLine($"{product.id} - {product.name}");
// otro ejemplo, donde el valor indicará el tipo de dato
var person = (1, "Sebas");
Console.WriteLine($"Persona: ID {person.Item1} - {person.Item2}");
var people2 = new[]
{
    (1, "Belu"),
    (2, "Valen"),
    (3, "Ramses")
};
foreach (var p in people2)
{
    Console.WriteLine($"{p.Item1}. {p.Item2}");
}

(int id, string name)[] people3 = new[]
{
    (1, "Belu"),
    (2, "Valen"),
    (3, "Ramses")
};
foreach (var p in people3)
{
    Console.WriteLine($"{p.id}. {p.name}");
}

// una tupla nos ayudaría en el retorno de múltiples valores en una función
var city = getLocation();
Console.WriteLine($"latitud: {city.lat} | Longitud: {city.lng} | Ciudad: {city.name}");
// solo se puede obtener el dato que se necesita, lo demas se pueden omitir con un _
var (_, lng, _) = getLocation();
Console.WriteLine(lng);

static (float lat, float lng, string name) getLocation()
{
    float lat = 13.123f;
    float lng = -32.321f;
    string name = "STGO";
    return (lat, lng, name);
}