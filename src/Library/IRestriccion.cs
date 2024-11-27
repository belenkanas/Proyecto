namespace Library;

/// <summary>
/// Clase genérica de las cuales dependen RestriccionItem, RestriccionNombreTipo, RestriccionNoTipoDePokemon y RestriccionSoloTipoPokemon.
/// Tiene un nombre específico, declarado luego en su contructor y un método que tiene como parametro el jugador que lo vaya a implementar la restriccion y el nombre del tipo de pokemon, item o nombre que vaya a excluir.
/// </summary>
public interface IRestriccion
{
    public  string NombreRestriccion { get; set; }
    public void UsarRestriccion(JugadorPrincipal jugadorPrincipal, string nombre);
}