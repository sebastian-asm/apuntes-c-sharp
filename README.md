# Apuntes C#

Lenguage fuertemente tipado, lo que significa que a las variables hay que indicarles un tipo de dato para especificar su alcance (int, double, char, string o boolean). En C# el punto y coma (;) es necesario al terminar de cada línea para indicar su finalización.

El lenguaje nos permite crear objetos anónimos, o sea, sin necesidad de definir una clase para luego crear la instancia. La desventaja de crear uno anónimo es que solo es de lectura, su contenido no se puede modificar. 

```c#
var people = new 
{
	Name = "Seba",
	Country = "Chile"
};
```

## POO

C# es multiparadigma y uno de ellos es la Programación Orientada a Objetos siendo uno de los más utilizado basado en clases y objetos.

- **public**: se puede acceder desde cualquier lado cuando se crea el objeto
- **private**: solo se podrá acceder dentro de la clase en donde fue definida
- **protected**: permite usar dentro de la clase padre y de las clases que extiende
- **static**: permite acceder a propiedades y métodos sin necesidad de instanciar un objeto, sino directamente de la clase. Cuando se crea una clase static, todo lo que contenga tambpien debe ser static (propiedades y métodos)

Existe la posibilidad de modificar el acceso de las propiedades de la clase mediante un "accessor" de tipo *get* para leer y de tipo *set* para establecer (este siempre disponible una variable llamada *value*).

**Herencia**: permite que una clase herede de otra sus características (propiedades y métodos).

**Sobrecarga de métodos**: es la capacidad que tienen las clases para tener métodos con el mismo nombre pero invocado con distintos parámetros.

**Sobreescritura de métodos**: es una característica que permite modificar un método de la clase padre o ampliar su funcionalidad mediante la palabra reservada *virtual* y *override*.

**Interfaces**: esta una especia de "contrato" que las clases deben cumplir, aplicando los métodos y propiedades que indica la interface.

**Generics**: nos permite reutilizar código, por convención de utiliza la letra *T*, o sea, `<T>`.

## List

Una *List* es un objecto que está preparado con una gran colección métodos listos para usar en los datos. A diferencia de un array al que se le tiene que indicar su longitud, en una list no es necesario, en este aspecto es mucho más flexible. Conmunmente para trabajar con List se agrega el paquete `using System.Collections.Generic`.

## Tuple (Tuplas)

Lista de variables que pueden ser de distinto tipo. A diferencia de un objeto anónimo, la tupla sí permite modificar su contenido. Cuando se crea un tupla en base a un array, todos los registros deben contar con los mismo tipos de datos y orden.

## Exceptions

Nos permiten controlar situaciones inesperadas, como puede ser que la conexión a la db este caída o algún servicio, que un archivo no exista, o que se espera un int y llegue un string. Esto se hace mediante un `try catch`, que aunque el programa tenga un error, puede seguir adelante.  

## LINQ

Es una extensión del lenguaje que nos permite trabajar con colecciones (array o list) de manera más sencilla y declarativa, como si se tratara de SQL. También se puede usar su sintaxis junto a Entity Framework.

## Entity Framework

Es un ORM que vienen por defecto en .NET, el cual nos permite trabajar la interacción con la base de datos sin necesidad de realizar queries de forma nativa en SQL, más bien, con EF se utilizan objetos y clases. Pasos para agregar el framework:
1. Crear un nuevo proyecto (usando la plantilla *Bibliteca de clases*)
2. En *Dependencias* agregar con el administrador *NuGet* los paquetes `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools` y `Microsoft.EntityFrameworkCore`
3. En *Herramientas*, luego *Administrador de paquetes NuGet* abrir *Consola del administrador de paquetes*
4. Usar la consola (indicando el proyecto predeterminado) para mapear la base de datos con el comando `Scaffold-DbContext "Server=.; Database=CSharpDB; User Id=sa; Password=Password1" Microsoft.EntityFrameworkCore.SqlServer` 