using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;
/// <summary>
/// Esta clase implementa el comando 'mostrarturno' del bot. Este comando le
/// permite al entrenador ver si es su turno o no.
/// </summary>
public class ShowTurnCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, BatallaFacade> batallasEnCurso;

    /// <summary>
    /// Implementa el comando 'mostrarturno'. Este comando permite que el entrenador
    /// vea si es su turno o no.
    /// </summary>
    [Command("mostrarturno")]
    [Summary("Permite que el jugador vea si es su turno o no")]
    public async Task ExecuteAsync()
    {
        string displayName = Context.User.Username;
        Facade.Instance.RegisterPlayer(displayName);

        string resultado = Facade.Instance.MostrarTurno(displayName);
        await ReplyAsync(resultado);
    }
}