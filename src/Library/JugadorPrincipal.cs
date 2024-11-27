namespace Library;
    /// <summary>
    /// Esta clase representa al usuario, quien hará uso de los distintos pokemones para su batalla
    /// </summary>
    public class JugadorPrincipal : IJugador
    {
        public string NombreJugador { get; set; }
        public List<IPokemon> EquipoPokemons { get; set; }
        public List<IItem> InventarioItems { get; set; }
        public bool TurnoActual { get; set; }
        public IPokemon PokemonActual { get; set; }

        public CatalogoPokemons CatalogoPokemon { get; set; }
        public CuraTotal Cura { get; }
        public Revivir Revivir { get; }
        public SuperPocion Pocion { get; }

        public JugadorPrincipal(string nombre)
        {
            NombreJugador = nombre;
            EquipoPokemons = new List<IPokemon>();
            TurnoActual = true;
            CatalogoPokemon = new CatalogoPokemons();
            Cura = new CuraTotal();
            Revivir = new Revivir();
            Pocion = new SuperPocion();
            InventarioItems = new List<IItem> { Pocion, Revivir, Cura };
        }
        
        /// <summary>
        /// Durante la batalla, podrá elegir un pokémon por su índice
        /// </summary>
        /// <param name="indice">índice del pokémon elegido para la batalla</param>
        /// <returns>Pokémon del equipo elegido para la batalla</returns>
        /// <exception cref="ArgumentOutOfRangeException">Se tira una excepción cuando el índice no entra dentro del rango
        /// de los integrantes del equipo</exception>
        public IPokemon ElegirPokemon(int indice)
        {
            try
            {
                if (indice < 0 || indice >= EquipoPokemons.Count || indice > 5)
                {
                    throw new ArgumentOutOfRangeException("Debe ingresar un valor entre 0 y "+ (EquipoPokemons.Count - 1));
                }

                PokemonActual = EquipoPokemons[indice];
                PokemonActual.Ataques = EquipoPokemons[indice].Ataques;
                return PokemonActual;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Debe ingresar un valor entre 0 y "+ (EquipoPokemons.Count - 1));
            }
            finally
            {
                Console.WriteLine("Gracias por jugar!");
            }
            return null;
        }

        /// <summary>
        /// El pokémon a atacar elige un ataque para 
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="enemigo"></param>
        /// <param name="indiceAtaque"></param>
        public void ElegirAtaque(IPokemon pokemon, IPokemon enemigo, int indiceAtaque)
        {
            var msg = PokemonActual.UsarAtaque(indiceAtaque, enemigo, this); // Supongamos que elegimos un ataque del Pokémon
            var a = pokemon;
            var b = enemigo;
            Console.WriteLine(msg);
        }

        /// <summary>
        /// Muestra el turno del pokémon en la batalla
        /// </summary>
        /// <returns>Turno actual</returns>
        public bool MostrarTurno()
        {
            if (TurnoActual)
            {
                Console.WriteLine($"{NombreJugador} es tu turno");
            }
            else
            {
                Console.WriteLine("Es turno del oponente");
            }
            return TurnoActual;
        }

        /// <summary>
        /// Muestra el catálogo con todos los pokémones disponibles para formar un equipo
        /// </summary>
        /// <param name="catalogo"></param>
        public string MostrarCatalogo()
        {
            return CatalogoPokemon.MostrarCatalogo();
        }

        /// <summary>
        /// Muestra los ataques disponibles que tiene el pokémon a través de su índice dentro del equipo
        /// </summary>
        /// <param name="indice"></param>
        public string MostrarAtaquesDisponibles(int indice)
        {
            string cadena = "";
            if (indice >= 0 && indice < EquipoPokemons.Count)
            {
                IPokemon pokemon = EquipoPokemons[indice];
                pokemon.AtaquesPorTipo();
                Console.WriteLine($"Ataques disponibles para {pokemon.Nombre} de tipo {pokemon.TipoPokemon.NombreTipo}:\n");

                for (int i = 0; i < pokemon.Ataques.Count; i++)
                {
                    cadena += $"{i + 1}. Nombre: {pokemon.Ataques[i].Nombre} Tipo: {pokemon.Ataques[i].TipoAtaque.NombreTipo} Daño: {pokemon.Ataques[i].DañoBase} Es especial: {pokemon.Ataques[i].EsEspecial}.\n";
                }
            }
            else
            {
                cadena += "Índice inválido";
            }
            return cadena;
        }

        /// <summary>
        /// Del catálogo elegir 6 pokémons para agregar a su equipo
        /// </summary>
        /// <param name="indice">número de pokémon en la lista del catálogo</param>
        public Pokemon ElegirDelCatalogo(int indice)
        {
            int indiceCatalogo = indice - 1;
            
            if (indiceCatalogo < 0 || indiceCatalogo > CatalogoPokemon.Catalogo.Count)
            {
                Console.WriteLine("Índice inválido");
                return null;
            }
            
            if (EquipoPokemons.Count < 6)
            {
                IPokemon pokemon = CatalogoPokemon.Catalogo[indiceCatalogo];
                
                if (EquipoPokemons.Count == 1)
                {
                    PokemonActual = pokemon;
                }
               
                EquipoPokemons.Add(pokemon);
                return (Pokemon)pokemon;
            }
            else
            {
                Console.WriteLine("Ya tienes 6 pokémones en tu equipo");
                return null;
            }
        }
        
        /// <summary>
        /// Muestra el equipo formado
        /// </summary>
        /// <returns>Todos los pokémon del equipo con su nombre y tipo</returns>
        public string MostrarEquipo()
        {
            string cadenaEquipo = "";

            if (EquipoPokemons.Count > 0)
            {
                foreach (IPokemon pokemon in EquipoPokemons)
                {
                    cadenaEquipo += $"{pokemon.Nombre}, {pokemon.TipoPokemon.NombreTipo}\n";
                }
                
                return cadenaEquipo;
            }
            else
            {
                return cadenaEquipo = null;
            }
        }

        /// <summary>
        /// Verifica si todos los pokemones del equipo están derrotados.
        /// </summary>
        /// <returns>True si todos los Pokemones están derrotados, False en caso contrario.</returns>
        public bool PokemonesDerrotados()
        {
            foreach (IPokemon pokemon in EquipoPokemons)
            {
                if (pokemon.VidaActual > 0)     //si al menos uno tiene vida mayor a 0 la batalla sigue
                {
                    return false;
                }
            }
            return true;        // sino se termina
        }

        /// <summary>
        /// Cambia el pokemon actual por otro del equipo
        /// </summary>
        /// <param name="indice">Indice del Pokemon en el equipo</param>
        public string CambiarPokemonBatalla(int indice)
        {
            if (indice < 0 || indice >= EquipoPokemons.Count)
            {
                return "Indice del Pokemon inválido";
            }
            else
            {
                if (PokemonActual != EquipoPokemons[indice])
                {
                    PokemonActual = EquipoPokemons[indice];
                    TurnoActual = false;
                    return $"{NombreJugador} ha cambiado de pokémon a {PokemonActual.Nombre}";
                }
                else
                {
                    return "Ingrese otro índice";
                }
            }
        }
        
        public double UsarItem(int indiceItem, IPokemon pokemon)
        {
            if (indiceItem < 0 || indiceItem >= InventarioItems.Count)
            {
                Console.WriteLine("Índice de ítem inválido.");
                return 0;
            }
            else
            {
                IItem item = InventarioItems[indiceItem];
                if (item == Cura)
                {
                    Cura.Usar(pokemon);
                    TurnoActual = false; // Al usar un ítem, se pierde el turno
                    return pokemon.VidaActual;
                }
                else if (item == Revivir)
                {
                    TurnoActual = false; // Al usar un ítem, se pierde el turno
                    return Revivir.Usar(pokemon.VidaActual, pokemon.VidaTotal);
                }
                else
                {
                    TurnoActual = false; // Al usar un ítem, se pierde el turno
                    return Pocion.Usar(pokemon.VidaActual, pokemon.VidaTotal);
                }
            }
        }

        /// <summary>
        /// Muestra el inventario del jugador
        /// </summary>
        public string MostrarInventario()
        {
            string cadena = "Inventario de Items:\n";
            for (int i = 0; i < InventarioItems.Count; i++)
            {
                cadena += $"{i + 1}. {InventarioItems[i].NombreItem} \n";
            }

            return cadena;
        }

        /// <summary>
        /// Si es el turno del jugador, tiene la opción de rendirse de la batalla. Sino la batalla seguirá.
        /// </summary>
        /// <returns></returns>
        public bool Rendirse()
        {
            if (TurnoActual)
            {
                return true;
            }

            return false;
        }
    }