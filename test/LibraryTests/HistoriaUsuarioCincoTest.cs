using NUnit.Framework;

namespace Library.Tests;
/// <summary>
/// Como jugador, quiero saber de quién es el turno para estar seguro de cuándo atacar o esperar.
/// </summary>
public class HistoriaUsuarioCincoTest
{
    public CatalogoPokemons CatalogoPokemons;
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
    
    [SetUp]
    public void SetUp()
    {
        CatalogoPokemons = new CatalogoPokemons();
        jugador = new JugadorPrincipal("Ash");
        jugador2 = new JugadorPrincipal("Sean");
        
        jugador.MostrarCatalogo();
        jugador.ElegirDelCatalogo(4);
        jugador.ElegirDelCatalogo(8);
        
        jugador2.MostrarCatalogo();
        jugador2.ElegirDelCatalogo(3);
        jugador2.ElegirDelCatalogo(9);
    }

    [Test]
    //En la pantalla se muestra claramente un indicador que señala de quién es el turno actual.
    public void MostrarTurnoActual()
    {
        jugador.TurnoActual = true;
        jugador2.TurnoActual = false;
        
        Assert.That(true, Is.EqualTo(jugador.MostrarTurno()));
        Assert.That(false, Is.EqualTo(jugador2.MostrarTurno()));
        
        IPokemon pokemon = jugador.ElegirPokemon(1);
        IPokemon pokemonE = jugador2.ElegirPokemon(0);
        jugador.MostrarAtaquesDisponibles(1);

        pokemon.UsarAtaque(1, pokemonE);
        jugador.TurnoActual = false;
        jugador2.TurnoActual = true;
        
        Assert.That(true, Is.EqualTo(jugador2.MostrarTurno()));
    }
}