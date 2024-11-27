using Discord.Commands;
using Library;

namespace Ucu.Poo.DiscordBot.Commands;

public class RestrictionsCommand : ModuleBase<SocketCommandContext>
{


 [Command("restrictedpokemons")]
 [Summary("recibe una lista de pokemons que estan resringidos")]

 public async Task ExecuteAsync([Remainder] [Summary("hola")]int id)
 {

 }

 [Command("restricteditems")]
 [Summary("recibe lista de que items estan restringidos")]

 [Command("restrictedtypes")]
 [Summary("Recibe una lista de que tipos de pokemon estan restringidos")]
 public async Task ExecuteAsync([Remainder] [Summary("holaa")]string [] args)
 {
  
 }
}