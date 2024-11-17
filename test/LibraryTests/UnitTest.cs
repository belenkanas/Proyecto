using Library;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Tests;

[TestFixture]
public class JugadorPrincipalTest
{
    public JugadorPrincipal jugador1;
    
    [SetUp]
    public void SetUp()
    {
        jugador1 = new JugadorPrincipal("Ana");
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
}

[TestFixture]
public class PokemonTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
    public CatalogoAtaques catalogoAtaques;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Juan");
        jugador2 = new JugadorPrincipal("Bob");
        catalogoAtaques = new CatalogoAtaques();
        
        jugador.ElegirDelCatalogo(3);
        jugador2.ElegirDelCatalogo(1);
        
    }

    /// <summary>
    /// Este test, verifica que al utilizar el método UsarAtaque(), el índice ingresado del ataque que se quiere
    /// utilizar sea válido. En este caso, es negtivo entonces está fuera de rango, y devuelve un mensaje diciendo que
    /// ese ataque no es válido.
    /// </summary>
    [Test]
    public void UsarAtaque_IndiceInvalido()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);
        
        string resultado = pokemon.UsarAtaque(-1, pokemonenemigo);

        Assert.That("El ataque no es válido", Is.EqualTo(resultado));
    }

    /// <summary>
    /// Para este caso, el índice es válido y el ataque es especial entonces verificamos que se calcule el daño esperado
    /// utilizando el ponderador.
    /// </summary>
    [Test]
    public void UsarAtaque_CalculoDeDañoConPonderador()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);

        pokemon.UsarAtaque(0, pokemonenemigo);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonenemigo.TipoPokemon);
        double dañoEsperado = pokemon.Ataque - pokemonenemigo.Defensa * ponderador;
        double vida = pokemonenemigo.VidaTotal - dañoEsperado;

        Assert.That(vida, Is.EqualTo(pokemonenemigo.VidaActual));
    }

    /// <summary>
    /// Este caso, verifica que para este turno los ataques especiales no están disponibles.
    /// Devuelve un mensaje mencionándolo.
    /// </summary>
    [Test]
    public void UsarAtaque_AtaqueEspecialNoDisponible()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);

        pokemon.turnoContadorEspecial = 1;

        pokemon.AtaquesPorTipo();
        jugador.ElegirAtaque(pokemon, pokemonenemigo, 3);

        string resultadoEsperado = pokemon.UsarAtaque(3, pokemonenemigo);

        string resultado = "El ataque especial no está disponible este turno.";

        Assert.That(resultado, Is.EqualTo(resultadoEsperado));
    }
    
    /// <summary>
    /// Y en este caso, el índice es válido pero el ataque no es especial entonces no utiliza el ponderador pero
    /// calcula el daño igualmente.
    /// </summary>
    [Test]
    public void UsarAtaque_AtaqueEspecialCalulcaDaño()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        
        pokemon.turnoContadorEspecial = 2;
        
        string resultado2 = pokemon.UsarAtaque(0, pokemonenemigo);
        string resultadoEsperado2 = "Pikachu usó Chispa y causó 7 puntos de daño.";
        
        Assert.That(resultado2, Is.EqualTo(resultadoEsperado2));
    }

    /// <summary>
    /// Este test, verifica el método RecibirDaño()
    /// Primero, comprueba que el pokémon no sea derrotado si su vida actual es mayor a 0 después de recibir el daño.
    /// También, comprueba que al aplicar un ataque su vida disminuye a 0 y el estado del pokémon pasa a ser Derrotado.
    /// </summary>
    [Test]
    public void RecibirDaño()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);
        
        pokemonenemigo.RecibirDaño(30);
        
        Assert.That(pokemonenemigo.Estado, Is.Not.EqualTo("Derrotado"));

        pokemon.AtaquesPorTipo();
        pokemon.turnoContadorEspecial = 2;
        pokemon.UsarAtaque(3, pokemonenemigo);
        
        Assert.That(pokemonenemigo.VidaActual, Is.EqualTo(0));
        Assert.That(pokemonenemigo.Estado, Is.EqualTo("Derrotado"));
    }

    /// <summary>
    /// Este test verifica que muestre la vida en el formato pedido.
    /// </summary>
    [Test]
    public void MostrarVida_Formato()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        pokemon.RecibirDaño(20);
        
        string esperado = $"{pokemon.VidaActual}/{pokemon.VidaTotal}";
        
        Assert.That("80/100", Is.EqualTo(esperado));
    }
    
    /// <summary>
    /// Este test, verifica que al utilizar el método AtaquesPorTipo() de un pokémon, muestre una lista con todos los
    /// ataques disponibles que tiene para ese tipo de pokémon, ya sean especiales o no, dependiendo del turno.
    /// Este caso, devolverá que la lista es incorrecta porque se agregó otro tipo que no es el del pokémon seleccionado.
    /// </summary>
    [Test]
    public void AgregaAtaquesDelMismoTipoDePokemon_AgregandoOtrosTipos()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);

        pokemon.AtaquesPorTipo();

        List<Ataque> ataques = new List<Ataque>()
        {
            new Ataque("Chispa", new Electrico(), 7, false),
            new Ataque("Impactrueno", new Electrico(), 8, false),
            new Ataque("Rayo", new Electrico(), 55, true),
            new Ataque("Trueno", new Electrico(), 100, true),
            new Ataque("Ascuas", new Fuego(), 10, false)
        };
        
        Assert.That(ataques, Is.Not.EqualTo(pokemon.Ataques));
    }
    
    /// <summary>
    /// Y este caso, la lista es correcta, ya que están todos los ataques disponibles para ese pokémon.
    /// </summary>
    [Test]
    public void AgregaAtaquesDelMismoTipoDePokemon()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);

        pokemon.AtaquesPorTipo();

        List<Ataque> ataques = new List<Ataque>()
        {
            new Ataque("Chispa", new Electrico(), 7, false),
            new Ataque("Impactrueno", new Electrico(), 8, false),
            new Ataque("Rayo", new Electrico(), 55, true),
            new Ataque("Trueno", new Electrico(), 100, true)
        };
        
        Assert.That(ataques.Count, Is.EqualTo(pokemon.Ataques.Count));
    }

    /// <summary>
    /// Esta prueba, comprueba que el método ObtenerAtaquesDisponibles() muestra los ataques disponibles dependiendo
    /// del turno, si ya utilizó un ataque especial debe esperar dos turnos patra volver a utilizarlo. Entonces, si el
    /// turno es impar los ataques disponibles serán todos menos los especiales.
    /// </summary>
    [Test]
    public void ObtenerAtaquesDisponibles_SinEspeciales()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.AtaquesPorTipo();
        
        pokemon.turnoContadorEspecial = 1;

        List<Ataque> ataques = pokemon.ObtenerAtaquesDisponibles();
        
        Assert.That("Chispa", Is.EqualTo(ataques[0].Nombre));  
        Assert.That("Impactrueno", Is.EqualTo(ataques[1].Nombre));
        
    }
    
    /// <summary>
    /// Y para esta prueba, verificamos que si el turno es par, muestre todos los ataques disponibles incluyendo los
    /// ataques especiales.
    /// </summary>
    [Test]
    public void ObtenerAtaquesDisponibles_ConEspeciales()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        
        pokemon.turnoContadorEspecial = 2;
        
        List<Ataque> ataques = pokemon.ObtenerAtaquesDisponibles();
        
        Assert.That("Chispa", Is.EqualTo(ataques[0].Nombre));  
        Assert.That("Impactrueno", Is.EqualTo(ataques[1].Nombre));
        Assert.That("Rayo", Is.EqualTo(ataques[2].Nombre));  
        Assert.That("Trueno", Is.EqualTo(ataques[3].Nombre));
    }
}

[TestFixture]
public class AtaqueTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Sol");
        jugador2 = new JugadorPrincipal("Ema");
    }

    /// <summary>
    /// Este test, verifica que el método CalcularDano() en la clase Ataque, calcula el daño esperado considerando el
    /// daño base, el ponderador y la defensa del pokémon enemigo. Al utilizar el método verificamos si dan el mismo
    /// resultado.
    /// </summary>
    [Test]
    public void CalcularDano_AtaqueEspecial()
    {
        jugador.ElegirDelCatalogo(2);
        jugador2.ElegirDelCatalogo(5);

        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        pokemon.turnoContadorEspecial = 2;
        pokemonEnemigo.DefensaEspecial = 40;

        double danoEsperado = pokemon.Ataques[3].DañoBase * 2.0 - pokemonEnemigo.DefensaEspecial;
        danoEsperado = Math.Max(danoEsperado, 0);

        double resultado = pokemon.Ataques[3].CalcularDaño(pokemon, pokemonEnemigo);
        
        Assert.That(resultado, Is.EqualTo(danoEsperado));
    }

    /// <summary>
    /// En el caso de que el ataque no sea especial, calculamos sin utilizar el ponderador.
    /// </summary>
    [Test]
    public void CalcularDano_NoEsEspecial()
    {
        jugador.ElegirDelCatalogo(2);
        jugador2.ElegirDelCatalogo(5);

        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        pokemonEnemigo.Defensa = 20;
        
        double danoEsperado = pokemon.Ataques[1].DañoBase - pokemonEnemigo.Defensa;
        danoEsperado = Math.Max(danoEsperado, 0);
        
        double resultado = pokemon.Ataques[1].CalcularDaño(pokemon, pokemonEnemigo);
        
        Assert.That(danoEsperado, Is.EqualTo(resultado));
    }
}

[TestFixture]
public class CatalogosTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Jorge");
        jugador2 = new JugadorPrincipal("Matias");
    }

    /// <summary>
    /// Esta prueba, verifica que agregue todos los ataques al catálogo de ataques.
    /// </summary>
    [Test]
    public void AgregarAtaques_VerificarSiAgregaTodos()
    {
        CatalogoAtaques CatalogoAtaques = new CatalogoAtaques();

        List<Ataque> ataquesAgregar = new List<Ataque>()
        {
            new Ataque("Acua Jet", new Agua(), 25, true),
            new Ataque("Burbuja", new Agua(), 25, false),
            new Ataque("Pistola de agua", new Agua(), 6, false),
            new Ataque("Hidrobomba", new Agua(), 90, true),

            new Ataque("Chispa", new Electrico(), 7, false),
            new Ataque("Impactrueno", new Electrico(), 8, false),
            new Ataque("Rayo", new Electrico(), 55, true),
            new Ataque("Trueno", new Electrico(), 100, true),

            new Ataque("Ascuas", new Fuego(), 10, false),
            new Ataque("Colmillo ígneo", new Fuego(), 10, false),
            new Ataque("Llamarada", new Fuego(), 100, true),
            new Ataque("Lanzallamas", new Fuego(), 55, true),

            new Ataque("Canto helado", new Hielo(), 15, false),
            new Ataque("Vaho gélido", new Hielo(), 9, false),
            new Ataque("Rayo hielo", new Hielo(), 65, true),
            new Ataque("Ventisca", new Hielo(), 100, true),
            
            new Ataque("Hoja afilada", new Planta(), 15, false),
            new Ataque("Látigo cepa", new Planta(), 7, false),
            new Ataque("Bomba germen", new Planta(), 40, true),
            new Ataque("Tormenta floral", new Planta(), 65, true),
            
            new Ataque("Lanzarrocas", new Roca(), 12, false), 
            new Ataque("Avalancha", new Roca(), 50, true),
            new Ataque("Roca afilada", new Roca(), 80, true),
            new Ataque("Tumba rocas", new Roca(), 30, true),
            
            new Ataque("Bofetón lodo", new Tierra(), 15, false),
            new Ataque("Disparo lodo", new Tierra(), 6, false),
            new Ataque("Bomba Fango", new Tierra(), 30, true),
            new Ataque("Terremoto", new Tierra(), 100, true)
        };
        
        Assert.That(ataquesAgregar.Count, Is.EqualTo(CatalogoAtaques.ataques.Count));

        for (int i = 0; i < CatalogoAtaques.ataques.Count; i++)
        {
            Assert.That(CatalogoAtaques.ataques[i].Nombre, Is.EqualTo(ataquesAgregar[i].Nombre));
            Assert.That(CatalogoAtaques.ataques[i].TipoAtaque.NombreTipo, Is.EqualTo(ataquesAgregar[i].TipoAtaque.NombreTipo));
            Assert.That(CatalogoAtaques.ataques[i].DañoBase, Is.EqualTo(ataquesAgregar[i].DañoBase));
            Assert.That(CatalogoAtaques.ataques[i].EsEspecial, Is.EqualTo(ataquesAgregar[i].EsEspecial));
        }
    }

    /// <summary>
    /// Este test, verifica que agregue todos los pokémones al catálogo de pokémones.
    /// </summary>
    [Test]
    public void AgregarPokemones()
    {
        CatalogoPokemons catalogoPokemons = new CatalogoPokemons();

        List<Pokemon> pokemones = new List<Pokemon>()
        {
            new Pokemon("Squirtle", new Agua(), 100),
            new Pokemon("Wartortle", new Agua(), 100),
            new Pokemon("Pikachu", new Electrico(), 100),
            new Pokemon("Magneton", new Electrico(), 100),
            new Pokemon("Charmander", new Fuego(), 100),
            new Pokemon("Charizard", new Fuego(), 100),
            new Pokemon("Articuno", new Hielo(), 100),
            new Pokemon("Vulpix de Alola", new Hielo(), 100),
            new Pokemon("Bulbasaur", new Planta(), 100),
            new Pokemon("Oddish", new Planta(), 100),
            new Pokemon("Geodude", new Roca(), 100),
            new Pokemon("Pupitar", new Roca(), 100),
            new Pokemon("Sandshrew", new Tierra(), 100),
            new Pokemon("Rhyhorn", new Tierra(), 100)
        };

        Assert.That(catalogoPokemons.Catalogo.Count, Is.EqualTo(pokemones.Count));
        
        for (int i = 0; i < catalogoPokemons.Catalogo.Count; i++)
        {
            Assert.That(catalogoPokemons.Catalogo[i].Nombre, Is.EqualTo(pokemones[i].Nombre));
            Assert.That(catalogoPokemons.Catalogo[i].TipoPokemon.NombreTipo, Is.EqualTo(pokemones[i].TipoPokemon.NombreTipo));
        }
    }

    /// <summary>
    /// Este test, comprueba que el método MostrarCatalogo() de la clase CatalogoPokemons() muestre todos los pokémones
    /// que hay en el catálogo, los que se han agregado en el método anterior.
    /// </summary>
    [Test]
    public void MostrarCatalogoPokemons_VerificarMuestreTodos()
    {
        CatalogoPokemons catalogoPokemons = new CatalogoPokemons();
        
        string muestra = "Seleccione 6 pokémons para su equipo con su número correspondiente: \n" +
                         "1. Squirtle\n" +
                         "2. Wartortle\n" +
                         "3. Pikachu\n" +
                         "4. Magneton\n" +
                         "5. Charmander\n" +
                         "6. Charizard\n" +
                         "7. Articuno\n" +
                         "8. Vulpix de Alola\n" +
                         "9. Bulbasaur\n" +
                         "10. Oddish\n" +
                         "11. Geodude\n" +
                         "12. Pupitar\n" +
                         "13. Sandshrew\n" +
                         "14. Rhyhorn\n";
        
        Assert.That(catalogoPokemons.MostrarCatalogo(), Is.EqualTo(muestra));
    }
}

[TestFixture]
public class EfectosItemsTest
{
    public JugadorPrincipal jugador;
    public Dormir dormir;
    public Envenenar envenenar;
    public Paralizar paralizar;
    public Quemar quemar;
    public CuraTotal cura;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("José");
        dormir = new Dormir();
        envenenar = new Envenenar();
        paralizar = new Paralizar();
        quemar = new Quemar();
        cura = new CuraTotal();
        jugador.ElegirDelCatalogo(4);
    }
    
    /// <summary>
    /// Este test verifica que al aplicar el efecto Dormir el estado del pokémon cambie a "Dormido" y que su vida
    /// disminuya un 5% en cada turno.
    /// </summary>
    [Test]
    public void DormirAplicarEfecto_VerificarEstadoYVidaActual()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        dormir.AplicarEfecto(pokemon);
        double vida = pokemon.VidaActual;
        double vidaEsperada = pokemon.VidaActual * 0.95;
        
        dormir.AplicarDañoPorTurno(pokemon);
        
        Assert.That(pokemon.Estado, Is.EqualTo("Dormido"));
        Assert.That(pokemon.VidaActual, Is.EqualTo(vidaEsperada));
    }

    /// <summary>
    /// Este test verifica que el estado del pokémon cambie a Envenenado cuando le apliquen el efecto y que su vida
    /// disminuya un 5% en cada turno.
    /// </summary>
    [Test]
    public void EnvenenarAplicarEfecto_VerificarEstadoYVidaActual()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        envenenar.AplicarEfecto(pokemon);
        double vida = pokemon.VidaActual;
        double vidaEsperada = pokemon.VidaActual * 0.95;
        
        envenenar.AplicarDañoPorTurno(pokemon);
        
        Assert.That(pokemon.Estado, Is.EqualTo("Envenenado"));
        Assert.That(pokemon.VidaActual, Is.EqualTo(vidaEsperada));
    }

    /// <summary>
    /// En esta prueba verificamos el estado del pokémon luego de aplicar el efecto.
    /// </summary>
    [Test]
    public void ParalizarAplicarEfecto_VerificarEstado()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        paralizar.AplicarEfecto(pokemon);
        
        Assert.That(pokemon.Estado, Is.EqualTo("Paralizado"));
    }

    /// <summary>
    /// En esta prueba verificamos que el estado del pokémon sea Quemado luego de aplicar el efecto ys u vida disminuya
    /// un 10% luego de cada turno.
    /// </summary>
    [Test]
    public void QuemarAplicarEfecto_VerificarEstado()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        quemar.AplicarEfecto(pokemon);
        double vida = pokemon.VidaActual;
        double vidaEsperada = pokemon.VidaActual * 0.90;
        
        quemar.AplicarDañoPorTurno(pokemon);
        
        Assert.That(pokemon.Estado, Is.EqualTo("Quemado"));
        Assert.That(pokemon.VidaActual, Is.EqualTo(vidaEsperada));
    }

    /// <summary>
    /// El método Usar() de la clase CuraTotal, restaura el estado del pokémon a Normal y elimina el efecto activo que tenía.
    /// Si el pokémon tiene cualquier efecto aplicado (menos Dormido), el efecto será eliminado y su estado cambia a Normal.
    /// </summary>
    [Test]
    public void CuraTotal_EfectoActivoNoNullYNoEsDormido()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        envenenar.AplicarEfecto(pokemon);
        
        cura.Usar(pokemon);
        
        Assert.That(pokemon.EfectoActivo, Is.Null);
        Assert.That(pokemon.Estado, Is.EqualTo("Normal"));
    }
    
    /// <summary>
    /// Para este caso, el pokémon no tiene un estado activo, entonces verificamos que su estado activo sea null y
    /// su estado sea Normal.
    /// </summary>
    [Test]
    public void CuraTotal_EfectoActivoNull()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        cura.Usar(pokemon);
        
        Assert.That(pokemon.EfectoActivo, Is.Null);
        Assert.That(pokemon.Estado, Is.EqualTo("Normal"));
    }
    
    /// <summary>
    /// Este caso, verifica que cuando el estado del pokémon sea Dormido no se puede aplicar la CuraTotal.
    /// Su estado y efecto activo no cambia.
    /// </summary>
    [Test]
    public void CuraTotal_EstadoDormido()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        dormir.AplicarEfecto(pokemon);
        
        cura.Usar(pokemon);
        
        Assert.That(pokemon.EfectoActivo.nombreEfecto, Is.EqualTo("Dormir"));
        Assert.That(pokemon.Estado, Is.EqualTo("Dormido"));
    }
    
    /// <summary>
    /// En esta prueba, comprobamos que al usar CuraTotal más veces del que está disponible, usosRestantes estará en 0
    /// y lanzará un mensaje diciendo que ya no se podrá usar más.
    /// </summary>
    [Test]
    public void CuraTotal_UtilizoTodosLosUsosDeCura()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        envenenar.AplicarEfecto(pokemon);
        cura.Usar(pokemon);
        quemar.AplicarEfecto(pokemon);
        cura.Usar(pokemon);
        paralizar.AplicarEfecto(pokemon);
        cura.Usar(pokemon);
        
        Assert.That(cura.usosRestantes, Is.EqualTo(0));
    }
}