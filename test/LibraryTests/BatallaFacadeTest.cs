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
    /// Este test verifica que la batalla haya iniciado correctamente, con sus pokémones actuales
    /// correspondientes.
    /// </summary>
    [Test]
    public void IniciarBatalla()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);
        jugador.PokemonActual = jugador.ElegirPokemon(0);
        jugador2.PokemonActual = jugador2.ElegirPokemon(1);
        
        string resultado = "Belén comienza la batalla con Squirtle\n" +
                           "Valentina comienza la batalla con Wartortle\n" +
                           $"¡La batalla ha comenzado! Turno 1.";
        
        Assert.That(batalla.IniciarBatalla(), Is.EqualTo(resultado));
    }
    
    /// <summary>
    /// Este test verifica que si todos los pokémon de el equipo de Belén están derrotados (tienen su vida actual en 0)
    /// La ganadora será Valentina y la batalla se termina.
    /// </summary>
    [Test]
    public void VerificarGanador_PokemonesDerrotados()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);
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
        Assert.That(batalla.BatallaSigue(), Is.EqualTo(false));
    }
    
    /// <summary>
    /// Este test verifica que si al menos un pokémon de cada equipo tiene su vida actual mayor a 0, la batalla continúa.
    /// </summary>
    [Test]
    public void VerificarGanador_Pokemones()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);
        
        jugador.ElegirPokemon(0).VidaActual = 100;
        jugador2.ElegirPokemon(0).VidaActual = 100;
        
        string resultado = batalla.VerificarGanador();
        
        Assert.That(resultado, Is.EqualTo("La batalla continúa"));
        Assert.That(batalla.BatallaSigue(), Is.EqualTo(true));
    }

    /// <summary>
    /// Este test verifica el turno de cada jugador.
    /// </summary>
    [Test]
    public void VerificarTurno()
    {
        jugador.TurnoActual = true;
        jugador2.TurnoActual = false;

        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);

        bool turno = batalla.VerificarTurno(jugador.NombreJugador);
        
        Assert.That(turno, Is.EqualTo(true));
        Assert.That(batalla.VerificarTurno(jugador2.NombreJugador), Is.EqualTo(false));
    }

    /// <summary>
    /// Este test verifica que si los dos jugadores atacan en una ronda, jugarán la segunda ronda de la batalla. Así
    /// sucesivamente hasta que alguno de los dos equipos quede con la vida de todos los pokemones en 0. 
    /// </summary>
    [Test]
    public void ObtenerTurnoActual_NumeroDeRonda()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);

        IPokemon pokemon = jugador.ElegirPokemon(0);
        jugador.PokemonActual = pokemon;
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);
        jugador2.PokemonActual = pokemonEnemigo;
        pokemon.AtaquesPorTipo();

        batalla.RealizarAtaque(jugador.NombreJugador, 0);
        Assert.That(batalla.jugador1Ataco, Is.EqualTo(true));

        pokemonEnemigo = jugador2.ElegirPokemon(1);
        jugador2.PokemonActual = pokemonEnemigo;
        pokemonEnemigo.AtaquesPorTipo();

        batalla.RealizarAtaque(jugador2.NombreJugador, 0);

        Assert.That(batalla.ObtenerTurnoActual(), Is.EqualTo(2));
    }

    /// <summary>
    /// En este test verificamos que al ingresar un índice no válido para cambiar de pokémon en la batalla,
    /// el pokemon actual será el que ya estaba batallando y el turno no cambia (sigue siendo turno del jugador
    /// que quiso ejecutar el cambio).
    /// </summary>
    [Test]
    public void CambiarPokemon_IndiceNoValidoYNoCambiaElTurno()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);

        IPokemon pokemon = jugador.ElegirPokemon(0);
        jugador.PokemonActual = pokemon;
        
        batalla.CambiarPokemon(jugador.NombreJugador, 7);
        string respuesta = batalla.VerificarFinTurno(jugador);
        
        Assert.That(jugador.PokemonActual, Is.EqualTo(pokemon));
        Assert.That(jugador.TurnoActual, Is.EqualTo(true));   //verificamos que el turno sigue siendo del jugador
        Assert.That(respuesta, Is.EqualTo($"{jugador.NombreJugador} es tu turno"));
    }

    /// <summary>
    /// Este test verifica que al ingresar un índice válido para cambiar de pokémon, se actualiza el pokémon actual
    /// y el turno se pierde.
    /// </summary>
    [Test]
    public void CambiarPokemon_IndiceValidoYCambiaTurno()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);
        IPokemon pokemon = jugador.ElegirPokemon(0);
        jugador.PokemonActual = pokemon;
        
        batalla.CambiarPokemon(jugador.NombreJugador, 1);
        IPokemon pokemonActual = jugador.ElegirPokemon(1);

        string respuesta = batalla.VerificarFinTurno(jugador);
        
        Assert.That(jugador.PokemonActual, Is.EqualTo(pokemonActual));
        Assert.That(jugador.TurnoActual, Is.EqualTo(false)); 
        Assert.That(respuesta, Is.EqualTo($"{jugador.NombreJugador} ha perdido su turno al cambiar de Pokémon."));
    }

    /// <summary>
    /// En esta prueba verificamos que el jugador ya está en la lista de espera y muestra la lista de espera.
    /// </summary>
    [Test]
    public void ListaDeEspera_YaIngresados()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);
        string mensaje = batalla.ListaDeEspera(jugador);
        
        Assert.That(mensaje, Is.EqualTo($"{jugador.NombreJugador} ya está agregado a la lista de espera"));
        Assert.That(batalla.MostrarListaDeEspera(), Is.EqualTo("Belén\nValentina\n"));
    }
    
    /// <summary>
    /// En esta prueba verificamos que el jugador logra unirse a la lista de espera y muestra la lista completa.
    /// </summary>
    [Test]
    public void ListaDeEspera_IngresaALaListaYMuestra()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);
        JugadorPrincipal jugador3 = new JugadorPrincipal("Pedro");
        string mensaje = batalla.ListaDeEspera(jugador3);
        
        Assert.That(mensaje, Is.EqualTo($"{jugador3.NombreJugador} fue agregado a la lista de espera"));
        Assert.That(batalla.MostrarListaDeEspera(), Is.EqualTo("Belén\nValentina\nPedro\n"));
    }

    [Test]
    public void IniciarBatallaListaDeEspera_VerificarEliminaJugadores()
    {
        BatallaFacade batalla = new BatallaFacade(jugador, jugador2);
        batalla.IniciarBatallaListaDeEspera();
        
        Assert.That(batalla.listaDeEspera.Count, Is.EqualTo(0));
        Assert.That(batalla.NotificarInicio(jugador), Is.EqualTo($"{jugador.NombreJugador} la batalla ha comenzado"));
        Assert.That(batalla.NotificarInicio(jugador2), Is.EqualTo($"{jugador2.NombreJugador} la batalla ha comenzado"));
        Assert.That(batalla.IniciarBatallaListaDeEspera(), Is.EqualTo($"No hay jugadores suficientes para comenzar una batalla"));
    }
    
}