using System.ComponentModel;
using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'catalogoataques' del bot. Este comando muestra
/// un catálogo de ataques disponibles para utilizar en la batalla.
/// </summary>
public class AttacksCatalogueCommand : ModuleBase<SocketCommandContext>
{
    private static Dictionary<string, JugadorPrincipal> jugadores = new Dictionary<string, JugadorPrincipal>();

    /// <summary>
    /// Implementa el comando 'catalogoataques'. Este comando muestra la lista de
    /// ataques disponibles del pokemon en batalla para usar en la misma.
    /// </summary>
    [Command("catalogoataques")]
    [Summary("Muestra los ataques disponibles para utilizar")]
    public async Task ExecuteAsync([Summary("Índice del pokemón en el equipo (1-6)")] int indice)
    {
        string displayName = Context.User.Username;
        // Verifica si el jugador ya existe
        if (!jugadores.ContainsKey(displayName))
        {
            await ReplyAsync("No tienes un equipo registrado. Usa el comando 'addpokemon2team' para agregar Pokémon.");
            return;
        }

        JugadorPrincipal jugadorPrincipal = jugadores[displayName];

        // Valida el índice del Pokémon en el equipo
        if (indice < 1 || indice > jugadorPrincipal.EquipoPokemons.Count)
        {
            await ReplyAsync("Por favor, ingrese un índice válido de Pokémon en su equipo (1-6).");
            return;
        }

        // Muestra los ataques del Pokémon seleccionado
        string ataques = jugadorPrincipal.MostrarAtaquesDisponibles(indice - 1); // Ajusta índice para base 0
        await ReplyAsync(ataques);
    }
}