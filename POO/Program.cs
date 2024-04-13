// paquete que nos permitirá la manipulación del formato JSON
using System.Text.Json;

Sale sale = new Sale(123, DateTime.Now);
string message = sale.getInfo();
Console.WriteLine(message);
sale.Total = -123;
Console.WriteLine(sale.Total);

// HERENCIA
Doctor doctor = new Doctor("Belu", 39, "Mastologa");
Console.WriteLine(doctor.getInfo());
Console.WriteLine(doctor.getData());

// SOBRECARGA DE MÉTODO
Math math = new Math();
Console.WriteLine(math.Sum(5, 5));
Console.WriteLine(math.Sum("5", "5"));
int[] numbers = new int[] { 2, 4, 6 };
Console.WriteLine(math.Sum(numbers));

// SOBREESCRITURA
Demo2 demo = new Demo2();
Console.WriteLine(demo.Hi());
Sale2 sale2 = new Sale2(5);
sale2.Add(2);
sale2.Add(10);
sale2.Add(20);
Console.WriteLine("El total es: " + sale2.GetTotal());
// m: para indicar un valor decimal
SaleWithTax saleWithTax = new SaleWithTax(5, 1.19m);
saleWithTax.Add(2);
saleWithTax.Add(10);
saleWithTax.Add(20);
Console.WriteLine("El total + IVA es: " + saleWithTax.GetTotal());

// STATIC
Console.WriteLine(Demo3.count);
Demo3 demo3 = new Demo3();
Demo3 demo33 = new Demo3();
Console.WriteLine(Demo3.GetCount());

// INTERFACES
IFish[] sharks = new IFish[]
{
    new Shark("Tiburonsin"),
    new Shark("Jaw"),
};
showFish(sharks);
static void showFish(IFish[] fishs)
{
    Console.WriteLine("** Listado de peces **");
    int i = 0;
    while (i < fishs.Length)
    {
        Console.WriteLine(fishs[i++].Swim());
    }
}

// GENERICS
MyList<int> numbers2 = new MyList<int>(10);
numbers2.Add(1);
numbers2.Add(2);
MyList<string> myList = new MyList<string>(10);
myList.Add("1");
myList.Add("2");
Console.WriteLine(numbers2.getElement(11));
Console.WriteLine(myList.getElement(0));
Console.WriteLine(numbers2.getString());
Console.WriteLine(myList.getString());
MyList<People2> people2 = new MyList<People2>(5);
people2.Add(new People2() { name = "Belu", country = "Argentina" });
people2.Add(new People2() { name = "Seba", country = "Chile" });
Console.WriteLine(people2.getString());

// JSON
Beer beer = new Beer()
{
    name = "Pikantus",
    brand = "Erdinger"
};
string json = JsonSerializer.Serialize(beer);
Beer beer2 = JsonSerializer.Deserialize<Beer>(json);
Console.WriteLine(json);

class Sale
{
    // propiedades
    private int total;
    DateTime date;

    // accessor
    public int Total
    {
        get
        {
            return total;
        }
        // set siempre tendrá disponible la variable value
        set
        {
            // no se permite que el valor de total sea menor a cero
            if (value < 0) value = 0;
            total = value;
        }
    }

    // constructor (se llama igual a la clase)
    public Sale(int total, DateTime date)
    {
        this.total = total;
        this.date = date;
    }

    // métodos
    public string getInfo()
    {
        return "Total: $" + total + " | " + "Fecha: " + date.ToString();
    }
}

// HERENCIA
class People
{
    // conmunmente una propiedad privada se declara con un _ al inicio por convención
    private string _name;
    private int _age;

    public People(string name, int age)
    {
        // en este caso se puede omitir el this ya que la propiedad declara es
        // diferente a la variable que se desclara en el constructor por el _
        _name = name;
        _age = age;
    }

    public string getInfo()
    {
        return "Nombre: " + _name + " - " + "Edad: " + _age;
    }
}

// solo se puede heredar de una clase
class Doctor : People
{
    private string _speciality;

    // base permite enviar los valores al constructor padre
    // como el "super" de JavaScript
    // siempre respetando el mismo orden de las variables definidas en el padre
    public Doctor(string name, int age, string speciality) : base(name, age)
    {
        _speciality = speciality;
    }

    public string getData()
    {
        return getInfo() + " - " + "Especialidad: " + _speciality;
    }
}

// SOBRECARGA DE MÉTODO
class Math
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Sum(string a, string b)
    {
        return int.Parse(a) + int.Parse(b);
    }

    public int Sum(int[] numbers)
    {
        int result = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            result += numbers[i];
        }
        return result;
    }
}

// SOBREESCRITURA DE MÉTODO
class Demo1
{
    // virtual permitirá la sobreescritura mediante override
    public virtual string Hi()
    {
        return "Hola! desde la clase padre";
    }
}

class Demo2 : Demo1
{
    public override string Hi()
    {
        // sobreescribira el return del padre
        // return "Hola! desde la clase hija";
        // con base se sumará el return del padre
        return base.Hi() + " | " + "Hola! desde la clase hija";
    }
}

public class Sale2
{
    private decimal[] _amounts;
    private int _n;
    private int _end;

    public Sale2(int n)
    {
        _end = 0;
        _amounts = new decimal[n];
        _n = n;
    }

    public void Add(decimal amount)
    {
        if (_end < _n)
        {
            _amounts[_end] = amount;
            _end++;
        }
    }

    public virtual decimal GetTotal()
    {
        decimal total = 0;
        int i = 0;
        while (i < _amounts.Length)
        {
            total += _amounts[i];
            i++;
        }
        return total;
    }
}

public class SaleWithTax : Sale2
{
    private decimal _tax;

    public SaleWithTax(int n, decimal tax) : base(n)
    {
        _tax = tax;
    }

    public override decimal GetTotal()
    {
        return base.GetTotal() * _tax;
    }
}

// STATIC
class Demo3
{
    public static int count = 0;

    public Demo3()
    {
        count++;
    }

    public static string GetCount()
    {
        // el $ permite hacer interpolación de string
        return $"Esta clase se ha instanciado {count} veces";
    }
}

// INTERFACES
public interface IAnimal
{
    public string Name { get; set; }
}

public interface IFish
{
    public string Swim();
}

// a diferencia de la herencia de clase que solo se puede heredar de una
// con las interfaces se pueden indicar las necesarias separadas por coma
class Shark : IAnimal, IFish
{
    public string Name { get; set; }
    public Shark(string name)
    {
        Name = name;
    }
    public string Swim()
    {
        return $"{Name} es un nadador";
    }
}

// GENERICS
class MyList<T>
{
    private T[] _elements;
    private int _count = 0;

    public MyList(int n)
    {
        _elements = new T[n];
    }

    public void Add(T x)
    {
        if (_count < _elements.Length)
        {
            _elements[_count++] = x;
        }
    }

    public T getElement(int i)
    {
        if (i >= 0 && i <= _count)
        {
            return _elements[i];
        }
        // en caso de no cumplir el if se devuelve el tipo por defecto
        return default(T);
    }

    public string getString()
    {
        int i = 0;
        string result = "";
        while (i < _count)
        {
            result += _elements[i++].ToString() + "|";
        }
        return result;
    }
}

class People2
{
    public string name { get; set; }
    public string country { get; set; }

    public override string ToString()
    {
        return $"Nombre: {name}, País: {country}";
    }
}

// JSON
class Beer
{
    public string name { get; set; }
    public string brand { get; set; }
}