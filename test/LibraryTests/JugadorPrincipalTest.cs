using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class JugadorPrincipalTest
{
    public JugadorPrincipal jugador1;
    public Envenenar envenenar;
    
    [SetUp]
    public void SetUp()
    {
        jugador1 = new JugadorPrincipal("Ana");
        envenenar = new Envenenar();
    }
    
    /// <summary>
    /// Este test del método ElegirPokemonDelCatalogo() verifica que cuando se elige un pokémon del catálogo a través
    /// de su índice, devuelva el pokémon esperado ya que su índice es válido.
    /// </summary>
    [Test]
    public void ElegirPokemonDelCatalogo_IndiceValido()
    {
        IPokemon pokemon = jugador1.ElegirDelCatalogo(3);
        
        Assert.That(("Pikachu"), Is.EqualTo(pokemon.Nombre));
    }

    /// <summary>
    /// Este test verifica que al ingresar un índice fuera del rango esperado para elegir tu pokémon, devuelva null.
    /// </summary>
    [Test]
    public void ElegirPokemonDelCatalogo_IndiceNegativo()
    {
        IPokemon pokemon = jugador1.ElegirDelCatalogo(-1);
        
        Assert.That(null, Is.EqualTo(pokemon));
    }

    /// <summary>
    /// Verificamos que no puede agregar más de 6 pokémones a su equipo.
    /// </summary>
    [Test]
    public void ElegirPokemonDelCatalogo_MasDe6NoDeja()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);
        
        Assert.That(jugador1.ElegirDelCatalogo(7), Is.EqualTo(null));
    }

    /// <summary>
    /// Verifica que el jugador pueda elegir el pokémon que quiera de su equipo por el índice
    /// en este caso, el índice es válido y devuelve el pokémon elegido.
    /// </summary>
    [Test]
    public void ElegirPokemonDelEquipo_IndiceValido()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(3);

        IPokemon pokemon = jugador1.ElegirPokemon(0);
        
        Assert.That(pokemon.Nombre, Is.EqualTo("Squirtle"));
    }

    /// <summary>
    /// En este caso, el índice está fuera del rango permitido entonces devolverá null.
    /// </summary>
    [Test]
    public void ElegirPokemonDelEquipo_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(5);

        IPokemon pokemon = jugador1.ElegirPokemon(3);
        
        Assert.That(pokemon, Is.EqualTo(null));
    }

    /// <summary>
    /// Muestra el turno actual del jugador.
    /// </summary>
    [Test]
    public void MostrarTurnoJugador()
    {
        jugador1.TurnoActual = false;
        
        Assert.That(false, Is.EqualTo(jugador1.MostrarTurno()));
    }

    /// <summary>
    /// Verifica que muestre correctamente los ataques disponibles del pokémon elegido por su índice para la batalla
    /// En este caso, el índice es válido, entonces devuelve una lista de ataques disponibles para ese pokémon.
    /// </summary>
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

    /// <summary>
    /// Para este caso, el índice del pokémon elegido es inválido y devuelve el mensaje de error.
    /// </summary>
    [Test]
    public void MostrarAtaquesDisponibles_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(6);
        string ataques = jugador1.MostrarAtaquesDisponibles(-1);
            
        string resultado = "Índice inválido";
        
        Assert.That(resultado, Is.EqualTo(ataques));
    }

    /// <summary>
    /// Verifica que muestre todos los pokémones seleccionados para formar el equipo de 6 a través de su índice.
    /// </summary>
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
    
    /// <summary>
    /// Para este caso, no hay pokémones en el equipo entonces devuelve null.
    /// </summary>
    [Test]
    public void MostrarEquipoConPokemonsInvalido()
    {
        Assert.That(jugador1.MostrarEquipo(), Is.EqualTo(null));
    }

    /// <summary>
    /// En este test, se prueba que todos los pokémones del equipo tienen su vida en 0/100 entonces el método
    /// PokemonesDerrotados() devuelve true y se termina la batalla asumiendo de ganador el jugador oponente.
    /// </summary>
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
    
    /// <summary>
    /// Si al menos uno de los pokémones del equipo tiene su vida > 0, devuelve false que significa que la batalla sigue. 
    /// </summary>
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

    /// <summary>
    /// Esta prueba, verifica que, al querer cambiar de pokémon en una batalla, el índice ingresado sea válido
    /// (que no sea el del pokémon que está en batalla y que esté dentro del rango). También verifica que el jugador
    /// utilizó su turno haciendo el cambio.
    /// </summary>
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
        Assert.That(jugador1.TurnoActual, Is.EqualTo(false));
    }
    
    /// <summary>
    /// En este caso, el jugador ingresa el índice del pokémon que está actualmente en la batalla entonces devolverá un
    /// mensaje de que deberá ingresar otro índice.
    /// </summary>
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
    
    /// <summary>
    /// Y para este caso, el índice ingresado está fuera de rango entonces devolverá un mensaje comentando que el
    /// índice del pokémon es inválido.
    /// </summary>
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

    /// <summary>
    /// Este test verifica que si un jugador desea usar un item, como Cura Total, devuelva que el turno del jugador
    /// ya lo perdió utilizando el item y el pokémon ya no tiene el efecto activo.
    /// </summary>
    [Test]
    public void UsarItem_IndiceValidoCuraTotal()
    {
        jugador1.ElegirDelCatalogo(2);
        IPokemon pokemon = jugador1.ElegirPokemon(0);
        envenenar.AplicarEfecto(pokemon);
        jugador1.UsarItem(2, pokemon);
        
        Assert.That(pokemon.Estado, Is.EqualTo("Normal"));
        Assert.That(jugador1.TurnoActual, Is.EqualTo(false));
    }
    
    /// <summary>
    /// Este test verifica que si un jugador desea usar un item, como Revivir, devuelva que el turno del jugador
    /// ya lo perdió utilizando el item y la vida actual del pokémon aumento un 50%.
    /// </summary>
    [Test]
    public void UsarItem_IndiceValidoRevivir()
    {
        jugador1.ElegirDelCatalogo(2);
        IPokemon pokemon = jugador1.ElegirPokemon(0);
        pokemon.VidaActual = 0;
        double vida = jugador1.UsarItem(1, pokemon);
        double vidaEsperada = pokemon.VidaTotal * 0.5;
        
        Assert.That(jugador1.TurnoActual, Is.EqualTo(false));
        Assert.That(vida, Is.EqualTo(vidaEsperada));
    }
    
    /// <summary>
    /// Este test verifica que si un jugador desea usar un item, como Super Pocion, devuelva que el turno del jugador
    /// ya lo perdió utilizando el item y la vida actual del pokémon aumente dependiendo de su vida actual anterior.
    /// </summary>
    [Test]
    public void UsarItem_IndiceValidoPocion()
    {
        jugador1.ElegirDelCatalogo(3);
        IPokemon pokemon = jugador1.ElegirPokemon(0);
        pokemon.VidaActual = 10;
        double vida = jugador1.UsarItem(0, pokemon);
        double vidaEsperada = pokemon.VidaActual + 70;
        
        Assert.That(jugador1.TurnoActual, Is.EqualTo(false));
        Assert.That(vida, Is.EqualTo(vidaEsperada));
    }

    /// <summary>
    /// Verificamos que muestre todos los items del inventario, Super Pocion, Revivir y Cura Total
    /// </summary>
    [Test]
    public void MostrarInventarioItems()
    {
        string inventario = jugador1.MostrarInventario();

        string resultadoEsperado = "Inventario de Items:\n1. Super Pocion \n2. Revivir \n3. Cura Total \n";
        
        Assert.That(inventario, Is.EqualTo(resultadoEsperado));
    }

    /// <summary>
    /// Verificamos el turno del jugador para obtener si tiene la posibilidad de rendirse o no. En este caso, si
    /// puede rendirse porque esta en su turno.
    /// </summary>
    [Test]
    public void Rendirse_TurnoTrue()
    {
        jugador1.TurnoActual = true;
        
        Assert.That(jugador1.Rendirse(), Is.EqualTo(true));
    }
    
    /// <summary>
    /// En este caso, no puede rendirse porque es el turno del otro oponente.
    /// </summary>
    [Test]
    public void Rendirse_TurnoFalse()
    {
        jugador1.TurnoActual = false;
        
        Assert.That(jugador1.Rendirse(), Is.EqualTo(false));
    }
}