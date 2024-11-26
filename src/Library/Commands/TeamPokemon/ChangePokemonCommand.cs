using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

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
        Facade.Instance.RegisterPlayer(displayName);
        

        // Usa el método CambiarPokemonpara cambiar el Pokémon activo
        string resultado = Facade.Instance.CambiarPokemon(displayName, indice);

        await ReplyAsync(resultado);
    }

}