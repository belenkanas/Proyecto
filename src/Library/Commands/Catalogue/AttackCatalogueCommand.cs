using System.ComponentModel;
using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'catalogoataques' del bot. Este comando muestra
/// un catálogo de ataques disponibles para utilizar en la batalla.
/// </summary>
public class AttacksCatalogueCommand : ModuleBase<SocketCommandContext>
{

    /// <summary>
    /// Implementa el comando 'catalogoataques'. Este comando muestra la lista de
    /// ataques disponibles del pokemon en batalla para usar en la misma.
    /// </summary>
    [Command("catalogoataques")]
    [Summary("Muestra los ataques disponibles para utilizar")]
    public async Task ExecuteAsync([Summary("Índice del pokemón en el equipo (1-6)")] int indice)
    {
        string displayName = Context.User.Username;
        Facade.Instance.RegisterPlayer(displayName);

        string ataques = Facade.Instance.MostrarAtaques(displayName, indice); // Ajusta índice para base 0
        await ReplyAsync(ataques);
    }
}