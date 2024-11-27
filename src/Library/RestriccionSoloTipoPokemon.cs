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
    
    public void UsarRestriccion(JugadorPrincipal jugadorPrincipal, string nombre)
    {
        foreach (Pokemon pokemon in jugadorPrincipal.CatalogoPokemon.Catalogo)
        {
            if (pokemon.TipoPokemon.NombreTipo != nombre)
            {
                jugadorPrincipal.CatalogoPokemon.Catalogo.Remove(pokemon);
            }
        }
        
    }
}