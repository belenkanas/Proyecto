using Library;
using NUnit.Framework;

namespace Tests;

public class JugadorPrincipalTest
{
    public CatalogoPokemons catalogoPokemons;
    public CatalogoAtaques catalogoAtaques;
    public JugadorPrincipal jugador1;
    
    [SetUp]
    public void SetUp()
    {
        catalogoPokemons = new CatalogoPokemons();
        catalogoAtaques = new CatalogoAtaques();
        jugador1 = new JugadorPrincipal("Ana");
    }
    
    [Test]
    public void ElegirPokemonDelCatalogo_IndiceValido()
    {
        IPokemon pokemon = jugador1.ElegirDelCatalogo(3);
        
        Assert.That(("Pikachu"), Is.EqualTo(pokemon.Nombre));
    }

    [Test]
    public void ElegirPokemonDelCatalogo_IndiceNegativo()
    {
        IPokemon pokemon = jugador1.ElegirDelCatalogo(-1);
        
        Assert.That(null, Is.EqualTo(pokemon));
    }

    [Test]
    public void ElegirPokemonDelEquipo_IndiceValido()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(3);

        IPokemon pokemon = jugador1.ElegirPokemon(0);
        
        Assert.That(pokemon.Nombre, Is.EqualTo("Squirtle"));
    }

    [Test]
    public void ElegirPokemonDelEquipo_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(5);

        IPokemon pokemon = jugador1.ElegirPokemon(3);
        
        Assert.That(pokemon, Is.EqualTo(null));
    }

    [Test]
    public void MostrarTurnoJugador()
    {
        jugador1.TurnoActual = false;
        
        Assert.That(false, Is.EqualTo(jugador1.MostrarTurno()));
    }

    [Test]
    public void MostrarAtaquesDisponibles_IndiceValido()
    {
        jugador1.ElegirDelCatalogo(6);
        string ataques = jugador1.MostrarAtaquesDisponibles(0);

        string resultado = $"1. Nombre: Ascuas Tipo: Fuego Daño: 10 Es especial: False.\n" +
                           $"2. Nombre: Colmillo ígneo Tipo: Fuego Daño: 10 Es especial: False.\n" +
                           $"3. Nombre: Llamarada Tipo: Fuego Daño: 100 Es especial: True.\n" +
                           $"4. Nombre: Lanzallamas Tipo: Fuego Daño: 55 Es especial: True.\n";
        
        Assert.That(ataques, Is.EqualTo(resultado));
    }

    [Test]
    public void MostrarAtaquesDisponibles_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(6);
        string ataques = jugador1.MostrarAtaquesDisponibles(-1);
            
        string resultado = "Índice inválido";
        
        Assert.That(resultado, Is.EqualTo(ataques));
    }

    [Test]
    public void MostrarEquipoConPokemonsValido()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        string equipo = "Squirtle, Agua\nWartortle, Agua\nPikachu, Electrico\nMagneton, Electrico\nCharmander, Fuego\nCharizard, Fuego\n";
        
        Assert.That(jugador1.MostrarEquipo(), Is.EqualTo(equipo));
    }
    
    [Test]
    public void MostrarEquipoConPokemonsInvalido()
    {
        Assert.That(jugador1.MostrarEquipo(), Is.EqualTo(null));
    }

    [Test]
    public void PokemonesDerrotados_TodosSinVida()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(0).VidaActual = 0;
        jugador1.ElegirPokemon(1).VidaActual = 0;
        jugador1.ElegirPokemon(2).VidaActual = 0;
        jugador1.ElegirPokemon(3).VidaActual = 0;
        jugador1.ElegirPokemon(4).VidaActual = 0;
        jugador1.ElegirPokemon(5).VidaActual = 0;
        
        Assert.That(jugador1.PokemonesDerrotados, Is.EqualTo(true));
    }
    
    [Test]
    public void PokemonesDerrotados_AlMenosUnoConVida()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(0).VidaActual = 0;
        jugador1.ElegirPokemon(1).VidaActual = 0;
        jugador1.ElegirPokemon(2).VidaActual = 0;
        jugador1.ElegirPokemon(3).VidaActual = 0;
        jugador1.ElegirPokemon(4).VidaActual = 0;
        jugador1.ElegirPokemon(5).VidaActual = 100;
        
        Assert.That(jugador1.PokemonesDerrotados, Is.EqualTo(false));
    }

    [Test]
    public void CambiarPokemonBatalla_IndiceValidoYPokemonNoActual()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(1);
        string resultado = $"Ana ha cambiado de pokémon a Squirtle";
        
        Assert.That(resultado,Is.EqualTo(jugador1.CambiarPokemonBatalla(0)));
    }
    
    [Test]
    public void CambiarPokemonBatalla_IndiceValidoYPokemonActual()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(1);
        string resultado = $"Ingrese otro índice";
        
        Assert.That(resultado,Is.EqualTo(jugador1.CambiarPokemonBatalla(1)));
    }
    
    [Test]
    public void CambiarPokemonBatalla_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(1);
        string resultado = $"Indice del Pokemon inválido";
        
        Assert.That(resultado,Is.EqualTo(jugador1.CambiarPokemonBatalla(-1)));
    }
    
    
}