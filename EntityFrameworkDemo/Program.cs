using DB;
using Microsoft.EntityFrameworkCore;

// esto evita poner en crudo los datos de conexión en el context que nos crea EF
DbContextOptionsBuilder<CSharpDBContext> optionsBuilder = new DbContextOptionsBuilder<CSharpDBContext>();

optionsBuilder.UseSqlServer("Server=.; Database=CSharpDB; User Id=sa; Password=Password1");

int option = 0;

do
{
    Menu();
    Console.Write("\nSeleccione una opción: ");
    option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            Show(optionsBuilder);
            break;
        case 2:
            Add(optionsBuilder);
            break;
        case 3:
            Edit(optionsBuilder);
            break;
        case 4:
            Delete(optionsBuilder);
            break;
    }
} while (option != 5);

static void Menu()
{
    Console.WriteLine("\nCRUD C# Y ENTITY FRAMEWORK");
    Console.WriteLine("**************************");
    Console.WriteLine("1. Mostrar");
    Console.WriteLine("2. Agregar");
    Console.WriteLine("3. Editar");
    Console.WriteLine("4. Eliminar");
    Console.WriteLine("5. Salir");
}

static void Show(DbContextOptionsBuilder<CSharpDBContext> optionsBuilder)
{
    Console.Clear();
    Console.WriteLine("+++ Listado de cervezas +++\n");
    // using nos permite creer un "microuniverso" de la conexión
    // la cual ya incluye su método de desconexión
    using (CSharpDBContext context = new CSharpDBContext(optionsBuilder.Options))
    {
        // List<Beer> beers = context.Beers.ToList();
        List<Beer> beers = context.Beers.OrderBy(beer => beer.Name).ToList();
        // sintaxis con LINQ
        // include permite hacer un join con la tabla Brand
        List<Beer> beers2 = (from beer in context.Beers
                             orderby beer.Name
                             select beer)
                             .Include(beer => beer.Brand)
                             .ToList();
        foreach (var beer in beers)
        {
            Console.WriteLine($"Id: {beer.Id} - Nombre: {beer.Name} - Marca: {beer.Brand.Name}");
        }
    }

    // cerrando la conexión a la db (no es necesario usando using)
    // context.Dispose();
}

static void Add(DbContextOptionsBuilder<CSharpDBContext> optionsBuilder)
{
    Console.Clear();
    Console.WriteLine("+++ Agregar una cerveza +++\n");
    Console.Write("Nombre: ");
    string name = Console.ReadLine();
    Console.Write("Id de la marca: ");
    int brandId = int.Parse(Console.ReadLine());

    using (var context = new CSharpDBContext(optionsBuilder.Options))
    {
        Beer beer = new Beer() { Name = name, BrandId = brandId };
        context.Add(beer);
        // guardar en la db
        context.SaveChanges();
    }
}

static void Edit(DbContextOptionsBuilder<CSharpDBContext> optionsBuilder)
{
    Console.Clear();
    Show(optionsBuilder);
    Console.WriteLine("\n+++ Editar una cerveza +++\n");
    Console.Write("Id de la cerveza: ");
    int id = int.Parse(Console.ReadLine());

    using (var context = new CSharpDBContext(optionsBuilder.Options))
    {
        Beer beer = context.Beers.Find(id);
        if (beer != null)
        {
            Console.Write("Nuevo nombre: ");
            string name = Console.ReadLine();
            Console.Write("Nuevo Id de la marca: ");
            int brandId = int.Parse(Console.ReadLine());
            beer.Name = name;
            beer.BrandId = brandId;
            // entry indica que la info se está actualizando
            context.Entry(beer).State = EntityState.Modified;
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine($"El id {id} no existe");
        }
    }
}

static void Delete(DbContextOptionsBuilder<CSharpDBContext> optionsBuilder)
{
    Console.Clear();
    Show(optionsBuilder);
    Console.WriteLine("\n+++ Eliminar una cerveza +++\n");
    Console.Write("Id de la cerveza: ");
    int id = int.Parse(Console.ReadLine());

    using (var context = new CSharpDBContext(optionsBuilder.Options))
    {
        Beer beer = context.Beers.Find(id);
        if (beer != null)
        {
            context.Beers.Remove(beer);
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine($"El id {id} no existe");
        }
    }
}