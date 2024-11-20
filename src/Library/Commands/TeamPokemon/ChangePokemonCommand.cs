using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands;

public class ChangePokemonCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new();

    /// <summary>
    /// Implementa el comando 'cambiarpokemon'. Este comando permite que el entrenador
    /// cambie el Pokémon actual en batalla por otro de su equipo.
    /// </summary>
    [Command("changepokemon")]
    [Summary("Permite que el entrenador cambie de pokemon en la batalla.")]
    public async Task ExecuteAsync(int indice)
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
        string resultado = jugadorPrincipal.CambiarPokemonBatalla(indice).ToString();

        await ReplyAsync(resultado);
    }

}