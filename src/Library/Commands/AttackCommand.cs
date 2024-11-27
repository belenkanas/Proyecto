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
    /// <summary>
    /// Implementa el comando 'attack'. Este comando permite que el entrenador
    /// elija un ataque y lo utilice en la partida.
    /// </summary>
    [Command("attack")]
    [Summary("Permite que el jugador realice un ataque en la partida")]
    public async Task ExecuteAsync(int indiceAtaque)
    {
        string displayName = Context.User.Username;
        
        //Registra al jugador si aun no esta registrado
        Facade.Instance.RegisterPlayer(displayName);

        string result = Facade.Instance.RealizarAtaque(displayName, indiceAtaque);
        
        // Verifica si se pudo realizar el ataque.
        if (string.IsNullOrEmpty(result))
        {
            result = "El ataque no pudo realizarse. Verifica el estado de la batalla.";
        }
        await ReplyAsync(result);
        
    }
}
