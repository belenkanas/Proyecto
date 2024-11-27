namespace Library;

public class RestriccionNoTipoDePokemon : IRestriccion
{
    public string NombreRestriccion { get; set; }

    public RestriccionNoTipoDePokemon()
    {
        this.NombreRestriccion = "Restricción de NO jugar con cierto Tipo de Pokemon";
    }
    /// <summary>
    /// Método para eliminar del catálogo de pokemons, los pokemons de cierto tipo que el jugador no requiera
    /// para la partida.
    /// </summary>
    /// <param name="jugadorPrincipal">Usuario que eligirá la restriccion</param>
    /// <param name="nombre">Tipos de pokemon que no quiere que aparezca disponible, lo indica por el nombre del tipo.</param>
    public void UsarRestriccion(JugadorPrincipal jugadorPrincipal, string nombre)
    {
        foreach (Pokemon pokemon in jugadorPrincipal.CatalogoPokemon.Catalogo)
        {
            if (pokemon.TipoPokemon.NombreTipo == nombre)
            {
                jugadorPrincipal.CatalogoPokemon.Catalogo.Remove(pokemon);
            }
        }

       // return jugadorPrincipal.MostrarCatalogo();
    }
    
    //La lógica del método es que se fijará en la lista de CatalogosPokemon del jugador y aquel pokemon que coincia con el tipo indicado
    //será eliminado de las opciones.
}