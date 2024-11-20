using NUnit.Framework;

namespace Library.Tests;

/// <summary>
/// Test1: Como jugador quiero elegir 6 Pokemoon del catalogo disponible.
/// </summary>
[TestFixture]
public class HistoriaUsuarioUnoTest
{
    public CatalogoPokemons catalogo;
    public JugadorPrincipal jugador1;
    public CatalogoAtaques ataques;

    [SetUp]
    //Debo asegurarme que se puede elegir hasta 6 pokemones y que se muestren en pantalla
    public void SetUp()
    {
        catalogo = new CatalogoPokemons();
        jugador1 = new JugadorPrincipal("Ana");
        
        jugador1.MostrarCatalogo();
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(7);
        jugador1.ElegirDelCatalogo(9);
        jugador1.ElegirDelCatalogo(12);
        jugador1.ElegirDelCatalogo(14);
        jugador1.MostrarEquipo();
        
    }
    [Test]
    public void PokemonsSeleccionadosSeMuestranEnPantalla()
    {
        string resultado = $"Squirtle, Agua\n" +
                           $"Charmander, Fuego\n" +
                           $"Articuno, Hielo\n" +
                           $"Bulbasaur, Planta\n" +
                           $"Pupitar, Roca\n" +
                           $"Rhyhorn, Tierra\n";

        // Se asegura si el mensaje es el mismo (el de la lista del equipo que se forma)
        Assert.That(jugador1.MostrarEquipo(), Is.EqualTo(resultado));
    }
    
    [Test]
    public void SeleccionarEquipo()
    { 
        // Se asegura que al grupo se pudieron unir 6 pokemones y no más.
        Assert.That(6, Is.EqualTo(jugador1.EquipoPokemons.Count));
    }
}