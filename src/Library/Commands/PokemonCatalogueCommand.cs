using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'showpokemons' del bot. Este comando muestra
/// un catálogo de pokemons disponibles para utilizar en la batalla.
/// </summary>
// ReSharper disable once UnusedType.Global
public class PokemonCatalogueCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'showpokemons'. Este comando muestra la lista de
    /// pókemons disponibles para usar en la batalla.
    /// </summary>
    [Command("showpokemons")]
    [Summary("Muestra los pókemons disponibles para utilizar")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        //Resolver static 
        string result = CatalogoPokemons.MostrarCatalogo();

        await ReplyAsync(result);
    }
}
