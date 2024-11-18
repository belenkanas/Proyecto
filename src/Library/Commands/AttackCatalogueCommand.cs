using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showattacks' del bot. Este comando muestra
/// un catálogo de ataques disponibles para utilizar en la batalla.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AttacksCatalogueCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'showattacks'. Este comando muestra la lista de
    /// ataques disponibles para usar en la batalla.
    /// </summary>
    [Command("showattacks")]
    [Summary("Muestra los ataques disponibles para utilizar")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        //Resolver static y número del pokemon dentro del equipo.
        string result = JugadorPrincipal.MostrarAtaquesDisponibles(1);

        await ReplyAsync(result);
    }
}