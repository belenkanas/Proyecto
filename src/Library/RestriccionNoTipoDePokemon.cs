namespace Library;

public class RestriccionNoTipoDePokemon : IRestriccion
{
    public string NombreRestriccion { get; set; }

    public RestriccionNoTipoDePokemon()
    {
        this.NombreRestriccion = "Restricción de NO jugar con cierto Tipo de Pokemon";
    }
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
}