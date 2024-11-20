using NUnit.Framework;

namespace Library.Tests;
/// <summary>
/// Como jugador, quiero poder cambiar de Pokémon durante una batalla.
/// </summary>
public class HistoriaUsuarioSieteTest
{
    public CatalogoPokemons CatalogoPokemons; 
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
    public BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        CatalogoPokemons = new CatalogoPokemons(); 
        jugador = new JugadorPrincipal("Asia");
        jugador2 = new JugadorPrincipal("Robert");
        batalla = new BatallaFacade(jugador.NombreJugador, jugador2.NombreJugador);
        
        jugador.MostrarCatalogo();
        jugador.ElegirDelCatalogo(5);
        jugador.ElegirDelCatalogo(6);
        jugador.ElegirDelCatalogo(7);
        jugador.ElegirDelCatalogo(8);
        jugador.ElegirDelCatalogo(10);
        jugador.ElegirDelCatalogo(12);
        
        jugador2.MostrarCatalogo();
        jugador2.ElegirDelCatalogo(1);
        jugador2.ElegirDelCatalogo(5);
        jugador2.ElegirDelCatalogo(9);
        jugador2.ElegirDelCatalogo(10);
        jugador2.ElegirDelCatalogo(11);
        jugador2.ElegirDelCatalogo(14);
    }

    [Test]
    public void CambiarPokemon()
    {
        jugador.PokemonActual = jugador.EquipoPokemons[0];
        batalla.CambiaPokemon(jugador, 1);       //Cambia a Charizard
        
        Assert.That("Charizard", Is.EqualTo(jugador.PokemonActual.Nombre));
    }

    [Test]
    public void PierdeTurno()
    {
        jugador.PokemonActual = jugador.EquipoPokemons[0];

        batalla.CambiaPokemon(jugador, 1);

        Assert.That(jugador.TurnoActual, Is.EqualTo(false));
    }
}