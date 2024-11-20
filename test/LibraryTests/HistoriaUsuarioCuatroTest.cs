using NUnit.Framework;

namespace Library.Tests;
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