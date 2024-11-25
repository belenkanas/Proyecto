using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class EfectosTest
{
    public JugadorPrincipal jugador;
    public Dormir dormir;
    public Envenenar envenenar;
    public Paralizar paralizar;
    public Quemar quemar;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Mateo");
        dormir = new Dormir();
        envenenar = new Envenenar();
        paralizar = new Paralizar();
        quemar = new Quemar();
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
        Assert.That(paralizar.nombreEfecto, Is.EqualTo("Paralizar"));
    }
    
    /// <summary>
    /// En esta prueba verificamos que se cumpla el permiso para atacar del pokemon
    /// el cual es aleatorio.
    /// </summary>
    [Test]
    public void PuedeAtacar_RetornaValoresAleatorios()
    {
        int puedeAtacarVerdadero = 0;
        int puedeAtacarFalso = 0;
        
        for (int i = 0; i < 1000; i++) // Probamos varios casos para capturar la mayor cantidad posible de casos verdadero y de casos falsos.
        {
            if (paralizar.PuedeAtacar())
                puedeAtacarVerdadero++;
            else
                puedeAtacarFalso++;
        }
        
        Assert.That(puedeAtacarVerdadero, Is.GreaterThan(0)); //Verifica que por lo menos una vez permite atacar
        Assert.That(puedeAtacarFalso, Is.GreaterThan(0));// Verifica que por lo menos una vez no permite atacar.
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
}