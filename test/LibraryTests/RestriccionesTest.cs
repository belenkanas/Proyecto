using Library;
using NUnit.Framework;

namespace LibraryTests;
/// <summary>
/// En esta clase de test se va a probar que el catálogo de Restricciones sea correcto, y que la eleccion de la misma muestre lo esperado.
/// </summary>
[TestFixture]
public class RestriccionesTest
{
    public JugadorPrincipal jugador;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Sol");
        
    }

    /// <summary>
    /// Se comprueba que los distintos tipos de restricciones se muestren en pantalla a la hora de iniciar la partida.
    /// </summary>
    [Test]
    public void PresentacionRestricciones()
    {
        string restricciones = jugador.MostrarRestricciones();

        string presentarRestricciones = $"Restricciones: \n" +
                                        $"0- Restricción de NO jugar con cierto Pokemon \n" +
                                        $"1- Restricción de Solo un Tipo de Pokemon \n" +
                                        $"2- Restricción de NO jugar con cierto Tipo de Pokemon \n" +
                                        $"3- Restricción de NO jugar con cierto item \n";
        Assert.That(restricciones, Is.EqualTo(presentarRestricciones));
    }

    /// <summary>
    /// Se comprueba que luego de elegir solo un tipo de pokemon para jugar en la pantalla, el catalogo de pokemons disponibles para el jugador sean solo de ese tipo.
    /// Para eso, tiene que elegir el índice 1 de la lista de restricciones disponibles, y como resultado le aparecerá el catalogo de pokemones de solo el tipo deseado.
    /// </summary>
    [Test]
    public void SoloTipoPokemon()
    {
        string soloUnTipoPokemon = jugador.ElegirRestriccion(1, "Agua");

        string catalogoResultado = $"" +
                                   $"Seleccione 6 pokémons para su equipo con su número correspondiente: \n" +
                                   $"1. Squirtle\n" +
                                   $"2. Wartortle\n";
                                   
       //El jugador solo elige el tipo pokemon Agua, el cual es correspondiente a los Pokemons Squirtle y Wartotle.
       //A continuación, solo esos son los disponibles para elegir.
        Assert.That(soloUnTipoPokemon, Is.EqualTo(catalogoResultado));
    }

    /// <summary>
    /// Para este test, se comprobará que el jugador no quiere que el tipo de pokemon Agua le aparezca entre las opciones a
    /// utilizar. Si no le aparece en el catalogo de pokemons, por consecuencia (y dependencia de Ataques con TipoPokemon), tampoco podrá usar ataques de este tipo.
    /// Se debería comprobar que al jugador le aparece el catálogo pokemons sin el tipo "Agua".
    /// </summary>
    [Test]
    public void SinTipoPokemon()
    {
        //Elige la segunda opcion de listas de restricciones, indicando el nombre del tipo que no quiere que aparezca.
        string sinTipoPokemon = jugador.ElegirRestriccion(2, "Agua");

        string catalogoResultado = $"" +
                                   $"Seleccione 6 pokémons para su equipo con su número correspondiente: \n" +
                                   $"1. Pikachu\n" +
                                   $"2. Magneton\n" +
                                   $"3. Charmander\n" +
                                   $"4. Charizard\n" +
                                   $"5. Articuno\n" +
                                   $"6. Vulpix de Alola\n" +
                                   $"7. Bulbasur\n" +
                                   $"8. Oddish\n" +
                                   $"9. Geodude\n" +
                                   $"10. Pupitar\n" +
                                   $"11. Sandshrew\n" +
                                   $"12. Rhyhorn\n";
        
        Assert.That(sinTipoPokemon, Is.EqualTo(catalogoResultado));
    }
}
