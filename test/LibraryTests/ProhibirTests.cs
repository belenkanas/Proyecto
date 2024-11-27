using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
[TestOf(typeof(prohibiciones))]
public class prohibicionesTest
{

    [Test]
    public void ProhibirPokemon()
    {
        var prohibicion = new prohibiciones();
        prohibicion.prohibirPokemon("pikachu");

        var pikachu = new Pokemon("pikachu", new Electrico(), 100);
        //Assert.(...)... 
    }

    [Test]
    public void prohibirTipo()
    {
        var prohibicion = new prohibiciones();
        prohibicion.prohibirTipo("Agua");

        var pikachu = new Pokemon("wartortle", new Agua(), 100);
        // Assert.(...);
        
    }

    [Test]
    public void prohibirItem()
    {
        
    }
    
}