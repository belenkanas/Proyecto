using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon' del bot. Este comando muestra
/// le permite al entrenador agregar Pokemones a su equipo.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AddPokemonCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'addpokemon'. Este comando le permite al
    /// entrenador agregar Pokemones a su equipo
    /// </summary>
    [Command("addpokemon")]
    [Summary("Permite que el entrenador agregue pokemons a su equipo")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        
        //Falta ver cómo cambiar lo de Pokemon (porque toma el api de pokemones).
        string result = BatallaFacade.AgregarPokemonAJugador(displayName, new Pokemon("Squirtle", new Agua(), 100));

        await ReplyAsync(result);
    }
}
