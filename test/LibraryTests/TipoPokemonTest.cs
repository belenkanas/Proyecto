using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class TipoPokemonTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Gabriel");
        jugador2 = new JugadorPrincipal("Martín");
    }

    /// <summary>
    /// Este test verifica que el pokémon de tipo Agua al atacar a otro pokémon de tipo Fuego utiliza el ponderador.
    /// </summary>
    [Test]
    public void Agua_PonderadorOponenteTipoFuego()
    {
        jugador.ElegirDelCatalogo(1);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(5);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(2.0, Is.EqualTo(ponderador));
    }

    /// <summary>
    /// Este test verifica que el pokémon de tipo Agua al atacar a otro pokémon de tipo Planta utiliza el ponderador.
    /// </summary>
    [Test]
    public void Agua_PonderadorOponenteTipoPlanta()
    {
        jugador.ElegirDelCatalogo(1);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(9);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0.5, Is.EqualTo(ponderador));
    }

    /// <summary>
    /// Este test verifica que el pokémon de tipo Agua al atacar a otro pokémon que no sea de tipo Fuego, Hielo, Agua,
    /// Planta o Electrico, el ponderador es neutro (1.0).
    /// </summary>
    [Test]
    public void Agua_PonderadorOponenteNeutro()
    {
        jugador.ElegirDelCatalogo(1);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(13);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(1.0, Is.EqualTo(ponderador));
    }

    /// <summary>
    /// Este test verifica que un pokémon de tipo Electrico es inmune a otro de tipo Electrico, su ponderador será 0.
    /// </summary>
    [Test]
    public void Electrico_PonderadorOponenteElectrico()
    {
        jugador.ElegirDelCatalogo(3);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(4);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0, Is.EqualTo(ponderador));
    }

    /// <summary>
    /// Este test verifica que un pokémon de tipo Electrico es débil frente a otro de tipo Tierra, su ponderador será 0.5.
    /// </summary>
    [Test]
    public void Electrico_PonderadorOponenteTierra()
    {
        jugador.ElegirDelCatalogo(3);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(13);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0.5, Is.EqualTo(ponderador));
    }

    /// <summary>
    /// Este test verifica que el pokémon de tipo Electrico al atacar a otro pokémon que no sea de tipo Electrico o
    /// Tierra, el ponderador es neutro (1.0).
    /// </summary>
    [Test]
    public void Electrico_PonderadorOponenteNeutro()
    {
        jugador.ElegirDelCatalogo(3);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(10);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(1.0, Is.EqualTo(ponderador));
    }

    /// <summary>
    /// Este test verifica que un pokémon de tipo Fuego es fuerte frente a otro de tipo Fuego, su ponderador será 2.0.
    /// </summary>
    [Test]
    public void Fuego_PonderadorOponenteFuego()
    {
        jugador.ElegirDelCatalogo(5);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(5);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(2.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Fuego es débil frente a otro de tipo Roca, su ponderador será 0.5.
    /// </summary>
    [Test]
    public void Fuego_PonderadorOponenteRoca()
    {
        jugador.ElegirDelCatalogo(5);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(11);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0.5, Is.EqualTo(ponderador));   
    }
    
    /// <summary>
    /// Este test verifica que el pokémon de tipo Fuego al atacar a otro pokémon que no sea de tipo Fuego, Planta,
    /// Tierra, Agua o Roca, el ponderador es neutro (1.0).
    /// </summary>
    [Test]
    public void Fuego_PonderadorOponenteNeutro()
    {
        jugador.ElegirDelCatalogo(5);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(7);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(1.0, Is.EqualTo(ponderador));
    }

    /// <summary>
    /// Este test verifica que el pokémon de tipo Hielo al atacar a otro pokémon que no sea de tipo Fuego, Hielo o
    /// Roca, el ponderador es neutro (1.0).
    /// </summary>
    [Test]
    public void Hielo_PonderadorOponenteNeutro()
    {
        jugador.ElegirDelCatalogo(7);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(1);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(1.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Hielo es fuerte frente a otro de tipo Hielo, su ponderador será 2.0.
    /// </summary>
    [Test]
    public void Hielo_PonderadorOponenteHielo()
    {
        jugador.ElegirDelCatalogo(7);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(7);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(2.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Hielo es débil frente a otro de tipo Fuego, su ponderador será 0.5.
    /// </summary>
    [Test]
    public void Hielo_PonderadorOponenteFuego()
    {
        jugador.ElegirDelCatalogo(7);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(5);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0.5, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Planta es fuerte frente a otro de tipo Agua, su ponderador será 2.0.
    /// </summary>
    [Test]
    public void Planta_PonderadorOponenteAgua()
    {
        jugador.ElegirDelCatalogo(9);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(1);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(2.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Planta es débil frente a otro de tipo Fuego, su ponderador será 0.5.
    /// </summary>
    [Test]
    public void Planta_PonderadorOponenteFuego()
    {
        jugador.ElegirDelCatalogo(9);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(5);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0.5, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que el pokémon de tipo Planta al atacar a otro pokémon que no sea de tipo Fuego, Hielo,
    /// Tierra, Agua o Electrico, el ponderador es neutro (1.0).
    /// </summary>
    [Test]
    public void Planta_PonderadorOponenteNeutro()
    {
        jugador.ElegirDelCatalogo(9);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(11);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(1.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Roca es fuerte frente a otro de tipo Fuego, su ponderador será 2.0.
    /// </summary>
    [Test]
    public void Roca_PonderadorOponenteFuego()
    {
        jugador.ElegirDelCatalogo(11);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(6);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(2.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Roca es débil frente a otro de tipo Agua, su ponderador será 0.5.
    /// </summary>
    [Test]
    public void Roca_PonderadorOponenteAgua()
    {
        jugador.ElegirDelCatalogo(11);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(2);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0.5, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que el pokémon de tipo Roca al atacar a otro pokémon que no sea de tipo Fuego, Planta,
    /// Tierra o Agua, el ponderador es neutro (1.0).
    /// </summary>
    [Test]
    public void Roca_PonderadorOponenteNeutro()
    {
        jugador.ElegirDelCatalogo(11);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(3);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(1.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Tierra es fuerte frente a otro de tipo Electrico, su ponderador será 2.0.
    /// </summary>
    [Test]
    public void Tierra_PonderadorOponenteElectrico()
    {
        jugador.ElegirDelCatalogo(13);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(3);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(2.0, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que un pokémon de tipo Tierra es débil frente a otro de tipo Agua, su ponderador será 0.5.
    /// </summary>
    [Test]
    public void Tierra_PonderadorOponenteAgua()
    {
        jugador.ElegirDelCatalogo(13);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(2);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(0.5, Is.EqualTo(ponderador));
    }
    
    /// <summary>
    /// Este test verifica que el pokémon de tipo Tierra al atacar a otro pokémon que no sea de tipo Electrico, Planta,
    /// Hielo o Agua, el ponderador es neutro (1.0).
    /// </summary>
    [Test]
    public void Tierra_PonderadorOponenteNeutro()
    {
        jugador.ElegirDelCatalogo(13);
        IPokemon pokemon = jugador.ElegirPokemon(0);

        jugador2.ElegirDelCatalogo(5);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonEnemigo.TipoPokemon);

        Assert.That(1.0, Is.EqualTo(ponderador));
    }
}