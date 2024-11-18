using Library;
using NUnit.Framework;

namespace LibraryTests;

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