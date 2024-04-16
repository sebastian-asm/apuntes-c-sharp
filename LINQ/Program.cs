List<Beer> beers = new List<Beer>()
{
    new Beer() { Name = "Corona", Country = "México" },
    new Beer() { Name = "Delirium", Country = "Bélgica" },
    new Beer() { Name = "Erdinger", Country = "Alemania" }
};

var countries = new List<Country>()
{
    new Country() { Name = "México", Continent = "América" },
    new Country() { Name = "Bélgica", Continent = "Europa" },
    new Country() { Name = "Alemania", Continent = "Europa" },
};

foreach (var beer in beers)
{
    Console.WriteLine(beer);
}

// LINQ
// select (se pueden agregar campos adicionales en la consulta)
var beersName = from beer in beers
                select new
                {
                    Name = beer.Name,
                    Letters = beer.Name.Length
                };
foreach (var beer in beersName) Console.WriteLine(beer);

var beersMexico = from beer in beers
                  where beer.Country == "México"
                  || beer.Country == "Alemania"
                  select beer;
foreach (var beer in beersMexico) Console.WriteLine(beer);

var orderedBeers = from b in beers
                   orderby b.Country
                   select b;
foreach (var beer in orderedBeers) Console.WriteLine(beer);

// join
Console.WriteLine("************");
var beersWithContinent = from beer in beers
                         join country in countries
                         on beer.Country equals country.Name
                         select new
                         {
                             Beer = beer.Name,
                             Country = beer.Country,
                             Continent = country.Continent
                         };
foreach (var beer in beersWithContinent) Console.WriteLine(beer);

class Beer
{
    public string Name { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"Nombre: {Name}, País: {Country}";
    }
}

class Country
{
    public string Name { get; set; }
    public string Continent { get; set; }
}