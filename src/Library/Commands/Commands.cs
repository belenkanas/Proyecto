using Library;

namespace Ucu.Poo.DiscordBot.Commands;

using Discord.Commands;
using System.Threading.Tasks;

public class CommandModule : ModuleBase<SocketCommandContext>
{
    private JugadorPrincipal jugador = new JugadorPrincipal("Jugador");

    [Command("catalogo")]
    public async Task MostrarCatalogo()
    {
        string catalogo = jugador.MostrarCatalogo();
        await ReplyAsync(catalogo);
    }

    [Command("equipo")]
    public async Task MostrarEquipo()
    {
        string equipo = jugador.MostrarEquipo();
        if (equipo == null)
        {
            await ReplyAsync("No tienes ningún Pokémon en tu equipo.");
        }
        else
        {
            await ReplyAsync($"Tu equipo:\n{equipo}");
        }
    }

   
    

    [Command("cambiar")]
    public async Task CambiarPokemon(int indice)
    {
        string resultado = jugador.CambiarPokemonBatalla(indice);
        await ReplyAsync(resultado);
    }

    [Command("inventario")]
    public async Task MostrarInventario()
    {
        string inventario = jugador.MostrarInventario();
        await ReplyAsync(inventario);
    }

    [Command("usarItem")]
    public async Task UsarItem(int indiceItem)
    {
        if (jugador.PokemonActual != null)
        {
            jugador.UsarItem(indiceItem, jugador.PokemonActual);
            await ReplyAsync("Usaste un ítem en tu Pokémon.");
        }
        else
        {
            await ReplyAsync("No tienes un Pokémon en batalla.");
        }
    }
}
