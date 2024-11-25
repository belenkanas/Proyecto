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
    }
}