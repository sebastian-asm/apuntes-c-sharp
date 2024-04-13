// VARIABLES
int number1 = 1;
Console.WriteLine(number1);
number1 = 2;
Console.WriteLine(number1);

// TIPOS DE DATOS
int number2 = 3; // número entero
double doubleNumer = 123.4; // número con decimales
char character = 'a'; // una sola letra (con comilla simple)
string name = "belu"; // cadena de texto (con comilla doble)
bool exits = false; // almacenar true o false

// FUNCIONES
// void indica que la función no devuelve nada
static void show()
{
    Console.WriteLine("Texto que se imprime desde una función");
}
show(); // invocación de la función

static void sum(int num1, int num2) // función con parámetros
{
    int total = num1 + num2;
    Console.WriteLine(total);
}
sum(10, 20);
sum(50, 50);

// esta función retorna un valor int
static int mul(int num1, int num2)
{
    return num1 * num2;
}
int m = mul(5, 5);
Console.WriteLine(m);

// SENTENCIA IF / ELSE
bool hungry = true;
bool money = true;
// && = and
// || = or
if (hungry && money && isOpenRestaurent("Mostaza", 8))
{
    Console.WriteLine("A comer!");
}
else
{
    Console.WriteLine("A esperar...");
}

static bool isOpenRestaurent(string name, int hour = 0)
{
    if (name == "Mostaza" && hour >= 8 && hour <= 23)
    {
        return true;
    }
    else if (name == "Restaurant 24 horas")
    {
        return true;
    }
    else
    {
        return false;
    }
}

// SENTENCIA SWITCH
int option = -1;
switch (option)
{
    case 1:
        Console.WriteLine("Seleccionaste la opción 1");
        break;
    case 2:
        Console.WriteLine("Seleccionaste la opción 2");
        break;
    case 3:
    case 4:
        Console.WriteLine("Seleccionaste la opción 3 o 4");
        break;
    case < 0:
        Console.WriteLine("Opción fuera de rango");
        break;
    // se puede utilizar and y or
    case > 4 and < 10:
        Console.WriteLine("Seleccionaste una opción entre 4 y 10");
        break;
    default:
        Console.WriteLine("Opción no válida");
        break;
}

// ARREGLOS: almacenar una colección de variables
// el 5 indica el largo del array
// se puede indicar los datos del array con las {}
string[] days = new string[5] {
    "Lunes",
    "Martes",
    "Miércoles",
    "Jueves",
    null // para indicar que la última posición no tiene valor asignado
};

// otra forma de guardar datos apuntando directamente a su indice
// days[0] = "Lunes";

// esto daría error ya que supera el largo indicado en el array
// days[5] = "Viernes";

// SENTENCIA WHILE Y DO WHILE
int i = 1;
while (i <= 10)
{
    Console.WriteLine("Número de i: " + i);
    i++;
}

int j = 1;
while (j < 100)
{
    // el break rompera el ciclo
    if (j > 5) break;
    Console.WriteLine("Número de j: " + j);
    j++;
}

// recorriendo un array con while
int index = 0;
days[4] = "Viernes";
while (index < days.Length)
{
    Console.WriteLine("Día: " + days[index]);
    index++;
}

// entrar una vez al ciclo aunque todavía no se cumpla la condición
bool run = false;
do
{
    Console.WriteLine("Entro por lo menos una vez");
} while (run);

// SENTENCIA FOR
for (int x = 0; x < days.Length; x++)
{
    Console.WriteLine("Día: " + days[x]);
}
