using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'elegirpokemon' del bot. Este comando le
/// permite al entrenador elegir un pokemon de su equipo para usar en la batalla.
/// </summary>
public class ChoosePokemonCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new();

    /// <summary>
    /// Implementa el comando 'elegirpokemon'. Este comando permite que el entrenador
    /// elija un pokemon de su equipo para usar en batalla.
    /// </summary>
    [Command("elegirpokemon")]
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
        
        string resultado = jugadorPrincipal.ElegirPokemon(index).ToString();

        await ReplyAsync(resultado);
    }
}

