using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;
public class AttackCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, BatallaFacade> batallasEnCurso;

    [Command("attack")]
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
