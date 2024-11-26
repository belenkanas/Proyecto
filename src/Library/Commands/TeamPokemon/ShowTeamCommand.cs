using Discord.Commands;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Implementa el comando 'equipo' del bot para mostrar los Pokémon del equipo del jugador.
/// </summary>
public class ShowTeamCommand : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Implementa el comando 'equipo'.
    /// </summary>
    [Command("equipo")]
    [Summary("Muestra el equipo de Pokémon del jugador.")]
    public async Task MostrarEquipo()
    {
        string displayName = Context.User.Username;

        // Registrar al jugador si no existe
        Facade.Instance.RegisterPlayer(displayName);

        // Mostrar el equipo del jugador
        string resultado = Facade.Instance.ShowPlayerTeam(displayName);

        // Responder con el resultado
        await ReplyAsync(resultado);
    }
}