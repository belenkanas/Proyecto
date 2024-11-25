using Library;
using NUnit.Framework;
using Ucu.Poo.DiscordBot.Commands;

namespace LibraryTests;

[TestFixture]
public class CatalogueCommandTest
{
    public JugadorPrincipal jugador;
    public AttacksCatalogueCommand comando;

    [SetUp]
    public void SetUp()
    {
        jugador = new JugadorPrincipal("Pedro");

        jugador.ElegirDelCatalogo(0);
        jugador.ElegirDelCatalogo(1);
        jugador.ElegirDelCatalogo(2);
    }
}