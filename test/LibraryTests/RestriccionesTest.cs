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

        string catalogoResultado = $"Seleccione 6 pokémons para su equipo con su número correspondiente: \n" +
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

        string catalogoResultado = $"Seleccione 6 pokémons para su equipo con su número correspondiente: \n" +
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

    /// <summary>
    /// Para este test, el jugador prefiere que cierto pokemon nunca aparezca como opción para jugar. Para eso se lo elimina del
    /// catalogo de pokemons, y por dependencias, no apareceran sus ataques ni se lo podrá usar en toda la partida.
    /// </summary>
    [Test]
    public void RestriccionPokemon()
    {
        //Es la restriccion n°0 de la lista que le aparece al principio. El pokemon que no quiere que aparezca es Pikachu, y lo indica por su nombre
        string sinNombrePokemon = jugador.ElegirRestriccion(0, "Pikachu");

        string catalogoResultado = "Seleccione 6 pokémons para su equipo con su número correspondiente: \n" +
                                   "1. Squirtle\n" +
                                   "2. Wartortle\n" +
                                   "3. Magneton\n" +
                                   "4. Charmander\n" +
                                   "5. Charizard\n" +
                                   "6. Articuno\n" +
                                   "7. Vulpix de Alola\n" +
                                   "8. Bulbasaur\n" +
                                   "9. Oddish\n" +
                                   "10. Geodude\n" +
                                   "11. Pupitar\n" +
                                   "12. Sandshrew\n" +
                                   "13. Rhyhorn\n";
        
        Assert.That(sinNombrePokemon, Is.EqualTo(catalogoResultado));
    }

    /// <summary>
    /// Para este test, el jugador elige no jugar con cierto tipo de item, en este caso el de Cura Total. Para eso, se le quitará la opcion al InventarioItems que tiene
    /// acceso el jugador, por lo que más adelante no lo podrá utilizar en la partida.
    /// </summary>
    [Test]
    public void RestriccionItem()
    {
        //Elige la ultima opcion de la lista de restricciones que le aparece al principio, y elige el item que no quiere utilizar por su nombre. El que no usará es el que restaura vida.
        string restriccionItem = jugador.ElegirRestriccion(3, "Revivir");

        string resultados = "Inventario de Items:\n" +
                            $"1. Cura Total \n" +
                            $"2. Super Pocion \n";
        
        Assert.That(resultados, Is.EqualTo(restriccionItem));
    }

    /// <summary>
    /// Para este test, el jugador no elige ninguna restriccion planteada, por lo que, como indica la historia de usuario, no se da por iniciada la partida.
    /// Se comprobará que el índice que elige el usuario no es uno de los de la lista (puede elegir un numero negativo como uno mayor a 3 para indicar su desacuerdo),
    /// y que por dicha eleccion la batalla no estará activa.
    /// </summary>
    [Test]
    public void NoSeEligenRestricciones()
    {
        string noRestriccion = jugador.ElegirRestriccion(10, "no");
        string resultado = "No se eligen restricciones, no se inicia batalla";
        
        Assert.That(noRestriccion, Is.EqualTo(resultado));
    }
}
