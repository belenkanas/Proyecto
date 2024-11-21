using Discord.Commands;
using Library;
using Ucu.Poo.DiscordBot.Domain;

namespace Ucu.Poo.DiscordBot.Commands;

/// <summary>
/// Esta clase implementa el comando 'addpokemon2team' del bot. Este comando le permite agregar al
/// entrenador hasta 6 pokemons del catálogo de pokemons.
/// </summary>
// ReSharper disable once UnusedType.Global
public class AddPokemon2TeamCommand : ModuleBase<SocketCommandContext>
{
    private static CatalogoPokemons catalogo = new CatalogoPokemons();
    private static Dictionary<string, JugadorPrincipal> jugadores = new Dictionary<string, JugadorPrincipal>();
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
        // Verifica si el jugador ya existe, si no, lo crea
        if (!jugadores.ContainsKey(displayName))
        {
            jugadores[displayName] = new JugadorPrincipal(displayName);
        }

        JugadorPrincipal jugador = jugadores[displayName];

        // Valida el índice y trata de agregar el Pokémon al equipo
        if (id <= 0 || id > catalogo.Catalogo.Count)
        {
            await ReplyAsync("Por favor, ingrese un número válido correspondiente a un Pokémon del catálogo.");
            return;
        }

        string result = jugador.ElegirDelCatalogo(id).ToString();
        //Envía respuesta al jugador
        await ReplyAsync(result);
    }
}