using Library;
using NUnit.Framework;

namespace LibraryTests;

[TestFixture]
public class CatalogosTest
{
    /// <summary>
    /// Esta prueba, verifica que agregue todos los ataques al catálogo de ataques.
    /// </summary>
    [Test]
    public void AgregarAtaques_VerificarSiAgregaTodos()
    {
        CatalogoAtaques CatalogoAtaques = new CatalogoAtaques();

        List<Ataque> ataquesAgregar = new List<Ataque>()
        {
            new Ataque("Acua Jet", new Agua(), 25, true),
            new Ataque("Burbuja", new Agua(), 25, false),
            new Ataque("Pistola de agua", new Agua(), 6, false),
            new Ataque("Hidrobomba", new Agua(), 90, true),

            new Ataque("Chispa", new Electrico(), 7, false),
            new Ataque("Impactrueno", new Electrico(), 8, false),
            new Ataque("Rayo", new Electrico(), 55, true),
            new Ataque("Trueno", new Electrico(), 100, true),

            new Ataque("Ascuas", new Fuego(), 10, false),
            new Ataque("Colmillo ígneo", new Fuego(), 10, false),
            new Ataque("Llamarada", new Fuego(), 100, true),
            new Ataque("Lanzallamas", new Fuego(), 55, true),

            new Ataque("Canto helado", new Hielo(), 15, false),
            new Ataque("Vaho gélido", new Hielo(), 9, false),
            new Ataque("Rayo hielo", new Hielo(), 65, true),
            new Ataque("Ventisca", new Hielo(), 100, true),
            
            new Ataque("Hoja afilada", new Planta(), 15, false),
            new Ataque("Látigo cepa", new Planta(), 7, false),
            new Ataque("Bomba germen", new Planta(), 40, true),
            new Ataque("Tormenta floral", new Planta(), 65, true),
            
            new Ataque("Lanzarrocas", new Roca(), 12, false), 
            new Ataque("Avalancha", new Roca(), 50, true),
            new Ataque("Roca afilada", new Roca(), 80, true),
            new Ataque("Tumba rocas", new Roca(), 30, true),
            
            new Ataque("Bofetón lodo", new Tierra(), 15, false),
            new Ataque("Disparo lodo", new Tierra(), 6, false),
            new Ataque("Bomba Fango", new Tierra(), 30, true),
            new Ataque("Terremoto", new Tierra(), 100, true)
        };
        
        Assert.That(ataquesAgregar.Count, Is.EqualTo(CatalogoAtaques.ataques.Count));

        for (int i = 0; i < CatalogoAtaques.ataques.Count; i++)
        {
            Assert.That(CatalogoAtaques.ataques[i].Nombre, Is.EqualTo(ataquesAgregar[i].Nombre));
            Assert.That(CatalogoAtaques.ataques[i].TipoAtaque.NombreTipo, Is.EqualTo(ataquesAgregar[i].TipoAtaque.NombreTipo));
            Assert.That(CatalogoAtaques.ataques[i].DañoBase, Is.EqualTo(ataquesAgregar[i].DañoBase));
            Assert.That(CatalogoAtaques.ataques[i].EsEspecial, Is.EqualTo(ataquesAgregar[i].EsEspecial));
        }
    }

    /// <summary>
    /// Este test, verifica que agregue todos los pokémones al catálogo de pokémones.
    /// </summary>
    [Test]
    public void AgregarPokemones()
    {
        CatalogoPokemons catalogoPokemons = new CatalogoPokemons();

        List<Pokemon> pokemones = new List<Pokemon>()
        {
            new Pokemon("Squirtle", new Agua(), 100),
            new Pokemon("Wartortle", new Agua(), 100),
            new Pokemon("Pikachu", new Electrico(), 100),
            new Pokemon("Magneton", new Electrico(), 100),
            new Pokemon("Charmander", new Fuego(), 100),
            new Pokemon("Charizard", new Fuego(), 100),
            new Pokemon("Articuno", new Hielo(), 100),
            new Pokemon("Vulpix de Alola", new Hielo(), 100),
            new Pokemon("Bulbasaur", new Planta(), 100),
            new Pokemon("Oddish", new Planta(), 100),
            new Pokemon("Geodude", new Roca(), 100),
            new Pokemon("Pupitar", new Roca(), 100),
            new Pokemon("Sandshrew", new Tierra(), 100),
            new Pokemon("Rhyhorn", new Tierra(), 100)
        };

        Assert.That(catalogoPokemons.Catalogo.Count, Is.EqualTo(pokemones.Count));
        
        for (int i = 0; i < catalogoPokemons.Catalogo.Count; i++)
        {
            Assert.That(catalogoPokemons.Catalogo[i].Nombre, Is.EqualTo(pokemones[i].Nombre));
            Assert.That(catalogoPokemons.Catalogo[i].TipoPokemon.NombreTipo, Is.EqualTo(pokemones[i].TipoPokemon.NombreTipo));
        }
    }

    /// <summary>
    /// Este test, comprueba que el método MostrarCatalogo() de la clase CatalogoPokemons() muestre todos los pokémones
    /// que hay en el catálogo, los que se han agregado en el método anterior.
    /// </summary>
    [Test]
    public void MostrarCatalogoPokemons_VerificarMuestreTodos()
    {
        CatalogoPokemons catalogoPokemons = new CatalogoPokemons();
        
        string muestra = "Seleccione 6 pokémons para su equipo con su número correspondiente: \n" +
                         "1. Squirtle\n" +
                         "2. Wartortle\n" +
                         "3. Pikachu\n" +
                         "4. Magneton\n" +
                         "5. Charmander\n" +
                         "6. Charizard\n" +
                         "7. Articuno\n" +
                         "8. Vulpix de Alola\n" +
                         "9. Bulbasaur\n" +
                         "10. Oddish\n" +
                         "11. Geodude\n" +
                         "12. Pupitar\n" +
                         "13. Sandshrew\n" +
                         "14. Rhyhorn\n";
        
        Assert.That(catalogoPokemons.MostrarCatalogo(), Is.EqualTo(muestra));
    }
}