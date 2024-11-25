using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'catalogopokemons' del bot. Este comando muestra
/// un catálogo de pokemons disponibles para utilizar en la batalla.
/// </summary>
public class PokemonCatalogueCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'catalogopokemons'. Este comando muestra la lista de
    /// pókemons disponibles para usar en la batalla.
    /// </summary>
    [Command("catalogopokemons")]
    [Summary("Muestra los pókemons disponibles para utilizar")]
    public async Task MostrarCatalogo()
    {
        string displayName = Context.User.Username;

        // Registrar al jugador si no existe
        Facade.Instance.RegisterPlayer(displayName);

        // Obtener el catálogo desde la clase Facade
        string resultado = Facade.Instance.ShowPokemonCatalogue(displayName);

        // Responder con el resultado
        await ReplyAsync(resultado);
    }
}