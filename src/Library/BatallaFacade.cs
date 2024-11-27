namespace Library
{   
    /*
    En la fachada vemos los métodos de las clases implementados.
    Acá se crean los jugadores, se les agregan los pokemones y los ataques respectivamente.
    Además, llama a las funciones necesarias para poder realizar ataques entre jugadores.
    Todo esto después será utilizado en el Program.
    */
    public class BatallaFacade
    {
        public JugadorPrincipal jugador1 { get; private set; }
        public JugadorPrincipal jugador2 { get; private set; }
        public List<string> historialMovimientos;

        
        public int contadorTurnos; // Contador de turnos
        public bool jugador1Ataco; // Indicador de que el jugador 1 atacó en este turno
        public bool jugador2Ataco; // Indicador de que el jugador 2 atacó en este turno
        public bool BatallaEnCurso { get; private set; }
        public List<JugadorPrincipal> listaDeEspera {get; private set;}
        public BatallaFacade(JugadorPrincipal jugador1, JugadorPrincipal jugador2)
        {
            this.jugador1 = jugador1; //El constructor toma como parámetro a los rivales de la partida
            this.jugador2 = jugador2;
           
            contadorTurnos = 1; // Inicializamos el contador de turnos en 1
            jugador1Ataco = false; // Inicializamos en falso, porque aún no ha atacado
            jugador2Ataco = false; // Inicializamos en falso, porque aún no ha atacado
            BatallaEnCurso = true;
            listaDeEspera = new List<JugadorPrincipal>() { jugador1, jugador2 };
            historialMovimientos = new List<string>();
        }
        
        public string IniciarBatalla() //Muestra el inicio del juego, especificando el nombre del jugador y el pokemon elegido.
        {
            string resultado = "";
            resultado += $"{jugador1.NombreJugador} comienza la batalla con {jugador1.PokemonActual.Nombre}\n";
            resultado += $"{jugador2.NombreJugador} comienza la batalla con {jugador2.PokemonActual.Nombre}\n";
            resultado += $"¡La batalla ha comenzado! Turno {contadorTurnos}.";
            return resultado;
        }

        // Mediante este método, toma como parámetro al jugador (ya que es quien elige el ataque y quien lo usa), y el ataque elegido de la lista.
        // Luego devuelve la vida del pokemon atacado.
        public string RealizarAtaque(string nombreJugador, int indiceAtaque)
        {
            if (jugador1.NombreJugador == nombreJugador)
            {
                jugador1Ataco = true; // Indicamos que el jugador 1 atacó
                VerificarAtaques();
                return (jugador1.ElegirAtaque(jugador1.PokemonActual, jugador2.PokemonActual, indiceAtaque));
            }
            else if (jugador2.NombreJugador == nombreJugador)
            {
                jugador2Ataco = true; // Indicamos que el jugador 2 atacó
                VerificarAtaques();
                return (jugador2.ElegirAtaque(jugador2.PokemonActual, jugador1.PokemonActual, indiceAtaque));
            }
            
            return "No se pudo identificar al jugador que realiza el ataque";
        }
        
        

        // Verificamos si ambos jugadores ya han atacado para completar el turno
        public int VerificarAtaques()
        {
            if (jugador1Ataco && jugador2Ataco)
            {
                contadorTurnos++; // Incrementamos el turno después de que ambos han atacado
                
                jugador1Ataco = false; // Reseteamos el estado para el próximo turno
                jugador2Ataco = false; // Reseteamos el estado para el próximo turno
                VerificarGanador();
                Console.WriteLine($"¡El turno {contadorTurnos - 1} ha finalizado! \n" +
                       $"Comienza el turno {contadorTurnos}.");
                return contadorTurnos;
            }

            return contadorTurnos;
        }
        
        public void RegistrarMovimiento(JugadorPrincipal atacante, JugadorPrincipal defensor, int indiceAtaque)
        {
            atacante.PokemonActual.AtaquesPorTipo();
            string nombreAtaque = atacante.PokemonActual.Ataques[indiceAtaque].Nombre;
            double dañoInfligido = defensor.PokemonActual.VidaTotal - defensor.PokemonActual.VidaActual;

            string movimiento = $"Turno {contadorTurnos}: {atacante.NombreJugador} ({atacante.PokemonActual.Nombre}) " +
                                $"usó {nombreAtaque} contra {defensor.PokemonActual.Nombre} e infligió {dañoInfligido} de daño.";

            historialMovimientos.Add(movimiento);
        }

        // Método que obtiene el historial de los movimientos realizados
        public string ObtenerHistorialMovimientos()
        {
            if (historialMovimientos.Count == 0)
            {
                return "No se han registrado movimientos aún.";
            }

            return string.Join("\n", historialMovimientos);
        }
        
        public string VerificarGanador()
        {
            if (jugador1.PokemonesDerrotados())
            {
                BatallaEnCurso = false;
                return $"{jugador1.NombreJugador} ha sido derrotado " +
                                  $"{jugador2.NombreJugador} GANÓ";
            }
            if (jugador2.PokemonesDerrotados())
            {
                BatallaEnCurso = false;
                return $"{jugador2.NombreJugador} ha sido derrotado " +
                       $"{jugador1.NombreJugador} GANÓ";
            }
            
            BatallaEnCurso = true;
            return "La batalla continúa";
        }
        
        //Muestra el turno del jugador.
        public bool VerificarTurno(string nombreJugador)
        {
            if (jugador1.NombreJugador == nombreJugador)
            {
                return jugador1.MostrarTurno();
            }
            else if (jugador2.NombreJugador == nombreJugador)
            {
                return jugador2.MostrarTurno();
            }
            return false;
        }

        // Método para obtener el turno actual
        public int ObtenerTurnoActual()
        {
            return contadorTurnos;
        }
        
        /// <summary>
        /// Ejecuta el cambio de Pokemon y gestiona el cambio de turno.
        /// </summary>
        /// <param name="nombreJugador"></param>
        /// <param name="indicePokemonACambiar"></param>
        public void CambiarPokemon(string nombreJugador, int indicePokemonACambiar)
        {
            if (jugador1.NombreJugador == nombreJugador)
            {
                if (indicePokemonACambiar >= 0 && indicePokemonACambiar < jugador1.EquipoPokemons.Count)
                {
                    jugador1.CambiarPokemonBatalla(indicePokemonACambiar);
                    Console.WriteLine($"{jugador1.NombreJugador} ha cambiado de pokemon");
                    jugador1.TurnoActual = false;      // el jugador pierde el turno al cambiar de pokémon
                }
                else
                {
                    Console.WriteLine("Índice no válido");
                }
            }
            else if (jugador2.NombreJugador == nombreJugador)
            {
                if (indicePokemonACambiar >= 0 && indicePokemonACambiar < jugador2.EquipoPokemons.Count)
                {
                    jugador2.CambiarPokemonBatalla(indicePokemonACambiar);
                    Console.WriteLine($"{jugador2.NombreJugador} ha cambiado de pokemon");
                    jugador2.TurnoActual = false;
                }  
                else
                {
                    Console.WriteLine("Índice no válido");
                }
            }
        }

        /// <summary>
        /// Verificar si se pierde el turno después de una acción
        /// </summary>
        public string VerificarFinTurno(JugadorPrincipal jugador)
        {
            if (!jugador.TurnoActual)
            {
                return $"{jugador.NombreJugador} ha perdido su turno al cambiar de Pokémon.";
            }

            return $"{jugador.NombreJugador} es tu turno";
        }

        /// <summary>
        /// Gestiona el turno actual
        /// </summary>
        public bool BatallaSigue()
        {
            if (jugador1.PokemonesDerrotados() || jugador2.PokemonesDerrotados())
            {
                return BatallaEnCurso = false;
            }
            
            return BatallaEnCurso = true;
        }

        /// <summary>
        /// Método para unirse a la lista de espera
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public string ListaDeEspera(JugadorPrincipal jugador)
        {
            if (!listaDeEspera.Contains(jugador))
            {
                listaDeEspera.Add(jugador);
                return $"{jugador.NombreJugador} fue agregado a la lista de espera";
            }
            else
            {
                return $"{jugador.NombreJugador} ya está agregado a la lista de espera";
            }
        }

        /// <summary>
        /// Muestra los jugadores que están en la lista de espera para jugar
        /// </summary>
        public string MostrarListaDeEspera()
        {
            string resultado = "";
            if (listaDeEspera.Count == 0)
            {
                resultado += "Lista de espera vacía";
            }
            else
            {
                Console.WriteLine("Jugadores en la lista de espera:");
                foreach (JugadorPrincipal jugador in listaDeEspera)
                {
                    resultado += $"{jugador.NombreJugador}\n";
                }
            }
            return resultado;
        }

        /// <summary>
        /// Se fija si en la lista de espera hay 2 jugadores o más esperando para comenzar una batalla,
        /// en el caso de que lo haya comienza la batalla entre los dos primeros jugadores de la lista
        /// y los elimina de la lista de espera. Sino mostrará que no hay jugadores suficientes para iniciar
        /// una batalla
        /// </summary>
        public string IniciarBatallaListaDeEspera(Random random = null)
        {
            if (listaDeEspera.Count >= 2)
            {
                JugadorPrincipal jugadorLista = listaDeEspera[0];
                JugadorPrincipal jugadorLista2 = listaDeEspera[1];
                listaDeEspera.Remove(jugadorLista);
                listaDeEspera.Remove(jugadorLista2);

                NotificarInicio(jugadorLista);
                NotificarInicio(jugadorLista2);

                if (random == null)
                {
                    random = new Random();
                }
                
                bool primerTurno = random.Next(2) == 0;     // compara si el número generado es 0 (0 = true)(1 = false)
                
                if (primerTurno)
                {
                    jugadorLista.TurnoActual = true;
                    jugadorLista2.TurnoActual = false;
                    return $"{jugadorLista.NombreJugador} es el primero en jugar";
                }
                else
                {
                    jugadorLista.TurnoActual = false;
                    jugadorLista2.TurnoActual = true;
                    return $"{jugadorLista2.NombreJugador} es el primero en jugar";
                }
            }
            else
            {
                return "No hay jugadores suficientes para comenzar una batalla";
            }
        }

        public string NotificarInicio(JugadorPrincipal jugador)
        {
            return $"{jugador.NombreJugador} la batalla ha comenzado";
        }

        /// <summary>
        /// Verifica si el turno del jugador es verdadero, si es así tiene la opción de rendirse de la batalla y lanzará
        /// un mensaje con el jugador oponente ganador. En caso contrario, la batalla sigue.
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public string RendirseBatalla(JugadorPrincipal jugador)
        {
            if (!jugador.TurnoActual) 
            { 
                return "La batalla sigue";
            }
            if (jugador == jugador1) 
            {
                BatallaEnCurso = false;
                return $"{jugador2.NombreJugador} GANADOR";
            }
            else
            {
                BatallaEnCurso = false; 
                return $"{jugador1.NombreJugador} GANADOR";
            }
        }

        /// <summary>
        /// Si es el turno del jugador muestra en la pantalla que es su turno y le pregunta si se quiere rendir,
        /// en el caso de que elija la opción "Si" el jugador se rinde y gana su oponente (la batalla termina). Si
        /// elije la opción "No" le mostrará los ataques que tiene disponibles el pokemon actual del jugador. Pero en
        /// el caso de que sea su turno e ingrese otra opción diferente a "1" y "2", mostrará que la opción no es válida.
        /// Si no es el turno del jugador, la batalla sigue, no podrá rendirse.
        /// </summary>
        /// <param name="jugador"></param>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public string Acciones(JugadorPrincipal jugador, string opcion)
        {
            if (jugador.TurnoActual)
            {
                Console.WriteLine($"Turno de {jugador1.NombreJugador}");
                Console.WriteLine("¿Quiere rendirse?\n" +
                                  "1. Si\n" +
                                  "2. No");

                if (opcion == "1")
                {
                    return RendirseBatalla(jugador);
                }
                else if (opcion == "2")
                {
                    jugador1.PokemonActual.AtaquesPorTipo();
                    return jugador1.PokemonActual.Ataques.ToString();
                }
            }
            else
            {
                return "La batalla sigue";
            }
            
            return "Opción no válida"; 
        }

        public string ReglasPersonalizadas()
        {
            return jugador1.Reglas + jugador1.MostrarCatalogo() + jugador1.MostrarInventario();
        }

        public void Acepta(JugadorPrincipal oponente)
        {
            if (oponente.AceptaReglas("1"))
            {
                IniciarBatalla();
            }
            else
            {
                BatallaEnCurso = false;   
            }
        }
    }
}