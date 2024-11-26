﻿using Discord;
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
        
        Facade.Instance.RegisterPlayer(displayName);

        string result = Facade.Instance.RealizarAtaque(displayName, indiceAtaque);
        
        await ReplyAsync(result);
        
    }
}
