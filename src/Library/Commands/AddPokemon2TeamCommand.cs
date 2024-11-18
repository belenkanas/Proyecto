using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon2team' del bot. Este comando le permite agregar al
/// entrenador hasta 6 pokemons del catálogo de pokemons.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AddPokemon2TeamCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'addpokemon2team'. Este comando muestra la lista de
    /// pókemons disponibles para usar en la batalla.
    /// </summary>
    [Command("addpokemon2team")]
    [Summary("Le permite agregar hasta 6 pokemons al equipo del jugador.")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("IDPokemon")] int id = 0)
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        string catalogo = PokemonNameCommand.Task();
        //Resolver static 
        string result = JugadorPrincipal.ElegirDelCatalogo(id);

        await ReplyAsync(result);
    }
}