namespace Library;

public class RestriccionNombrePokemon : IRestriccion
{
    public string NombreRestriccion { get; set; }

    public RestriccionNombrePokemon()
    {
        this.NombreRestriccion = "Restricción de NO jugar con cierto Pokemon";
    }
     
    
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