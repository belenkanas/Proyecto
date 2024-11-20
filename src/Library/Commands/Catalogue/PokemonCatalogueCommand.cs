using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'catalogopokemons' del bot. Este comando muestra
/// un catálogo de pokemons disponibles para utilizar en la batalla.
/// </summary>
public class PokemonCatalogueCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new Dictionary<string, JugadorPrincipal>();
    

    /// <summary>
    /// Implementa el comando 'catalogopokemons'. Este comando muestra la lista de
    /// pókemons disponibles para usar en la batalla.
    /// </summary>
    [Command("catalogopokemons")]
    [Summary("Muestra los pókemons disponibles para utilizar")]
    public async Task MostrarCatalogo()
    {
        string displayName = Context.User.Username;
        
        JugadorPrincipal jugadorPrincipal = jugadores[displayName];

        string resultado = jugadorPrincipal.MostrarCatalogo();
        await ReplyAsync(resultado);
    }
    
    
    
}
