List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);
Console.WriteLine(numbers.Count);
// clear borra todos los elementos
numbers.Clear();
Console.WriteLine(numbers.Count);

// agregando valores en el inicio de la creación de la list
List<int> numbers2 = new List<int>() { 7, 1, 2, 3, 4, 5 };
Console.WriteLine(numbers2.Count);

// var: nos permitirá evitar escribir el tipo al inicio
// solo se puede usar en variables dentro de métodos
var list = new List<int>() { 10, 20, 30, 40, 50 };

// FOREACH
// funciona con list y string
foreach (var number in list)
{
    Console.WriteLine(number);
}

var people = new List<People>()
{
    new People() { name = "Belu", country = "Argentina" },
    new People() { name = "Seba", country = "Chile" }
};

showPeople(people);
// eliminar de la list (al igual que un array, la primera posición es 0)
people.RemoveAt(0);
showPeople(people);

// MÉTODOS MÁS COMUNES
// insert a diferencia del add, permite indicarle en que posición de la list se agregará
// en este caso, en el indice 0 se agrega el 6
numbers2.Insert(0, 6);

// comprobar si un dato existe en la lista (contains devuelve true o false)
if (numbers2.Contains(1)) Console.WriteLine("Existe");
else Console.WriteLine("No existe");

// saber en que posición se encuentra un elemento existente, de lo contrario devuelve -1
Console.WriteLine(numbers2.IndexOf(6));

// ordenar una lista (método mutable, o sea, el objeto cambia)
numbers2.Sort();
Console.WriteLine("** Lista ordenada **");
show(numbers2);

// agregar un rango de datos
numbers2.AddRange(new List<int>() { 200, 500, 300, 600 });
Console.WriteLine("** Lista con más datos **");
show(numbers2);

// TUPLE
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

// ***********************

static void show(List<int> numbers)
{
    foreach (var num in numbers)
    {
        Console.WriteLine(num);
    }
};

static void showPeople(List<People> students)
{
    Console.WriteLine("** Listado **");
    foreach (var student in students)
    {
        Console.WriteLine($"Nombre: {student.name} - País: {student.country}");
    }
}

class People
{
    public string name { get; set; }
    public string country { get; set; }
}