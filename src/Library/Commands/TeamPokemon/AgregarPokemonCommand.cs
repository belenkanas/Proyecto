using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon2team' del bot. Este comando le permite agregar al
/// entrenador hasta 6 pokemons del catálogo de pokemons.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AgregarPokemonCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'addpokemon2team'. Este comando muestra la lista de
    /// pókemons disponibles para usar en la batalla.
    /// </summary>
    [Command("agregarpokemon")]
    [Summary("Le permite agregar hasta 6 pokemons al equipo del jugador.")]
    // ReSharper disable once UnusedMember.Global
    public async Task ExecuteAsync([Remainder][Summary("IDPokemon en el catálogo (de 1 a 14)")] int id = 0)
    {
        string displayName = Context.User.Username;

        Facade.Instance.RegisterPlayer(displayName);

        string result = Facade.Instance.AddPokemonToTeam(displayName,id);
        //Envía respuesta al jugador
        await ReplyAsync(result);
    }
}