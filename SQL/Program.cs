using System.Data.SqlClient;

namespace SQL
{
    class Program
    {
        static void Main()
        {
            try
            {
                BeerDB beerDB = new BeerDB(".", "CSharpDB", "sa", "Password1");
                bool again = true;
                int option = 0;

                do
                {
                    Menu();
                    Console.Write("Elige una opción: ");
                    option = int.Parse(Console.ReadLine()!);

                    switch (option)
                    {
                        case 1:
                            Show(beerDB);
                            break;
                        case 2:
                            Add(beerDB);
                            break;
                        case 3:
                            Edit(beerDB);
                            break;
                        case 4:
                            Delete(beerDB);
                            break;
                        case 5:
                            again = false;
                            break;
                    }
                } while (again);


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error en la conexión a la DB: " + ex.Message);
            }
        }

        public static void Menu()
        {
            Console.WriteLine("\nCRUD C# Y SQL SERVER");
            Console.WriteLine("*********************");
            Console.WriteLine("1. Mostrar");
            Console.WriteLine("2. Agregar");
            Console.WriteLine("3. Editar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("5. Salir");
        }

        public static void Show(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("+++ Listado de cervezas +++");
            List<Beer> beers = beerDB.GetAll();
            foreach (var beer in beers)
            {
                Console.WriteLine($"Id: {beer.id} - Nombre: {beer.name} - Marca Id: {beer.brandId}");
            }
        }

        public static void Add(BeerDB beerDB)
        {
            Console.Clear();
            Console.WriteLine("+++ Agregar nueva cerveza +++");
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.Write("ID de la Marca: ");
            int brandId = int.Parse(Console.ReadLine());
            Beer beer = new Beer(name, brandId);
            beerDB.Add(beer);
        }

        public static void Edit(BeerDB beerDB)
        {
            Console.Clear();
            Show(beerDB);
            Console.WriteLine("\n+++ Editar una cerveza +++");
            Console.Write("Id de la cerveza: ");
            int id = int.Parse(Console.ReadLine());
            Beer beer = beerDB.Get(id);

            if (beer != null)
            {
                Console.Write("Nuevo nombre: ");
                string name = Console.ReadLine();
                Console.Write("Nuevo Id de la marca: ");
                int brandId = int.Parse(Console.ReadLine());

                beer.name = name;
                beer.brandId = brandId;
                beerDB.Edit(beer);
            }
            else
            {
                Console.WriteLine("La cerveza no existe");
            }
        }

        public static void Delete(BeerDB beerDB)
        {
            Console.Clear();
            Show(beerDB);
            Console.WriteLine("\n+++ Eliminar una cerveza +++");
            Console.Write("Id de la cerveza: ");
            int id = int.Parse(Console.ReadLine());
            Beer beer = beerDB.Get(id);

            if (beer != null)
            {
                beerDB.Delete(id);
            }
            else
            {
                Console.WriteLine("La cerveza no existe");
            }
        }
    }

}
