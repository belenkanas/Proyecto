using Library;
using NUnit.Framework;
using Ucu.Poo.DiscordBot.Commands;
using Ucu.Poo.DiscordBot.Services;


namespace LibraryTests;

public class ItemsCommandTest
{
    public JugadorPrincipal jugador;
    private static Dictionary<string, JugadorPrincipal> jugadores = new Dictionary<string, JugadorPrincipal>();

    [SetUp]
    public void SetUp()
    {
        void DemoBot()
        {
            BotLoader.LoadAsync().GetAwaiter().GetResult();
        }
        DemoBot();
        jugador = new JugadorPrincipal("Sol");
        jugadores.Add("Sol",jugador);
    }
    
    [Test]
    public async Task MostrarItemsTest()
    {
        string displayName = jugador.NombreJugador;

        JugadorPrincipal jugadorPrincipal = jugadores[displayName];

        string cadena = $"Inventario de Items:\n " +
                        $"1. Super Pocion \n" +
                        $"2. Revivir \n" +
                        $"3. Cura Total \n";
        
        string inventario = jugadorPrincipal.MostrarInventario();
        
        Assert.That(cadena,Is.EqualTo(inventario));
    }
}
