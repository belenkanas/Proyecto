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
    private readonly CatalogoPokemons catalogoPokemons;

    public PokemonCatalogueCommand()
    {
        catalogoPokemons = new CatalogoPokemons();
    }

    /// <summary>
    /// Implementa el comando 'catalogo'. Este comando muestra la lista de
    /// pókemons disponibles para usar en la batalla.
    /// </summary>
    [Command("catalogopokemon")]
    [Summary("Muestra los pókemons disponibles para utilizar")]
    public async Task MostrarCatalogo()
    {
        string catalogo = catalogoPokemons.MostrarCatalogo();
        
        // Si el catálogo está vacío, mostramos un mensaje de error
        if (string.IsNullOrEmpty(catalogo))
        {
            await ReplyAsync("No hay Pokémon disponibles en el catálogo.");
            return;
        }

        // Enviamos el catálogo al canal de Discord
        await ReplyAsync($"**Catálogo de Pokémon disponibles:**\n{catalogo}");
    }
    
    
    
}
