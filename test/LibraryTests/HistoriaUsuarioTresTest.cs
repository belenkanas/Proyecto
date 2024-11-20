using NUnit.Framework;

namespace Library.Tests;
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