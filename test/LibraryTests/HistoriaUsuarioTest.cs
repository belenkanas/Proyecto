using NUnit.Framework;

namespace Library.Tests;


[TestFixture]
public class HistoriaUsuarioTest
{
    public JugadorPrincipal jugador1;
    public JugadorPrincipal jugador2;
    public BatallaFacade batalla;

    [SetUp]
    public void SetUpUno()
    {
        jugador1 = new JugadorPrincipal("Ana");
        jugador2 = new JugadorPrincipal("Belén");
        batalla = new BatallaFacade(jugador1, jugador2);
        
        jugador1.MostrarCatalogo();
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(7);
        jugador1.ElegirDelCatalogo(9);
        jugador1.ElegirDelCatalogo(12);
        jugador1.ElegirDelCatalogo(14);
        jugador1.MostrarEquipo();
        
        jugador2.ElegirDelCatalogo(2);
        jugador2.ElegirDelCatalogo(4);
        jugador2.ElegirDelCatalogo(6);
        jugador2.ElegirDelCatalogo(10);
        jugador2.ElegirDelCatalogo(11);
        jugador2.ElegirDelCatalogo(13);
    }
    
    /// <summary>
    /// Historia de Usuario 1.
    /// Verificamos que el jugador puede seleccionar 6 Pokémons de una lista o catálogo y luego,
    /// se muestre en pantalla el equipo elegido.
    /// </summary>
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
    
    /// <summary>
    /// Verificamos que puede elegir hasta 6 pokémons para formar su equipo.
    /// </summary>
    [Test]
    public void SeleccionarEquipo()
    { 
        Assert.That(6, Is.EqualTo(jugador1.EquipoPokemons.Count));
    }

    /// <summary>
    /// Historia de Usuario 2.
    /// Verificamos que el jugador vea los ataques disponibles de sus Pokemones para poder elegir en cada turno.
    /// </summary>
    [Test]
    public void AtaquesDisponiblesPrimerTurno()
    {
        //Estamos en el primer turno.
        //Tenemos q ver q se muestre toda la lista de ataques de tipo Agua (que es la del tipo del Pokemon).
        string resultado = $"1. Nombre: Acua Jet Tipo: Agua Daño: 25 Es especial: True.\n" +
                           $"2. Nombre: Burbuja Tipo: Agua Daño: 25 Es especial: False.\n" +
                           $"3. Nombre: Pistola de agua Tipo: Agua Daño: 6 Es especial: False.\n" +
                           $"4. Nombre: Hidrobomba Tipo: Agua Daño: 90 Es especial: True.\n";
        
        Assert.That(jugador1.MostrarAtaquesDisponibles(0), Is.EqualTo(resultado));
    }

    /// <summary>
    /// Se debe asegurar que los ataques especiales se puedan seleccionar solo cada 2 turnos.
    /// </summary>
    [Test]
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
        pikachu.UsarAtaque(2, new Pokemon("Charmander", new Fuego(), 100), jugador1); 

        // Al usar un ataque, se cambia de turno.
        //Por lo qye ahora se prueba que los ataques disponibles sean únicamente los normales.
        List<Ataque> ataquesDisponiblesTurno2 = pikachu.ObtenerAtaquesDisponibles();
        List<Ataque> pruebaAtaques = new List<Ataque>();
        pruebaAtaques.Add(ataqueNormal1);
        pruebaAtaques.Add(ataqueNormal2);
        Assert.That(pruebaAtaques, Is.EqualTo(ataquesDisponiblesTurno2)); //Se comprueba que el único ataque disponible es el normal.
        

        // Usar un ataque normal en el Turno 2
        pikachu.UsarAtaque(0, new Pokemon("Charmander", new Fuego(), 100), jugador1); 

        // Se cambia de turno nuevamente, ahora deberían estar todos los ataques disponibles nuevamente
        List<Ataque> ataquesDisponiblesTurno3 = pikachu.ObtenerAtaquesDisponibles();
        Assert.Contains(ataqueNormal1, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueNormal2, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueEspecial1, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueEspecial2, ataquesDisponiblesTurno3);
    }

    /// <summary>
    /// Historia de Usuario 3.
    /// Verificamos que la vida de los Pokémons propios y del oponente se actualicen tras cada ataque.
    /// </summary>
    [Test]
    public void ActualizacionDeVidaEnCadaAtaque()
    {
        IPokemon pokemon = jugador1.ElegirPokemon(1);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(1);
        
        pokemon.AtaquesPorTipo();
        string vidaAntesAtaque = pokemonEnemigo.MostrarVida();
        pokemon.UsarAtaque(0, pokemonEnemigo, jugador1);
        string vidaDespuesAtaque = pokemonEnemigo.MostrarVida();
        
        Assert.That(vidaAntesAtaque, Is.Not.EqualTo(vidaDespuesAtaque));
        pokemon.UsarAtaque(1, pokemonEnemigo, jugador1);
        string vidaDespuesSegundoAtaque = pokemonEnemigo.MostrarVida();
        
        Assert.That(vidaDespuesAtaque, Is.Not.EqualTo(vidaDespuesSegundoAtaque));
    }

    /// <summary>
    /// Verificamos que la vida se muestre en formato numérico (ej. 20/50).
    /// </summary>
    [Test]
    public void MostrarVidaEnFormatoNumerico()
    {
        IPokemon pokemon = jugador1.ElegirPokemon(0);
        string vida = pokemon.MostrarVida();

        string vidaEsperada = "100/100";
        
        Assert.That(vida, Is.EqualTo(vidaEsperada));
    }


    /// <summary>
    /// Historia de Usuario 4.
    /// Verificamos que como jugador, quiero atacar en mi turno y hacer daño basado en la efectividad de
    /// los tipos de Pokémon.
    /// </summary>
    [Test]
    public void SeleccionarAtaqueBasadoEnEfectividad()
    {
        IPokemon pokemon = jugador1.ElegirPokemon(0);
        IPokemon pokemonEnemigo = jugador1.ElegirPokemon(1);

        pokemon.AtaquesPorTipo();
        Ataque ataque = pokemon.Ataques[1];

        double ponderador = ataque.TipoAtaque.Ponderador(pokemonEnemigo.TipoPokemon);
        double danoBase = ataque.CalcularDaño(pokemon, pokemonEnemigo);
        double danoTotal = danoBase * ponderador;

        string resultado = $"Squirtle usó Burbuja y causó {danoTotal} puntos de daño.";

        Assert.That(resultado, Is.EqualTo(pokemon.UsarAtaque(1, pokemonEnemigo, jugador1)));
    }
    
    /// <summary>
    /// Historia de Usuario 5.
    /// Verificamos que se muestre en pantalla de quién es el turno para estar seguro de cuándo atacar o esperar.
    /// </summary>
    [Test]
    public void MostrarTurnoActual()
    {
        jugador1.TurnoActual = true;
        jugador2.TurnoActual = false;
        
        Assert.That(true, Is.EqualTo(jugador1.MostrarTurno()));
        Assert.That(false, Is.EqualTo(jugador2.MostrarTurno()));
        
        IPokemon pokemon = jugador1.ElegirPokemon(1);
        IPokemon pokemonE = jugador2.ElegirPokemon(0);
        jugador1.MostrarAtaquesDisponibles(1);

        pokemon.UsarAtaque(1, pokemonE, jugador1);
        
        Assert.That(false, Is.EqualTo(jugador1.MostrarTurno()));
    }
    
    /// <summary>
    /// Historia de Usuario 6.
    /// Verificamos que la batalla se termine automáticamente cuando todos los Pokémons del oponente alcanza 0 de vida.
    /// </summary>
    [Test]
    public void DerrotaCuandoTotalPokemonsVidaCero()
    {
        foreach (IPokemon pokemon in jugador2.EquipoPokemons)
        {
            pokemon.VidaActual = 0; //Forzamos a que todos los pokemones del equipo estén derrotados.
        }

        batalla.VerificarGanador();
        
        Assert.IsFalse(batalla.BatallaSigue());
    }

    /// <summary>
    /// Verificamos que se muestre un mensaje indicando el ganador de la batalla.
    /// </summary>
    [Test]
    public void MensajeGanador()
    {
        jugador1.ElegirPokemon(0).VidaActual = 0;
        jugador1.ElegirPokemon(1).VidaActual = 0;
        jugador1.ElegirPokemon(2).VidaActual = 0;
        jugador1.ElegirPokemon(3).VidaActual = 0;
        jugador1.ElegirPokemon(4).VidaActual = 0;
        jugador1.ElegirPokemon(5).VidaActual = 0;
        
        string ganador = batalla.VerificarGanador();

        string resultadoJ2 = $"{jugador1.NombreJugador} ha sido derrotado " +
                           $"{jugador2.NombreJugador} GANÓ";
        
        Assert.That(ganador, Is.EqualTo(resultadoJ2));
    }
    
    /// <summary>
    /// Historia de Usuario 7.
    /// Verificamos que al cambiar de pokémon durante la batalla se pierde automáticamente el turno.
    /// </summary>
    [Test]
    public void CambiarPokemon()
    {
        jugador1.PokemonActual = jugador1.ElegirPokemon(0);
        batalla.CambiarPokemon(jugador1.NombreJugador, 1);       //Cambia a Charizard
        
        Assert.That("Charmander", Is.EqualTo(jugador1.PokemonActual.Nombre));
        Assert.That(jugador1.TurnoActual, Is.EqualTo(false));
    }
    
    /// <summary>
    /// Historia de Usuario 8.
    /// Verificamos que al utilizar un item durante la batalla el jugador pierde su turno.
    /// </summary>
    [Test]
    public void UsarItem_PierdeTurno()
    {
        IPokemon pokemon = jugador1.ElegirPokemon(0);
        pokemon.VidaActual = 0;
        
        jugador1.UsarItem(0, pokemon); // Usa la primera poción en el inventario

        //Comprobar que se pierde el turno luego de usar el ítem.
        Assert.IsFalse(jugador1.TurnoActual);
    } 
    
    /// <summary>
    /// Historia de Usuario 9.
    /// Verificamos que al unirse a la lista de espera, el jugador reciba un mensaje de confirmación.
    /// </summary>
    [Test]
    public void ListaDeEsperaJugadores()
    {
        string esperado = batalla.ListaDeEspera(jugador1);

        string mensaje = $"{jugador1.NombreJugador} ya está agregado a la lista de espera";
        
        Assert.That(mensaje, Is.EqualTo(esperado));
    }

    /// <summary>
    /// Historia de Usuario 10.
    /// Verificamos que se muestre la lista de espera con los jugadores que se unieron.
    /// </summary>
    [Test]
    public void MostrarListaDeEsperaPorOponente()
    {
        JugadorPrincipal jugador = new JugadorPrincipal("Sofia");
        batalla.ListaDeEspera(jugador);

        string esperado = batalla.MostrarListaDeEspera();

        string mensaje = "Ana\nBelén\nSofia\n";
        
        Assert.That(mensaje, Is.EqualTo(esperado));
    }
    
    /// <summary>
    /// Historia de Usuario 11.
    /// Verificamos que al iniciar una batalla se le notifique a ambos jugadores.
    /// </summary>
    [Test]
    public void NotificarInicio()
    {
        Random random = new Random();
        batalla.IniciarBatallaListaDeEspera(random);

        string muestra = $"{jugador1.NombreJugador} la batalla ha comenzado";

        Assert.That(muestra, Is.EqualTo(batalla.NotificarInicio(jugador1)));
        
        string muestra2 = $"{jugador2.NombreJugador} la batalla ha comenzado";

        Assert.That(muestra2, Is.EqualTo(batalla.NotificarInicio(jugador2)));
    }
    
    /// <summary>
    /// El primer turno se determina aleatoriamente.
    /// </summary>
    [Test]
    public void PrimerTurnoAleatorio()
    {
        Random random = new Random();
        batalla.IniciarBatallaListaDeEspera(random);
        
        Assert.That(jugador1.TurnoActual || jugador2.TurnoActual, Is.True);
    }
}
