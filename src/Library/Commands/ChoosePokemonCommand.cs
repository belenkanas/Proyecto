using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon' del bot. Este comando muestra
/// le permite al entrenador agregar Pokemones a su equipo.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ChoosePokemonCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'choosepokemon'. Este comando le permite al
    /// entrenador agregar Pokemones a su equipo
    /// </summary>
    [Command("choosepokemon")]
    [Summary("Permite que el entrenador elija un pokemon de su equipo para atacar con él")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync()
    {
        string displayName = CommandHelper.GetDisplayName(Context);
        
        //Tiene solamente disponibles los pokemons que eligió del catálogo mediante AddPokemon2Team
        //Falta ver cómo cambiar lo de Pokemon (static).
        string result = "";

        await ReplyAsync(result);
    }
}
