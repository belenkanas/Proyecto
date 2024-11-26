using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'mostrarvida' del bot. Este comando muestra
/// los niveles HP del pokemon del equipo (indicado por un índice).
/// </summary>
public class MostrarVidaCommand : ModuleBase<SocketCommandContext>
{

    /// <summary>
    /// Implementa el comando 'mostrarvida'. Este comando muestra la lista de
    /// items disponibles para usar en la batalla.
    /// </summary>
    [Command("mostrarvida")]
    [Summary("Muestra la vida del pokemon que está en batalla, elegido por el índice")]
    public async Task ExecuteAsync(int indice)
    {
        string displayName = Context.User.Username;
        Facade.Instance.RegisterPlayer(displayName);
        string resultado = Facade.Instance.MostrarVidaPokemon(displayName, indice);
        
        await ReplyAsync(resultado);
    }
}