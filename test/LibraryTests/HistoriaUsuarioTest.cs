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


/// <summary>
/// Historia de usuario 2.
/// Como jugador, quiero ver los ataques disponibles de mis Pokemones para poder elegir en cada turno
/// </summary>
[TestFixture]
public class HistoriaUsuarioDosTest
{
    public CatalogoPokemons catalogo;
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
        
    [SetUp]
    public void SetUp()
    {
        catalogo = new CatalogoPokemons();
        jugador = new JugadorPrincipal("Dan");
        jugador2 = new JugadorPrincipal("Pepe");
        
        jugador.MostrarCatalogo();
        jugador.ElegirDelCatalogo(2);
        jugador.ElegirDelCatalogo(4);
        jugador.ElegirDelCatalogo(5);
        jugador.ElegirDelCatalogo(8);
        jugador.ElegirDelCatalogo(9);
        jugador.ElegirDelCatalogo(13);
        jugador.MostrarEquipo();
        
        jugador2.MostrarCatalogo();
        jugador2.ElegirDelCatalogo(2);
        
    }
    
    [Test]
    public void AtaquesDisponiblesPrimerTurno()
    {
        //Estamos en el primer turno.
        //Tenemos q ver q se muestre toda la lista de ataques de tipo Agua (que es la del tipo del Pokemon).
        string resultado = $"1. Nombre: Acua Jet Tipo: Agua Daño: 25 Es especial: True.\n" +
                           $"2. Nombre: Burbuja Tipo: Agua Daño: 25 Es especial: False.\n" +
                           $"3. Nombre: Pistola de agua Tipo: Agua Daño: 6 Es especial: False.\n" +
                           $"4. Nombre: Hidrobomba Tipo: Agua Daño: 90 Es especial: True.\n";
        
        Assert.That(jugador.MostrarAtaquesDisponibles(0), Is.EqualTo(resultado));
    }

    [Test]
    // Se debe asegurar que los ataques especiales se puedan seleccionar solo a cada 2 turnos.
    public void AtaquesDisponiblesSegundoTurno()
    {
        Pokemon pikachu = new Pokemon("Pikachu", new Electrico(), 100);
        
        //Luego de crear el pokemon, se le agregan los ataques (2 de ellos especiales)
        Ataque ataqueNormal1 = new Ataque("Impactrueno", new Electrico(), 50, false);
        Ataque ataqueNormal2 = new Ataque("Chispa", new Electrico(), 30, false);
        Ataque ataqueEspecial1 = new Ataque("Rayo", new Electrico(), 80, true);
        Ataque ataqueEspecial2 = new Ataque("Trueno", new Electrico(), 100, true);

        pikachu.Ataques.Add(ataqueNormal1);
        pikachu.Ataques.Add(ataqueNormal2);
        pikachu.Ataques.Add(ataqueEspecial1);
        pikachu.Ataques.Add(ataqueEspecial2);

        
        //Se comprueba que en el primer turno todos los ataques estén disponibles para su disposición.
        List<Ataque> ataquesDisponiblesTurno1 = pikachu.ObtenerAtaquesDisponibles();
        Assert.Contains(ataqueNormal1, ataquesDisponiblesTurno1);
        Assert.Contains(ataqueNormal2, ataquesDisponiblesTurno1);
        Assert.Contains(ataqueEspecial1, ataquesDisponiblesTurno1);
        Assert.Contains(ataqueEspecial2, ataquesDisponiblesTurno1);

        // Usar un ataque especial en el Turno 1
        pikachu.UsarAtaque(2, new Pokemon("Charmander", new Fuego(), 100)); 

        // Al usar un ataque, se cambia de turno.
        //Por lo qye ahora se prueba que los ataques disponibles sean únicamente los normales.
        List<Ataque> ataquesDisponiblesTurno2 = pikachu.ObtenerAtaquesDisponibles();
        List<Ataque> pruebaAtaques = new List<Ataque>();
        pruebaAtaques.Add(ataqueNormal1);
        pruebaAtaques.Add(ataqueNormal2);
        Assert.That(pruebaAtaques, Is.EqualTo(ataquesDisponiblesTurno2)); //Se comprueba que el único ataque disponible es el normal.
        

        // Usar un ataque normal en el Turno 2
        pikachu.UsarAtaque(0, new Pokemon("Charmander", new Fuego(), 100)); 

        // Se cambia de turno nuevamente, ahora deberían estar todos los ataques disponibles nuevamente
        List<Ataque> ataquesDisponiblesTurno3 = pikachu.ObtenerAtaquesDisponibles();
        Assert.Contains(ataqueNormal1, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueNormal2, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueEspecial1, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueEspecial2, ataquesDisponiblesTurno3);

    }
}

/// <summary>
/// Como jugador, quiero ver la cantidad de vida (HP) de mis Pokémons y de los Pokémons oponentes para saber cuánta salud tienen.
/// </summary>
public class HistoriaUsuarioTresTest
{
    public CatalogoPokemons catalogo;
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
    public CatalogoAtaques ataques;

    [SetUp]
    public void SetUp()
    {
        catalogo = new CatalogoPokemons();
        jugador = new JugadorPrincipal("Pablo");
        jugador2 = new JugadorPrincipal("Juan");
        
        jugador.MostrarCatalogo();
        jugador.ElegirDelCatalogo(3);
        
        jugador2.ElegirDelCatalogo(5);
    }

    [Test]
    
    //La vida de los Pokémons propios y del oponente se actualizan tras cada ataque.
    public void ActualizacionDeVidaEnCadaAtaque()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);

        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        string vidaAntesAtaque = pokemonEnemigo.MostrarVida();
        pokemon.UsarAtaque(0, pokemonEnemigo);
        string vidaDespuesAtaque = pokemonEnemigo.MostrarVida();
        
        Assert.That(vidaAntesAtaque, Is.Not.EqualTo(vidaDespuesAtaque));

        pokemon.UsarAtaque(1, pokemonEnemigo);
        string vidaDespuesSegundoAtaque = pokemonEnemigo.MostrarVida();
        
        Assert.That(vidaDespuesAtaque, Is.Not.EqualTo(vidaDespuesSegundoAtaque));
    }

    [Test]
    //La vida se muestra en formato numérico (ej. 20/50).
    public void MostrarVidaEnFormatoNumerico()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        string vida = pokemon.MostrarVida();

        string vidaEsperada = "100/100";
        
        Assert.That(vida, Is.EqualTo(vidaEsperada));
    }
}

/// <summary>
/// Como jugador, quiero atacar en mi turno y hacer daño basado en la efectividad de los tipos de Pokémon.
/// </summary>
public class HistoriaUsuarioCuatroTest
{
    public CatalogoPokemons CatalogoPokemons;
    public JugadorPrincipal JugadorPrincipal;
    public JugadorPrincipal JugadorPrincipal2;
    
    [SetUp]
    public void SetUp()
    {
        CatalogoPokemons = new CatalogoPokemons();
        JugadorPrincipal = new JugadorPrincipal("Ash");
        JugadorPrincipal2 = new JugadorPrincipal("Sean");
        
        JugadorPrincipal.MostrarCatalogo();
        JugadorPrincipal.ElegirDelCatalogo(4);
        JugadorPrincipal.ElegirDelCatalogo(8);
        
        JugadorPrincipal2.MostrarCatalogo();
        JugadorPrincipal2.ElegirDelCatalogo(3);
        JugadorPrincipal2.ElegirDelCatalogo(9);
    }

    [Test]
    public void SeleccionarAtaqueBasadoEnEfectividad()
    {
        IPokemon pokemon = JugadorPrincipal.ElegirPokemon(0);
        IPokemon pokemonEnemigo = JugadorPrincipal2.ElegirPokemon(1);

        pokemon.AtaquesPorTipo();
        Ataque ataque = pokemon.Ataques[1];

        double ponderador = ataque.TipoAtaque.Ponderador(pokemonEnemigo.TipoPokemon);
        double danoBase = ataque.CalcularDaño(pokemon, pokemonEnemigo);
        double danoTotal = danoBase * ponderador;

        string resultado = $"Magneton usó Impactrueno y causó {danoTotal} puntos de daño.";

        Assert.That(resultado, Is.EqualTo(pokemon.UsarAtaque(1, pokemonEnemigo)));
    }
}

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

        batalla = new BatallaFacade(jugador, jugador2);
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
        jugador.ElegirPokemon(0).VidaActual = 0;
        jugador.ElegirPokemon(1).VidaActual = 0;
        
        string ganador = batalla.VerificarGanador();

        string resultadoJ2 = $"{jugador.NombreJugador} ha sido derrotado " +
                           $"{jugador2.NombreJugador} GANÓ";
        
        Assert.That(ganador, Is.EqualTo(resultadoJ2));
    }
}

/// <summary>
/// Como jugador, quiero poder cambiar de Pokémon durante una batalla.
/// </summary>
public class HistoriaUsuarioSieteTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
    public BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Asia");
        jugador2 = new JugadorPrincipal("Robert");
        batalla = new BatallaFacade(jugador, jugador2);
        
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
        batalla.CambiarPokemon(jugador.NombreJugador, 1);       //Cambia a Charizard
        
        Assert.That("Charizard", Is.EqualTo(jugador.PokemonActual.Nombre));
    }

    [Test]
    public void PierdeTurno()
    {
        jugador.PokemonActual = jugador.EquipoPokemons[0];

        batalla.CambiarPokemon(jugador.NombreJugador, 1);

        Assert.That(jugador.TurnoActual, Is.EqualTo(false));
    }
}

/// <summary>
/// Como entrenador, quiero poder usar un ítem durante una batalla.
/// Al usar el ítem se pierde el turno
/// </summary>
public class HistoriaUsuarioOcho
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal oponente;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Belen");
        oponente = new JugadorPrincipal("Valentina");

        
        jugador.ElegirDelCatalogo(2); // Squirtle
        oponente.ElegirDelCatalogo(4); // Charmander
    }

    [Test]
    public void UsarItem_PierdeTurno()
    {
        
        IPokemon pokemon = jugador.ElegirPokemon(0);
        double vidaAntes = pokemon.VidaActual;

        
        Console.WriteLine(jugador.MostrarInventario());
        jugador.UsarItem(0, pokemon); // Usa la primera poción en el inventario

        //Comprobar que se pierde el turno luego de usar el ítem.
        Assert.IsFalse(jugador.TurnoActual);
    } 
}

/// <summary>
/// Como entrenador, quiero unirme a la lista de jugadores esperando por un oponente.
/// </summary>
public class HistoriaUsuarioNueveTest
{
    public JugadorPrincipal entrenador;
    public JugadorPrincipal entrenador2;
    public BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new JugadorPrincipal("Martin");
        entrenador2 = new JugadorPrincipal("Clara");
        batalla = new BatallaFacade(entrenador, entrenador2);
        
    }

    [Test]
    // El jugador recibe un mensaje indicandole que está en la lista de espera
    public void ListaDeEsperaJugadores()
    {
        string esperado = batalla.ListaDeEspera(entrenador);

        string mensaje = $"{entrenador.NombreJugador} ya está agregado a la lista de espera";
        
        Assert.That(mensaje, Is.EqualTo(esperado));
    }
}


/// <summary>
/// Se quiere probar que al entrnador le deje ver la lista de jugadores que se unieron a la lista.
/// </summary>
public class HistoriaUsuarioDiezTest
{
    public JugadorPrincipal entrenador;
    public JugadorPrincipal entrenador2;
    public BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new JugadorPrincipal("Mateo");
        entrenador2 = new JugadorPrincipal("Belén");
        batalla = new BatallaFacade(entrenador, entrenador2);
        
    }

    [Test]
    public void MostrarListaDeEsperaPorOponente()
    {
        JugadorPrincipal jugador = new JugadorPrincipal("Sofia");
        batalla.ListaDeEspera(jugador);

        string esperado = batalla.MostrarListaDeEspera();

        string mensaje = "Mateo\nBelén\nSofia\n";
        
        Assert.That(mensaje, Is.EqualTo(esperado));
    }
}

/// <summary>
///  Como entrenador, quiero iniciar una ballata con un jugador que está esperando por un oponente.
/// </summary>
public class HistoriaUsuarioOnceTest
{
    public JugadorPrincipal entrenador;
    public JugadorPrincipal entrenador2;
    public BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new JugadorPrincipal("Lola");
        entrenador2 = new JugadorPrincipal("Pedro");
        batalla = new BatallaFacade(entrenador, entrenador2);
        
    }

    [Test]
    public void NotificarInicio()
    {
        Random random = new Random();
        batalla.IniciarBatallaListaDeEspera(random);

        string muestra = $"{entrenador.NombreJugador} la batalla ha comenzado";

        Assert.That(muestra, Is.EqualTo(batalla.NotificarInicio(entrenador)));
        
        string muestra2 = $"{entrenador2.NombreJugador} la batalla ha comenzado";

        Assert.That(muestra2, Is.EqualTo(batalla.NotificarInicio(entrenador2)));
    }
    
    [Test]
    public void PrimerTurnoAleatorio()
    {
        Random random = new Random();
        batalla.IniciarBatallaListaDeEspera(random);
        
        Assert.That(entrenador.TurnoActual || entrenador2.TurnoActual, Is.True);
    }
}