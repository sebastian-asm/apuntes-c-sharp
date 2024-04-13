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