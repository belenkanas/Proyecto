using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

public class UseItemCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new();

    /// <summary>
    /// Implementa el comando 'useitem'. Este comando permite que el entrenador
    /// use un item para atacar al oponente.
    /// </summary>
    [Command("useitem")]
    [Summary("Permite que el entrenador use un item en batalla.")]
    public async Task ExecuteAsync(int indice)
    {
        string displayName = Context.User.Username;
        Facade.Instance.RegisterPlayer(displayName);

        string resultado = Facade.Instance.UsarItem(displayName, indice);
        await ReplyAsync(resultado);
    }
}
    
