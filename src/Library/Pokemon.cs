namespace Library;

    /// <summary>
    /// Esta clase hereda de la interfaz, define todas las características de los personajes de la batalla.
    /// </summary>
    public class Pokemon: IPokemon
    {
        public string Nombre { get; set; }                  //Nombre del pokémon
        public ITipo TipoPokemon { get; set; }              //Tipo del pokémon
        public double VidaActual { get; set; }              //Vida del pokémon
        public double VidaTotal {get; set;}
        public double Ataque { get; set; }                  //Valor de ataque del pokémon
        public double Defensa { get; set; }                 //Valor de defensa del pokémon
        public double AtaqueEspecial { get; set; }          //Valor de ataque especial del pokémon
        public double DefensaEspecial { get; set; }         //Valor de defensa del pokémon
    
        public List<Ataque> Ataques {get; set;}
        public CatalogoAtaques Catalogo { get; set; }
        public string Estado { get; set; }
        public IEfectos? EfectoActivo { get; set; }
        public bool PuedeAtacar { get; set;}
        public int turnoContadorEspecial { get; set; }

        public Pokemon(string nombre, ITipo tipo, double vidaTotal)
            {
                Nombre = nombre;
                TipoPokemon = tipo;
                VidaActual = vidaTotal;
                VidaTotal = vidaTotal;
                Ataques = new List<Ataque>();
                Catalogo = new CatalogoAtaques();
                turnoContadorEspecial = 0;
            }

        /// <summary>
        /// Realiza un ataque a un pokémon enemigo
        /// </summary>
        /// <param name="indiceAtaque"></param>
        /// <param name="enemigo"></param>
        public string UsarAtaque(int indiceAtaque, IPokemon enemigo)           
        {
            if (indiceAtaque < 0 || indiceAtaque >= Ataques.Count)
            {
                return "El ataque no es válido";
            }
            
            Ataque ataque = Ataques[indiceAtaque];
            
            if (ataque.EsEspecial && turnoContadorEspecial % 2 != 0)
            {
                return "El ataque especial no está disponible este turno.";
            }
            
            double ponderador = TipoPokemon.Ponderador(enemigo.TipoPokemon);
            
            double danoInicial = ataque.CalcularDaño(this, enemigo);

            double danoTotal = danoInicial * ponderador;
            
            enemigo.RecibirDaño(danoTotal);

            
            turnoContadorEspecial++;
            
        
            return $"{Nombre} usó {ataque.Nombre} y causó {danoTotal} puntos de daño.";
        }
        
        /// <summary>
        /// Recibe daño del pokémon enemigo
        /// </summary>
        /// <param name="dano"></param>
        public void RecibirDaño(double dano)          
        {
            VidaActual -= dano;
            if (VidaActual <= 0)
            {
                VidaActual = 0;
                Estado = "Derrotado";
            }
        }
        
        /// <summary>
        /// Muestra la vida actual sobre la vida total del pokémon
        /// </summary>
        /// <returns></returns>
        public string MostrarVida()
        {
            return $"{VidaActual}/{VidaTotal}";
        }

        /// <summary>
        /// Agrega cada ataque del catálogo de ataques al tipo de pokemon correspondiente por tipo.
        /// Esto se asegura de que no haya incongruencia entre los tipos de pokemon y ataque en el juego.
        /// </summary>
        public void AtaquesPorTipo()
        {
            foreach (Ataque ataque in Catalogo.ataques)
            {
                if (ataque.TipoAtaque.NombreTipo == TipoPokemon.NombreTipo)
                {
                    Ataques.Add(ataque);
                }
            } 
        }
        
        /// <summary>
        /// Muestra los ataques disponibles que tiene el pokemon según el turno. A cada 2 turnos, no tiene acceso a los ataques especiales.
        /// </summary>
        /// <returns>Devuelve lista de ataques disponibles según partida.</returns>
        public List<Ataque> ObtenerAtaquesDisponibles()
        {
            if (turnoContadorEspecial % 2 == 0)
            {
                return Ataques; // Todos los ataques están disponibles cada dos turnos
            }
            else
            {
                // Solo devuelve ataques no especiales en turnos alternos
                return Ataques.Where(ataque => !ataque.EsEspecial).ToList();
            }
        }

    }
