using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;
/// <summary>
/// Esta clase implementa el comando 'attack' del bot. Este comando le
/// permite al entrenador usar ataques para dañar al oponente.
/// </summary>
public class AttackCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, BatallaFacade> batallasEnCurso;
    /// <summary>
    /// Implementa el comando 'attack'. Este comando permite que el entrenador
    /// elija un ataque y lo utilice en la partida.
    /// </summary>
    [Command("attack")]
    [Summary("Permite que el jugador realice un ataque en la partida")]
    public async Task ExecuteAsync(int indiceAtaque)
    {
        string displayName = CommandHelper.GetDisplayName(Context);

        if (batallasEnCurso.TryGetValue(displayName, out BatallaFacade batalla))
        {
            string resultado = batalla.RealizarAtaque(displayName, indiceAtaque);
            await ReplyAsync(resultado);
            
            string ganador = batalla.VerificarGanador();
            if (!string.IsNullOrEmpty(ganador))
            {
                await ReplyAsync(ganador);
                batallasEnCurso.Remove(displayName);
            }
        }
        else
        {
            await ReplyAsync("No estás en una batalla.");
        }
    }
}
