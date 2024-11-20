using NUnit.Framework;

namespace Library.Tests;
/// <summary>
///  Como entrenador, quiero iniciar una ballata con un jugador que está esperando por un oponente.
/// </summary>
public class HistoriaUsuarioOnceTest
{
    public JugadorPrincipal entrenador;
    public JugadorPrincipal entrenador2;
    public BatallaFacade batalla;
    
    [SetUp]
    public void SetUp()
    {
        entrenador = new JugadorPrincipal("Lola");
        entrenador2 = new JugadorPrincipal("Pedro");
        batalla = new BatallaFacade(entrenador.NombreJugador, entrenador2.NombreJugador);
        
    }

    [Test]
    public void NotificarInicio()
    {
        Random random = new Random();
        batalla.IniciarBatallaListaDeEspera(random);

        string muestra = $"{entrenador.NombreJugador} la batalla ha comenzado";

        Assert.That(muestra, Is.EqualTo(batalla.NotificarInicio(entrenador)));
        
        string muestra2 = $"{entrenador2.NombreJugador} la batalla ha comenzado";

        Assert.That(muestra2, Is.EqualTo(batalla.NotificarInicio(entrenador2)));
    }
    
    [Test]
    public void PrimerTurnoAleatorio()
    {
        batalla.ListaDeEspera(entrenador);
        batalla.ListaDeEspera(entrenador2);
        
        Random random = new Random();
        batalla.IniciarBatallaListaDeEspera(random);
        
        Assert.That(entrenador.TurnoActual || entrenador2.TurnoActual, Is.True);
    }
}