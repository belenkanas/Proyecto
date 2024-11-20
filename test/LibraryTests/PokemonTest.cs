using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class PokemonTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Juan");
        jugador2 = new JugadorPrincipal("Bob");
        
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