using System.ComponentModel;
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
    string displayName = CommandHelper.GetDisplayName(Context);
    private JugadorPrincipal jugadorPrincipal = new JugadorPrincipal(displayName);

    /// <summary>
    /// Implementa el comando 'catalogo'. Este comando muestra la lista de
    /// pókemons disponibles para usar en la batalla.
    /// </summary>
    [Command("catalogopokemon")]
    [Summary("Muestra los pókemons disponibles para utilizar")]
    public async Task MostrarAtaques(int indice)
    {
        string ataques = jugadorPrincipal.MostrarAtaquesDisponibles(indice);
        await ReplyAsync(ataques);
    }
}