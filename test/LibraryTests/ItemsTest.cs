using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class ItemsTest
{
    public JugadorPrincipal jugador;
    public Dormir dormir;
    public Envenenar envenenar;
    public Paralizar paralizar;
    public Quemar quemar;
    public CuraTotal cura;
    public Revivir revivir;
    public SuperPocion pocion;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("José");
        dormir = new Dormir();
        envenenar = new Envenenar();
        paralizar = new Paralizar();
        quemar = new Quemar();
        cura = new CuraTotal();
        revivir = new Revivir();
        pocion = new SuperPocion();
        jugador.ElegirDelCatalogo(4);
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

    /// <summary>
    /// En este test verificamos que cuando el pokémon tiene su vida en 0 y utilizamos el item Revivir, su vida sube
    /// un 50% de la vida total del pokémon.
    /// </summary>
    [Test]
    public void Revivir_VidaPokemonSubeA50()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.VidaActual = 0;

        double vidaActual = revivir.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        
        double vidaEsperada = pokemon.VidaTotal * 0.5;
        
        Assert.That(vidaActual, Is.EqualTo(vidaEsperada));
    }

    /// <summary>
    /// En esta prueba, comprobamos que si ya se utilizó el item Revivir una vez, no podrá volver a utilizarlo,
    /// entonces la vida del pokémon no aumenta.
    /// </summary>
    [Test]
    public void Revivir_SinUsosRestantes()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.VidaActual = 0;
        revivir.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        pokemon.VidaActual = 0;
        revivir.Usar(pokemon.VidaActual, pokemon.VidaTotal);

        Assert.That(pokemon.VidaActual, Is.EqualTo(0));
    }

    /// <summary>
    /// Cuando el pokémon tiene su vida actual mayor a 0, no se puede Revivir. Su vida actual no cambia.
    /// </summary>
    [Test]
    public void Revivir_VidaMayorA0()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.VidaActual = 50;
        double vida = revivir.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        
        Assert.That(pokemon.VidaActual, Is.EqualTo(vida));
    }

    /// <summary>
    /// En este test, verificamos que cuando la vida actual del pokémon es menor a 30 y utiliza la super pocion, su
    /// vida aumenta 70 puntos más de la actual. Y para los usos restantes del item, disminuirá un uso.
    /// </summary>
    [Test]
    public void SuperPocion_VidaMenorA30()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.VidaActual = 20;
        
        double vidaEsperada = pokemon.VidaActual + 70;
        double vidaActual = pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        
        Assert.That(vidaActual, Is.EqualTo(vidaEsperada));
        Assert.That(pocion.usosRestantes, Is.EqualTo(3));
    }

    /// <summary>
    /// En este caso, la vida del pokémon es mayor a 30, entonces verificamos que su vida actual aumente al 100%.
    /// </summary>
    [Test]
    public void SuperPocion_VidaMayorA30()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.VidaActual = 40;

        double vidaActual = pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        
        Assert.That(vidaActual, Is.EqualTo(pokemon.VidaTotal));
    }

    /// <summary>
    /// En este caso, comprobamos que si no le quedan usos de la super pocion, su vida actual no cambia. 
    /// </summary>
    [Test]
    public void SuperPocion_SinUsosRestantesDePocion()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.VidaActual = 10;
        pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        pokemon.VidaActual = 20;
        pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        pokemon.VidaActual = 30;
        pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
        
        Assert.That(pokemon.VidaActual, Is.EqualTo(30));
        Assert.That(pocion.usosRestantes, Is.EqualTo(0));
    }   
}