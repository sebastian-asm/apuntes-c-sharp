# Apuntes C#

Lenguage fuertemente tipado, lo que significa que a las variables hay que indicarles un tipo de dato para especificar su alcance (int, double, char, string o boolean). En C# el punto y coma (;) es necesario al terminar de cada línea para indicar su finalización.

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