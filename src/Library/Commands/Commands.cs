using Library;

namespace Ucu.Poo.DiscordBot.Commands;

using Discord.Commands;
using System.Threading.Tasks;

public class CommandModule : ModuleBase<SocketCommandContext>
{
    private JugadorPrincipal jugador = new JugadorPrincipal("Jugador");
    
    

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
