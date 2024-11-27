using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class DefensaTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal oponente;
    public BatallaFacade batalla;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Gabriel");
        oponente = new JugadorPrincipal("José");
        batalla = new BatallaFacade(jugador, oponente);
    }

    [Test]
    public void ProhibirTipos()
    {
        jugador.ProhibirTipos(new Agua());
        
        string resultado = "Pokemones de tipo Agua están restringidos\n" +
                                  "Pokemones de tipo Eléctrico están restringidos\n";
        
        Assert.That(jugador.ProhibirTipos(new Electrico()), Is.EqualTo(resultado));
    }
    
    [Test]
    public void ProhibirPokemonesEnEspecifico()
    {
        jugador.ProhibirPokemonesEnEspecifico("Squirtle");
        string resultado = "El pokémon Squirtle está restringido";
        
        Assert.That(jugador.Reglas, Is.EqualTo(resultado));
    }
    
    [Test]
    public void ProhibirItems()
    {
        jugador.ProhibirItems("Cura Total");
        string resultado = "Cura Total está restringido";
        
        Assert.That(jugador.Reglas, Is.EqualTo(resultado));
    }
    
    //Probe los test de las clases que restringen los tipos de pokemon, un pokemon especifico y los items. Por falta de
    //tiempo no pude hacer el test completo de todos los métodos probando si el oponente acepta la batalla.
}