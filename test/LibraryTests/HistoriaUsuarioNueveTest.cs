using NUnit.Framework;

namespace Library.Tests;
/// <summary>
/// Como entrenador, quiero unirme a la lista de jugadores esperando por un oponente.
/// </summary>
public class HistoriaUsuarioNueveTest
{
    public JugadorPrincipal entrenador;
    public JugadorPrincipal entrenador2;
    public BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new JugadorPrincipal("Martin");
        entrenador2 = new JugadorPrincipal("Clara");
        batalla = new BatallaFacade(entrenador.NombreJugador, entrenador2.NombreJugador);
        
    }

    [Test]
    // El jugador recibe un mensaje indicandole que está en la lista de espera
    public void ListaDeEsperaJugadores()
    {
        string esperado = batalla.ListaDeEspera(entrenador);

        string mensaje = $"{entrenador.NombreJugador} fue agregado a la lista de espera";
        
        Assert.That(mensaje, Is.EqualTo(esperado));
    }
}