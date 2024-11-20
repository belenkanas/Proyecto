using NUnit.Framework;

namespace Library.Tests;

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