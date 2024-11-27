namespace Library;

public class RestriccionNombrePokemon : IRestriccion
{
    public string NombreRestriccion { get; set; }

    public RestriccionNombrePokemon()
    {
        this.NombreRestriccion = "Restricción de NO jugar con cierto Pokemon";
    }
     
    
    /// <summary>
    /// Método para eliminar del catálogo de pokemons, el pokemon específico que el jugador no requiera
    /// para la partida.
    /// </summary>
    /// <param name="jugadorPrincipal">Usuario que eligirá la restriccion</param>
    /// <param name="nombre">Pokemon que no quiere que aparezca disponible, lo indica por su nombre.</param>
    public void UsarRestriccion(JugadorPrincipal jugadorPrincipal, string nombre)
    {
        foreach (Pokemon pokemon in jugadorPrincipal.CatalogoPokemon.Catalogo)
        {
            if (pokemon.Nombre == nombre)
            {
                jugadorPrincipal.CatalogoPokemon.Catalogo.Remove(pokemon);
            }
        }

        //return jugadorPrincipal.MostrarCatalogo();
    }
}