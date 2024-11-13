namespace Library;

/// <summary>
/// Catálogo que contiene todos los pokémons que el jugador puede elegir para su equipo
/// </summary>
public class CatalogoPokemons
{
    public List<IPokemon> Catalogo { get; set; }

    public CatalogoPokemons()
    {
        Catalogo = new List<IPokemon>();
        AgregarPokemons();
    }

    /// <summary>
    /// Se agregan al catálogo los pokémons disponibles
    /// </summary>
    /// <returns>Pokémons disponibles para que el jugador seleccione</returns>
    public void AgregarPokemons()
    {
        Catalogo.Add(new Pokemon("Squirtle", new Agua(), 100));
        Catalogo.Add(new Pokemon("Wartortle", new Agua(), 100));
        Catalogo.Add(new Pokemon("Pikachu", new Electrico(), 100));
        Catalogo.Add(new Pokemon("Magneton", new Electrico(), 100));
        Catalogo.Add(new Pokemon("Charmander", new Fuego(), 100));
        Catalogo.Add(new Pokemon("Charizard", new Fuego(), 100));
        Catalogo.Add(new Pokemon("Articuno", new Hielo(), 100));
        Catalogo.Add(new Pokemon("Vulpix de Alola", new Hielo(), 100));
        Catalogo.Add(new Pokemon("Bulbasaur", new Planta(), 100));
        Catalogo.Add(new Pokemon("Oddish", new Planta(), 100));
        Catalogo.Add(new Pokemon("Geodude", new Roca(), 100));
        Catalogo.Add(new Pokemon("Pupitar", new Roca(), 100));
        Catalogo.Add(new Pokemon("Sandshrew", new Tierra(), 100));
        Catalogo.Add(new Pokemon("Rhyhorn", new Tierra(), 100));
    }

    /// <summary>
    /// Muestra todos los pokémons que hay en el catálogo 
    /// </summary>
    public void MostrarCatalogo()
    {
        Console.WriteLine("Seleccione 6 pokémons para su equipo con su número correspondiente: ");

        for (int i = 0; i < Catalogo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Catalogo[i].Nombre}");
        }
    }
}