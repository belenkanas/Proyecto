using System.Reflection.Metadata;

namespace Library;

/// <summary>
/// Esta interfaz define los atributos y métodos de un pokémon
/// </summary>
public interface IPokemon
{
    public string Nombre { get; set; }                  //Nombre del pokémon
    public ITipo TipoPokemon { get; set; }              //Tipo del pokémon
    public double VidaActual { get; set; }                    //Vida del pokémon
    public double VidaTotal {get; set;}
    public double Ataque { get; set; }                  //Valor de ataque del pokémon
    public double Defensa { get; set; }                 //Valor de defensa del pokémon
    public double AtaqueEspecial { get; set; }          //Valor de ataque especial del pokémon
    public double DefensaEspecial { get; set; }         //Valor de defensa del pokémon
    public List<Ataque> Ataques {get; set;}
    public CatalogoAtaques Catalogo { get; set; }
    public string Estado {get; set; }                    //Estado es si esta bajo algun efecto
    IEfectos? EfectoActivo{get; set;}
    public int turnoContadorEspecial { get; set; }

    public bool PuedeAtacar {get; set; }                //Indicador si esta en condiciones de atacar
    public string UsarAtaque(int indiceAtaque, IPokemon enemigo);           //Método para realizar un ataque 
    public void RecibirDaño(double dano);          //Método para recibir daño del pokémon enemigo
    public string MostrarVida();                        //Método para mostrar la vida actual del pokémon
    public void AtaquesPorTipo();
    public List<Ataque> ObtenerAtaquesDisponibles();
}