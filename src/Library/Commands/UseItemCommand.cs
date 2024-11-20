using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands;

public class UseItemCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new();

    /// <summary>
    /// Implementa el comando 'choosepokemon'. Este comando permite que el entrenador
    /// cambie el Pokémon actual en batalla por otro de su equipo.
    /// </summary>
    [Command("changepokemon")]
    [Summary("Permite que el entrenador cambie de pokemon en la batalla.")]
    public async Task ExecuteAsync(int indice)
    {
        string displayName = Context.User.Username;
        JugadorPrincipal jugador = jugadores[displayName];

        if (jugador.PokemonActual != null)
        {
            jugador.UsarItem(indice, jugador.PokemonActual);
            await ReplyAsync("Usaste un ítem en tu Pokémon.");
        }
        else
        {
            await ReplyAsync("No tienes un Pokémon en batalla.");
        }
    }
}
    
