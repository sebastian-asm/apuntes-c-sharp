// DELEGADO
Operation mySum = Functions.Sum;
Console.WriteLine(mySum(10, 20));
mySum = Functions.Mul;
Console.WriteLine(mySum(10, 20));

// los delegados permiten la multidifusión (ejecutar todas las funciones relacionadas)
Show cw = Console.WriteLine;
cw += Functions.ConsoleShow;
cw("Demo");

Functions.Some("Belu", cw);

// delegados genéricos
Action<string> showMessage = Console.WriteLine;
Functions.SomeAction("Seba", showMessage);
showMessage("Demo 2");

Func<int> numberRandom = () => new Random().Next(0, 100);
Console.WriteLine($"Número random: {numberRandom()}");

Predicate<string> hasSpace = (word) => word.Contains(" ");
Console.WriteLine(hasSpace("hola mundo"));

// lambda
Action<string, string> showMessage2 = (a, b) => Console.WriteLine($"{a} {b}");
showMessage2("hola", "mundo");
Functions.SomeAction("test", (a) => Console.WriteLine(a));

delegate int Operation(int a, int b);
public delegate void Show(string message);

public class Functions
{
    // forma 1
    //public static int Sum(int x, int y)
    //{
    //    return x + y;
    //}
    // forma 2
    public static int Sum(int x, int y) => x + y;
    public static int Mul(int num1, int num2) => num1 * num2;
    public static void ConsoleShow(string msg) => Console.WriteLine(msg);

    // función de orden superior
    public static void Some(string name, Show fn)
    {
        // función de primer orden (callback)
        fn($"Hola {name}");
    }
    public static void SomeAction(string name, Action<string> fn)
    {
        fn($"Hola {name}");
    }
}