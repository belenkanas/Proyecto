namespace Library;

/// <summary>
/// 
/// </summary>
public class RestriccionSoloTipoPokemon : IRestriccion
{
    public string NombreRestriccion { get; set; }

    public RestriccionSoloTipoPokemon()
    {
        this.NombreRestriccion = "Restricción de Solo un Tipo de Pokemon";
    }
    
    /// <summary>
    /// Método para eliminar del catálogo de pokemons, los pokemons que no son del tipo que el jugador prefiere
    /// para la partida.
    /// </summary>
    /// <param name="jugadorPrincipal">Usuario que eligirá la restriccion</param>
    /// <param name="nombre">Tipo del pokemon que el jugador sí quiere para la partida.</param>
    public void UsarRestriccion(JugadorPrincipal jugadorPrincipal, string nombre)
    {
        foreach (Pokemon pokemon in jugadorPrincipal.CatalogoPokemon.Catalogo)
        {
            if (pokemon.TipoPokemon.NombreTipo != nombre)
            {
                jugadorPrincipal.CatalogoPokemon.Catalogo.Remove(pokemon);
            }
        }
       //En este método, se recorrerá la lista de catálogo de pokemons, y cualquiera que no coincida con el tipo de
       //pokemon específico, será removido de la lista de opciones que se mostrará más adelante.
    }
    
}