using Discord.Commands;
using Library;

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
    public async Task ExecuteAsync(int indiceAtaque)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        if (batallasEnCurso.TryGetValue(displayName, out BatallaFacade batalla))
        {
            string resultado = batalla.VerificarTurno(displayName).ToString();
            await ReplyAsync(resultado);

        }
    }
}