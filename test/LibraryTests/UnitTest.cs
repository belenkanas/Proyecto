using Library;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Tests;

[TestFixture]
public class JugadorPrincipalTest
{
    public JugadorPrincipal jugador1;
    
    [SetUp]
    public void SetUp()
    {
        jugador1 = new JugadorPrincipal("Ana");
    }
    
    [Test]
    public void ElegirPokemonDelCatalogo_IndiceValido()
    {
        IPokemon pokemon = jugador1.ElegirDelCatalogo(3);
        
        Assert.That(("Pikachu"), Is.EqualTo(pokemon.Nombre));
    }

    [Test]
    public void ElegirPokemonDelCatalogo_IndiceNegativo()
    {
        IPokemon pokemon = jugador1.ElegirDelCatalogo(-1);
        
        Assert.That(null, Is.EqualTo(pokemon));
    }

    [Test]
    public void ElegirPokemonDelEquipo_IndiceValido()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(3);

        IPokemon pokemon = jugador1.ElegirPokemon(0);
        
        Assert.That(pokemon.Nombre, Is.EqualTo("Squirtle"));
    }

    [Test]
    public void ElegirPokemonDelEquipo_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(5);

        IPokemon pokemon = jugador1.ElegirPokemon(3);
        
        Assert.That(pokemon, Is.EqualTo(null));
    }

    [Test]
    public void MostrarTurnoJugador()
    {
        jugador1.TurnoActual = false;
        
        Assert.That(false, Is.EqualTo(jugador1.MostrarTurno()));
    }

    [Test]
    public void MostrarAtaquesDisponibles_IndiceValido()
    {
        jugador1.ElegirDelCatalogo(6);
        string ataques = jugador1.MostrarAtaquesDisponibles(0);

        string resultado = $"1. Nombre: Ascuas Tipo: Fuego Daño: 10 Es especial: False.\n" +
                           $"2. Nombre: Colmillo ígneo Tipo: Fuego Daño: 10 Es especial: False.\n" +
                           $"3. Nombre: Llamarada Tipo: Fuego Daño: 100 Es especial: True.\n" +
                           $"4. Nombre: Lanzallamas Tipo: Fuego Daño: 55 Es especial: True.\n";
        
        Assert.That(ataques, Is.EqualTo(resultado));
    }

    [Test]
    public void MostrarAtaquesDisponibles_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(6);
        string ataques = jugador1.MostrarAtaquesDisponibles(-1);
            
        string resultado = "Índice inválido";
        
        Assert.That(resultado, Is.EqualTo(ataques));
    }

    [Test]
    public void MostrarEquipoConPokemonsValido()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        string equipo = "Squirtle, Agua\nWartortle, Agua\nPikachu, Electrico\nMagneton, Electrico\nCharmander, Fuego\nCharizard, Fuego\n";
        
        Assert.That(jugador1.MostrarEquipo(), Is.EqualTo(equipo));
    }
    
    [Test]
    public void MostrarEquipoConPokemonsInvalido()
    {
        Assert.That(jugador1.MostrarEquipo(), Is.EqualTo(null));
    }

    [Test]
    public void PokemonesDerrotados_TodosSinVida()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(0).VidaActual = 0;
        jugador1.ElegirPokemon(1).VidaActual = 0;
        jugador1.ElegirPokemon(2).VidaActual = 0;
        jugador1.ElegirPokemon(3).VidaActual = 0;
        jugador1.ElegirPokemon(4).VidaActual = 0;
        jugador1.ElegirPokemon(5).VidaActual = 0;
        
        Assert.That(jugador1.PokemonesDerrotados, Is.EqualTo(true));
    }
    
    [Test]
    public void PokemonesDerrotados_AlMenosUnoConVida()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(0).VidaActual = 0;
        jugador1.ElegirPokemon(1).VidaActual = 0;
        jugador1.ElegirPokemon(2).VidaActual = 0;
        jugador1.ElegirPokemon(3).VidaActual = 0;
        jugador1.ElegirPokemon(4).VidaActual = 0;
        jugador1.ElegirPokemon(5).VidaActual = 100;
        
        Assert.That(jugador1.PokemonesDerrotados, Is.EqualTo(false));
    }

    [Test]
    public void CambiarPokemonBatalla_IndiceValidoYPokemonNoActual()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(1);
        string resultado = $"Ana ha cambiado de pokémon a Squirtle";
        
        Assert.That(resultado,Is.EqualTo(jugador1.CambiarPokemonBatalla(0)));
    }
    
    [Test]
    public void CambiarPokemonBatalla_IndiceValidoYPokemonActual()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(1);
        string resultado = $"Ingrese otro índice";
        
        Assert.That(resultado,Is.EqualTo(jugador1.CambiarPokemonBatalla(1)));
    }
    
    [Test]
    public void CambiarPokemonBatalla_IndiceInvalido()
    {
        jugador1.ElegirDelCatalogo(1);
        jugador1.ElegirDelCatalogo(2);
        jugador1.ElegirDelCatalogo(3);
        jugador1.ElegirDelCatalogo(4);
        jugador1.ElegirDelCatalogo(5);
        jugador1.ElegirDelCatalogo(6);

        jugador1.ElegirPokemon(1);
        string resultado = $"Indice del Pokemon inválido";
        
        Assert.That(resultado,Is.EqualTo(jugador1.CambiarPokemonBatalla(-1)));
    }
}

[TestFixture]
public class PokemonTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
    public CatalogoAtaques catalogoAtaques;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Juan");
        jugador2 = new JugadorPrincipal("Bob");
        catalogoAtaques = new CatalogoAtaques();
        
        jugador.ElegirDelCatalogo(3);
        jugador2.ElegirDelCatalogo(1);
        
    }

    [Test]
    public void UsarAtaque_IndiceInvalido()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);
        
        string resultado = pokemon.UsarAtaque(-1, pokemonenemigo);

        Assert.That("El ataque no es válido", Is.EqualTo(resultado));
    }

    [Test]
    public void UsarAtaque_CalculoDeDañoConPonderador()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);

        pokemon.UsarAtaque(0, pokemonenemigo);

        double ponderador = pokemon.TipoPokemon.Ponderador(pokemonenemigo.TipoPokemon);
        double dañoEsperado = pokemon.Ataque - pokemonenemigo.Defensa * ponderador;
        double vida = pokemonenemigo.VidaTotal - dañoEsperado;

        Assert.That(vida, Is.EqualTo(pokemonenemigo.VidaActual));
    }

    [Test]
    public void UsarAtaque_AtaqueEspecialNoDisponible()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);

        pokemon.turnoContadorEspecial = 1;

        pokemon.AtaquesPorTipo();
        jugador.ElegirAtaque(pokemon, pokemonenemigo, 3);

        string resultadoEsperado = pokemon.UsarAtaque(3, pokemonenemigo);

        string resultado = "El ataque especial no está disponible este turno.";

        Assert.That(resultado, Is.EqualTo(resultadoEsperado));
    }

    [Test]
    public void UsarAtaque_AtaqueEspecialCalulcaDaño()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        
        pokemon.turnoContadorEspecial = 2;
        
        string resultado2 = pokemon.UsarAtaque(0, pokemonenemigo);
        string resultadoEsperado2 = "Pikachu usó Chispa y causó 7 puntos de daño.";
        
        Assert.That(resultado2, Is.EqualTo(resultadoEsperado2));
    }

    [Test]
    public void RecibirDaño()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonenemigo = jugador2.ElegirPokemon(0);
        
        pokemonenemigo.RecibirDaño(30);
        
        Assert.That(pokemonenemigo.Estado, Is.Not.EqualTo("Derrotado"));

        pokemon.AtaquesPorTipo();
        pokemon.turnoContadorEspecial = 2;
        pokemon.UsarAtaque(3, pokemonenemigo);
        
        Assert.That(pokemonenemigo.VidaActual, Is.EqualTo(0));
        Assert.That(pokemonenemigo.Estado, Is.EqualTo("Derrotado"));
    }

    [Test]
    public void MostrarVida_Formato()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        pokemon.RecibirDaño(20);
        
        string esperado = $"{pokemon.VidaActual}/{pokemon.VidaTotal}";
        
        Assert.That("80/100", Is.EqualTo(esperado));
    }
    
    [Test]
    public void AgregaAtaquesDelMismoTipoDePokemon_AgregandoOtrosTipos()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);

        pokemon.AtaquesPorTipo();

        List<Ataque> ataques = new List<Ataque>()
        {
            new Ataque("Chispa", new Electrico(), 7, false),
            new Ataque("Impactrueno", new Electrico(), 8, false),
            new Ataque("Rayo", new Electrico(), 55, true),
            new Ataque("Trueno", new Electrico(), 100, true),
            new Ataque("Ascuas", new Fuego(), 10, false)
        };
        
        Assert.That(ataques, Is.Not.EqualTo(pokemon.Ataques));
    }
    
    [Test]
    public void AgregaAtaquesDelMismoTipoDePokemon()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);

        pokemon.AtaquesPorTipo();

        List<Ataque> ataques = new List<Ataque>()
        {
            new Ataque("Chispa", new Electrico(), 7, false),
            new Ataque("Impactrueno", new Electrico(), 8, false),
            new Ataque("Rayo", new Electrico(), 55, true),
            new Ataque("Trueno", new Electrico(), 100, true)
        };
        
        Assert.That(ataques.Count, Is.EqualTo(pokemon.Ataques.Count));
    }

    [Test]
    public void ObtenerAtaquesDisponibles_SinEspeciales()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        pokemon.AtaquesPorTipo();
        
        pokemon.turnoContadorEspecial = 1;

        List<Ataque> ataques = pokemon.ObtenerAtaquesDisponibles();
        
        Assert.That("Chispa", Is.EqualTo(ataques[0].Nombre));  
        Assert.That("Impactrueno", Is.EqualTo(ataques[1].Nombre));
        
    }
    
    [Test]
    public void ObtenerAtaquesDisponibles_ConEspeciales()
    {
        IPokemon pokemon = jugador.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        
        pokemon.turnoContadorEspecial = 2;
        
        List<Ataque> ataques = pokemon.ObtenerAtaquesDisponibles();
        
        Assert.That("Chispa", Is.EqualTo(ataques[0].Nombre));  
        Assert.That("Impactrueno", Is.EqualTo(ataques[1].Nombre));
        Assert.That("Rayo", Is.EqualTo(ataques[2].Nombre));  
        Assert.That("Trueno", Is.EqualTo(ataques[3].Nombre));
    }
}

[TestFixture]
public class AtaqueTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Sol");
        jugador2 = new JugadorPrincipal("Ema");
    }

    [Test]
    public void CalcularDano_AtaqueEspecial()
    {
        jugador.ElegirDelCatalogo(2);
        jugador2.ElegirDelCatalogo(5);

        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        pokemon.turnoContadorEspecial = 2;
        pokemonEnemigo.DefensaEspecial = 40;

        double danoEsperado = pokemon.Ataques[3].DañoBase * 2.0 - pokemonEnemigo.DefensaEspecial;
        danoEsperado = Math.Max(danoEsperado, 0);

        double resultado = pokemon.Ataques[3].CalcularDaño(pokemon, pokemonEnemigo);
        
        Assert.That(resultado, Is.EqualTo(danoEsperado));
    }

    [Test]
    public void CalcularDano_NoEsEspecial()
    {
        jugador.ElegirDelCatalogo(2);
        jugador2.ElegirDelCatalogo(5);

        IPokemon pokemon = jugador.ElegirPokemon(0);
        IPokemon pokemonEnemigo = jugador2.ElegirPokemon(0);
        
        pokemon.AtaquesPorTipo();
        pokemonEnemigo.Defensa = 20;
        
        double danoEsperado = pokemon.Ataques[1].DañoBase - pokemonEnemigo.Defensa;
        danoEsperado = Math.Max(danoEsperado, 0);
        
        double resultado = pokemon.Ataques[1].CalcularDaño(pokemon, pokemonEnemigo);
        
        Assert.That(danoEsperado, Is.EqualTo(resultado));
    }
}

[TestFixture]
public class CatalogosTest
{
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Jorge");
        jugador2 = new JugadorPrincipal("Matias");
    }

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