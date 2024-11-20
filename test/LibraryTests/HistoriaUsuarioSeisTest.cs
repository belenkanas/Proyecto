using NUnit.Framework;

namespace Library.Tests;
/// <summary>
/// Como jugador, quiero ganar la batalla cuando la vida de todos los Pokémons oponente llegue a cero.
/// </summary>
public class HistoriaUsuarioSeisTest
{
    public CatalogoPokemons CatalogoPokemons;
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
    private BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Juan");
        jugador2 = new JugadorPrincipal("Martina");

        jugador.ElegirDelCatalogo(2); //Elige a Squirtle
        jugador.ElegirDelCatalogo(5); //Elige a Bulbasaur

        jugador2.ElegirDelCatalogo(4); //Elige a Charmander.
        jugador2.ElegirDelCatalogo(6); //Elige a Pidgey.

        batalla = new BatallaFacade(jugador.NombreJugador, jugador2.NombreJugador);
    }

    [Test]
    //La batalla termina automáticamente cuando todos los Pokémons del oponente alcanza 0 de vida.
    public void DerrotaCuandoTotalPokemonsVidaCero()
    {
        foreach (IPokemon pokemon in jugador2.EquipoPokemons)
        {
            pokemon.VidaActual = 0; //Forzamos a que todos los pokemones del equipo estén derrotados.
        }

        batalla.VerificarGanador();
        
        Assert.IsFalse(batalla.BatallaSigue());

    }

    [Test]
    //Se muestra un mensaje indicando el ganador de la batalla.
    public void MensajeGanador()
    {
        string ganador = batalla.VerificarGanador();

        string resultadoJ2 = $"{jugador.NombreJugador} ha sido derrotado " +
                             $"{jugador2.NombreJugador} GANÓ";
        
        Assert.That(ganador, Is.EqualTo(resultadoJ2));
    }
}