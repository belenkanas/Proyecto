using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showitems' del bot. Este comando muestra
/// un catálogo de items disponibles para utilizar en la batalla.
/// </summary>
public class InventaryItemsCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new Dictionary<string, JugadorPrincipal>();

    /// <summary>
    /// Implementa el comando 'showitems'. Este comando muestra la lista de
    /// items disponibles para usar en la batalla.
    /// </summary>
    [Command("showitems")]
    [Summary("Muestra los items disponibles para utilizar")]
    public async Task MostrarItems()
    {
        string displayName = Context.User.Username;
        
        JugadorPrincipal jugadorPrincipal = jugadores[displayName];
        
        string inventario = jugadorPrincipal.MostrarInventario();
        await ReplyAsync(inventario);
    }
}