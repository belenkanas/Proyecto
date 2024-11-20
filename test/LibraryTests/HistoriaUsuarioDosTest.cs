using NUnit.Framework;

namespace Library.Tests;

/// <summary>
/// Historia de usuario 2.
/// Como jugador, quiero ver los ataques disponibles de mis Pokemones para poder elegir en cada turno
/// </summary>
public class HistoriaUsuarioDosTest
{
    public CatalogoPokemons catalogo;
    public JugadorPrincipal jugador;
    public JugadorPrincipal jugador2;
        
    [SetUp]
    public void SetUp()
    {
        catalogo = new CatalogoPokemons();
        jugador = new JugadorPrincipal("Dan");
        jugador2 = new JugadorPrincipal("Pepe");
        
        jugador.MostrarCatalogo();
        jugador.ElegirDelCatalogo(2);
        jugador.ElegirDelCatalogo(4);
        jugador.ElegirDelCatalogo(5);
        jugador.ElegirDelCatalogo(8);
        jugador.ElegirDelCatalogo(9);
        jugador.ElegirDelCatalogo(13);
        jugador.MostrarEquipo();
        
        jugador2.MostrarCatalogo();
        jugador2.ElegirDelCatalogo(2);
        
    }
    
    [Test]
    
    public void AtaquesDisponiblesPrimerTurno()
    {
        //Estamos en el primer turno.
        //Tenemos q ver q se muestre toda la lista de ataques de tipo Agua (que es la del tipo del Pokemon).
        string resultado = $"1. Nombre: Acua Jet Tipo: Agua Daño: 25 Es especial: True.\n" +
                           $"2. Nombre: Burbuja Tipo: Agua Daño: 25 Es especial: False.\n" +
                           $"3. Nombre: Pistola de agua Tipo: Agua Daño: 6 Es especial: False.\n" +
                           $"4. Nombre: Hidrobomba Tipo: Agua Daño: 90 Es especial: True.\n";
        
        Assert.That(jugador.MostrarAtaquesDisponibles(0), Is.EqualTo(resultado));
    }

    [Test]
    // Se debe asegurar que los ataques especiales se puedan seleccionar solo a cada 2 turnos.
    public void AtaquesDisponiblesSegundoTurno()
    {
        Pokemon pikachu = new Pokemon("Pikachu", new Electrico(), 100);
        
        //Luego de crear el pokemon, se le agregan los ataques (2 de ellos especiales)
        Ataque ataqueNormal1 = new Ataque("Impactrueno", new Electrico(), 50, false);
        Ataque ataqueNormal2 = new Ataque("Chispa", new Electrico(), 30, false);
        Ataque ataqueEspecial1 = new Ataque("Rayo", new Electrico(), 80, true);
        Ataque ataqueEspecial2 = new Ataque("Trueno", new Electrico(), 100, true);

        pikachu.Ataques.Add(ataqueNormal1);
        pikachu.Ataques.Add(ataqueNormal2);
        pikachu.Ataques.Add(ataqueEspecial1);
        pikachu.Ataques.Add(ataqueEspecial2);

        
        //Se comprueba que en el primer turno todos los ataques estén disponibles para su disposición.
        List<Ataque> ataquesDisponiblesTurno1 = pikachu.ObtenerAtaquesDisponibles();
        Assert.Contains(ataqueNormal1, ataquesDisponiblesTurno1);
        Assert.Contains(ataqueNormal2, ataquesDisponiblesTurno1);
        Assert.Contains(ataqueEspecial1, ataquesDisponiblesTurno1);
        Assert.Contains(ataqueEspecial2, ataquesDisponiblesTurno1);

        // Usar un ataque especial en el Turno 1
        pikachu.UsarAtaque(2, new Pokemon("Charmander", new Fuego(), 100)); 

        // Al usar un ataque, se cambia de turno.
        //Por lo qye ahora se prueba que los ataques disponibles sean únicamente los normales.
        List<Ataque> ataquesDisponiblesTurno2 = pikachu.ObtenerAtaquesDisponibles();
        List<Ataque> pruebaAtaques = new List<Ataque>();
        pruebaAtaques.Add(ataqueNormal1);
        pruebaAtaques.Add(ataqueNormal2);
        Assert.That(pruebaAtaques, Is.EqualTo(ataquesDisponiblesTurno2)); //Se comprueba que el único ataque disponible es el normal.
        

        // Usar un ataque normal en el Turno 2
        pikachu.UsarAtaque(0, new Pokemon("Charmander", new Fuego(), 100)); 

        // Se cambia de turno nuevamente, ahora deberían estar todos los ataques disponibles nuevamente
        List<Ataque> ataquesDisponiblesTurno3 = pikachu.ObtenerAtaquesDisponibles();
        Assert.Contains(ataqueNormal1, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueNormal2, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueEspecial1, ataquesDisponiblesTurno3);
        Assert.Contains(ataqueEspecial2, ataquesDisponiblesTurno3);

    }
}