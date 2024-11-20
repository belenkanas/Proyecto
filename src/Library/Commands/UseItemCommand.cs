using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands;

public class UseItemCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new();

    /// <summary>
    /// Implementa el comando 'useitem'. Este comando permite que el entrenador
    /// use un item para atacar al oponente.
    /// </summary>
    [Command("useitem")]
    [Summary("Permite que el entrenador use un item en batalla.")]
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
            await ReplyAsync("No tienes un Pokémon en batalla. Usa el comando elegir pokemon");
        }
    }
}
    
