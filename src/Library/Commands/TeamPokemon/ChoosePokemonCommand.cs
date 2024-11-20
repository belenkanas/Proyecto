using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon' del bot. Este comando muestra
/// le permite al entrenador agregar Pokemones a su equipo.
/// </summary>
public class ChoosePokemonCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new();

    /// <summary>
    /// Implementa el comando 'choosepokemon'. Este comando permite que el entrenador
    /// cambie el Pokémon actual en batalla por otro de su equipo.
    /// </summary>
    [Command("choosepokemon")]
    [Summary("Permite que el entrenador elija un Pokémon de su equipo para usar en batalla.")]
    public async Task ExecuteAsync([Summary("Índice del Pokémon a elegir (0 a 5)")] int index)
    {
        string displayName = Context.User.Username;

        // Verifica si el jugador ya existe
        if (!jugadores.ContainsKey(displayName))
        {
            await ReplyAsync("No tienes un equipo registrado. Usa el comando 'addpokemon2team' para agregar Pokémon.");
            return;
        }

        JugadorPrincipal jugadorPrincipal = jugadores[displayName];

        // Usa el método CambiarPokemonBatalla para cambiar el Pokémon activo
        string resultado = jugadorPrincipal.ElegirPokemon(index).ToString();

        await ReplyAsync(resultado);
    }
}

