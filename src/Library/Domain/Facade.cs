using Library;

namespace Ucu.Poo.DiscordBot.Domain;

/// <summary>
/// Esta clase recibe las acciones y devuelve los resultados que permiten
/// implementar las historias de usuario.
/// </summary>
public class Facade
{
    private static Facade? _instance;
    private Dictionary<string, JugadorPrincipal> jugadores;
    private Dictionary<string, BatallaFacade> batallasActivas;

    private Facade()
    {
        this.WaitingList = new WaitingList();
        this.BattlesList = new BattlesList();
        this.jugadores = new Dictionary<string, JugadorPrincipal>();
        this.batallasActivas = new Dictionary<string, BatallaFacade>();
        this.restrictedpokemons = new List<Restrictions>();
    }

    public static Facade Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Facade();
            }

            return _instance;
        }
    }

    public static void Reset()
    {
        _instance = null;
    }

    private WaitingList WaitingList { get; }
    
    private BattlesList BattlesList { get; }

    /// <summary>
    /// Registra un nuevo jugador si no existe.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    public void RegisterPlayer(string displayName)
    {
        if (!jugadores.ContainsKey(displayName))
        {
            jugadores[displayName] = new JugadorPrincipal(displayName);
        }
    }

    /// <summary>
    /// Muestra el catálogo de Pokémon de un jugador.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>El catálogo de Pokémon.</returns>
    public string ShowPokemonCatalogue(string displayName)
    {
        if (!jugadores.ContainsKey(displayName))
        {
            return $"{displayName} no está registrado. Usa el comando para registrarte.";
        }

        JugadorPrincipal jugador = jugadores[displayName];
        string catalogo = jugador.MostrarCatalogo();

        if (string.IsNullOrWhiteSpace(catalogo))
        {
            return "Tu catálogo de Pokémon está vacío.";
        }

        return $"Catálogo de Pokémon de {displayName}:\n{catalogo}";
    }

    /// <summary>
    /// Muestra el equipo de un jugador.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>El equipo de Pokémon del jugador.</returns>
    public string ShowPlayerTeam(string displayName)
    {
        if (!jugadores.ContainsKey(displayName))
        {
            return $"{displayName} no está registrado. Usa el comando para registrarte.";
        }

        JugadorPrincipal jugador = jugadores[displayName];
        string equipo = jugador.MostrarEquipo();

        if (string.IsNullOrWhiteSpace(equipo))
        {
            return "Tu equipo está vacío. Usa el comando 'agregarpokemon' para agregar Pokémon.";
        }

        return $"Equipo de {displayName}:\n{equipo}";
    }



    /// <summary>
    /// Agrega un jugador a la lista de espera.
    /// </summary>
    /// <param name="displayName">El nombre del jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string AddTrainerToWaitingList(string displayName)
    {
        if (this.WaitingList.AddTrainer(displayName))
        {
            return $"{displayName} agregado a la lista de espera";
        }

        return $"{displayName} ya está en la lista de espera";
    }

    /// <summary>
    /// Remueve un jugador de la lista de espera.
    /// </summary>
    /// <param name="displayName">El jugador a remover.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string RemoveTrainerFromWaitingList(string displayName)
    {
        if (this.WaitingList.RemoveTrainer(displayName))
        {
            return $"{displayName} removido de la lista de espera";
        }
        else
        {
            return $"{displayName} no está en la lista de espera";
        }
    }

    /// <summary>
    /// Obtiene la lista de jugadores esperando.
    /// </summary>
    /// <returns>Un mensaje con el resultado.</returns>
    public string GetAllTrainersWaiting()
    {
        if (this.WaitingList.Count == 0)
        {
            return "No hay nadie esperando";
        }

        string result = "Esperan: ";
        foreach (Trainer trainer in this.WaitingList.GetAllWaiting())
        {
            result = result + trainer.DisplayName + "; ";
        }

        return result;
    }

    /// <summary>
    /// Determina si un jugador está esperando para jugar.
    /// </summary>
    /// <param name="displayName">El jugador.</param>
    /// <returns>Un mensaje con el resultado.</returns>
    public string TrainerIsWaiting(string displayName)
    {
        Trainer? trainer = this.WaitingList.FindTrainerByDisplayName(displayName);
        if (trainer == null)
        {
            return $"{displayName} no está esperando";
        }

        return $"{displayName} está esperando";
    }

    private string CreateBattle(string playerDisplayName, string opponentDisplayName)
    {
        this.WaitingList.RemoveTrainer(playerDisplayName);
        this.WaitingList.RemoveTrainer(opponentDisplayName);

        JugadorPrincipal jugador = new JugadorPrincipal(playerDisplayName);
        JugadorPrincipal oponente = new JugadorPrincipal(opponentDisplayName);

        BatallaFacade batalla = new BatallaFacade(jugador, oponente);
        batallasActivas[playerDisplayName] = batalla;
        batallasActivas[opponentDisplayName] = batalla;

        BattlesList.AddBattle(playerDisplayName, opponentDisplayName);
        return $"Comienza {playerDisplayName} vs {opponentDisplayName}";
    }

    /// <summary>
    /// Crea una batalla entre dos jugadores.
    /// </summary>
    public string StartBattle(string playerDisplayName, string? opponentDisplayName)
    {
        Trainer? opponent;

        if (!OpponentProvided() && !SomebodyIsWaiting())
        {
            return "No hay nadie esperando";
        }

        if (!OpponentProvided())
        {
            opponent = this.WaitingList.GetAnyoneWaiting();
            return this.CreateBattle(playerDisplayName, opponent!.DisplayName);
        }

        opponent = this.WaitingList.FindTrainerByDisplayName(opponentDisplayName!);

        if (!OpponentFound())
        {
            return $"{opponentDisplayName} no está esperando";
        }

        return this.CreateBattle(playerDisplayName, opponent!.DisplayName);

        bool OpponentProvided() => !string.IsNullOrEmpty(opponentDisplayName);
        bool SomebodyIsWaiting() => this.WaitingList.Count != 0;
        bool OpponentFound() => opponent != null;
    }

    public string RealizarAtaque(string jugador, int indiceAtaque)
    {
        if (batallasActivas.ContainsKey(jugador))
        {
            BatallaFacade batalla = batallasActivas[jugador];
            batalla.RealizarAtaque(jugador, indiceAtaque);
            return $"Ataque realizado";
        }

        return "No hay batalla activa";
    }

    public string ElegirPokemon(string displayName, int pokemon)
    {
        
        JugadorPrincipal jugador = jugadores[displayName];
        // Verifica si el jugador ya existe
        if (!jugadores.ContainsKey(displayName))
        {
            return "No tienes un equipo registrado. Usa el comando 'agregarpokemon' para agregar Pokémon a tu equipo.";
        }
        IPokemon pokemonelegido = jugador.ElegirPokemon(pokemon);
        string mensaje = $"¡{pokemonelegido.Nombre} ha sido elegido para la batalla!";

        return mensaje;
    }
    public string CambiarPokemon(string jugador, int indicePokemon)
    {
        if (batallasActivas.ContainsKey(jugador))
        {
            BatallaFacade batalla = batallasActivas[jugador];
            batalla.CambiarPokemon(jugador, indicePokemon);
            return "Pokémon cambiado.";
        }
        return "No estás en una batalla activa.";
    }

    public string MostrarAtaques(string displayName, int indice)
    {
        JugadorPrincipal jugador = jugadores[displayName];
        // Verifica si el jugador ya existe
        if (!jugadores.ContainsKey(displayName))
        {
            return "No tienes un equipo registrado. Usa el comando 'agregarpokemon' para agregar Pokémon.";
        }

        // Valida el índice del Pokémon en el equipo
        if (indice < 1 || indice > jugador.EquipoPokemons.Count)
        {
            return "Por favor, ingrese un índice válido de Pokémon en su equipo (1-6).";
            
        }

        // Muestra los ataques del Pokémon seleccionado
        return jugador.MostrarAtaquesDisponibles(indice - 1); // Ajusta índice para base 0
        
    }
    public string VerificarEstadoBatalla(string jugador)
    {
        if (batallasActivas.ContainsKey(jugador))
        {
            BatallaFacade batalla = batallasActivas[jugador];
            return batalla.VerificarGanador();
        }
        return "No estás en una batalla activa.";
    }

    public string AddPokemonToTeam(string playerName, int pokemonId)
    {
        if (!jugadores.ContainsKey(playerName))
        {
            return "Jugador no registrado. Usa algún comando para registrarte.";
        }

        JugadorPrincipal jugador = jugadores[playerName];
        Pokemon pokemon = jugador.ElegirDelCatalogo(pokemonId);

        return pokemon != null
            ? $"¡{pokemon.Nombre} ha sido agregado a tu equipo!"
            : "No se pudo agregar el Pokémon. Verifica el ID y que tengas espacio en el equipo.";
    }

    public string MostrarVidaPokemon(string displayName, int idpokemon)
    {
        JugadorPrincipal jugadorPrincipal = jugadores[displayName];
        IPokemon pokemon = jugadorPrincipal.ElegirPokemon(idpokemon);
        string resultado = pokemon.MostrarVida();
        return resultado;
    }

    public string MostrarTurno(string jugador)
    {
        JugadorPrincipal jugadorPrincipal = jugadores[jugador];
        batallasActivas.TryGetValue(jugador, out BatallaFacade batalla);
        
        if (batalla.VerificarTurno(jugador) == true)
        {
            string resultado = "Es tu turno!";
            return resultado;
        }
        else
        {
            string resultado = "No es tu turno";
            return resultado;
        }
    }

    public string UsarItem(string displayName, int id)
    {
        JugadorPrincipal jugador = jugadores[displayName];

        if (jugador.PokemonActual != null)
        {
            jugador.UsarItem(id, jugador.PokemonActual);
            return ("Usaste un ítem en tu Pokémon.");
        }
        return ("No tienes un Pokémon en batalla. Usa el comando elegir pokemon");
        
    }
    public string MostrarInventarioItems(string displayName)
    {
        JugadorPrincipal jugadorPrincipal = jugadores[displayName];
        
        string inventario = jugadorPrincipal.MostrarInventario();
        return inventario;
    }

}