//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
/*
using System;
using ClassLibrary;
using Library;

namespace EntregaUno
{
    /*Aca el Program llama a la fachada. Esto se usa para simplificar código, mediante la delegación. El programa es el siguiente:
    */
    /*class Program
    {
        static void Main(string[] args)
        {
            // Crear la fachada de batalla
            BatallaFacade batalla = new BatallaFacade("Ash", "Misty");

            // Crear Pokémons
            Pokemon pikachu = new Pokemon("Pikachu", new Electrico(), 100);
            Pokemon squirtle = new Pokemon("Squirtle", new Agua(), 100);

            // Añadir ataques a los Pokémons
            batalla.AgregarAtaqueAPokemon(pikachu, new Ataque("Impactrueno", new Electrico(), 50, false));
            batalla.AgregarAtaqueAPokemon(squirtle, new Ataque("Pistola Agua", new Agua(), 40, false));

            // Añadir Pokémons a los equipos de los jugadores
            batalla.AgregarPokemonAJugador("Ash", pikachu);
            batalla.AgregarPokemonAJugador("Misty", squirtle);

            // Iniciar batalla
            batalla.IniciarBatalla();

            // Simulación de turnos
            batalla.RealizarAtaque("Ash", 0); // Pikachu ataca primero
        }
    }
}*/
