using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'equipo' del bot. Este comando le
/// permite al entrenador ver los pokemons de su equipo.
/// </summary>
public class ShowTeamCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new Dictionary<string, JugadorPrincipal>();

    /// <summary>
    /// Implementa el comando 'equipo'. Este comando muestra el equipo
    /// de pokemones formados por el jugador.
    /// </summary>
    [Command("equipo")]
    [Summary("Muestra el equipo de pokemons del jugador")]
    public async Task MostrarEquipo()
    {
        string displayName = Context.User.Username;
        JugadorPrincipal jugadorPrincipal = jugadores[displayName];
        try
        {
            string equipo = jugadorPrincipal.MostrarEquipo();
            if (string.IsNullOrWhiteSpace(equipo))
            {
                await ReplyAsync("Tu equipo está vacío. Usa el comando 'addpokemon2team' para agregar Pokémon.");
            }
            else
            {
                await ReplyAsync(equipo);
            }
        }
        catch (Exception ex)
        {
            await ReplyAsync("Ocurrió un error al intentar mostrar tu equipo. Inténtalo de nuevo más tarde.");
            Console.WriteLine(ex);
        }
    }
}