using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class BatallaFacadeTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Belén");
        jugador2 = new JugadorPrincipal("Valentina");
        
        jugador.ElegirDelCatalogo(1);
        jugador.ElegirDelCatalogo(2);
        jugador.ElegirDelCatalogo(3);
        jugador.ElegirDelCatalogo(4);
        jugador.ElegirDelCatalogo(5);
        jugador.ElegirDelCatalogo(6);
        
        jugador2.ElegirDelCatalogo(1);
        jugador2.ElegirDelCatalogo(2);
        jugador2.ElegirDelCatalogo(3);
        jugador2.ElegirDelCatalogo(4);
        jugador2.ElegirDelCatalogo(5);
        jugador2.ElegirDelCatalogo(6);
    }

    /// <summary>
    /// Este test verifica que si todos los pokémon de el equipo de Belén están derrotados (tienen su vida actual en 0)
    /// La ganadora será Valentina y la batalla se termina.
    /// </summary>
    [Test]
    public void VerificarGanador_PokemonesDerrotados()
    {
        BatallaFacade batalla = new BatallaFacade(jugador.NombreJugador, jugador2.NombreJugador);

        jugador.ElegirPokemon(0).VidaActual = 0;
        jugador.ElegirPokemon(1).VidaActual = 0;
        jugador.ElegirPokemon(2).VidaActual = 0;
        jugador.ElegirPokemon(3).VidaActual = 0;
        jugador.ElegirPokemon(4).VidaActual = 0;
        jugador.ElegirPokemon(5).VidaActual = 0;

        string resultado = batalla.VerificarGanador();
        string ganador = $"{jugador.NombreJugador} ha sido derrotado " +
                         $"{jugador2.NombreJugador} GANÓ";
        
        Assert.That(resultado, Is.EqualTo(ganador));
        Assert.That(batalla.BatallaEnCurso, Is.EqualTo(false));
    }
}