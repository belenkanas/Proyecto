namespace Library;

public class RestriccionItem: IRestriccion
{
    
    public string NombreRestriccion { get; set; }

    public RestriccionItem()
    {
        this.NombreRestriccion = "Restricción de NO jugar con cierto item";
    }
    
    public void UsarRestriccion(JugadorPrincipal jugadorPrincipal, string nombre)
    {
        foreach (IItem item in jugadorPrincipal.InventarioItems)
        {
            if (item.NombreItem == nombre)
            {
                jugadorPrincipal.InventarioItems.Remove(item);
            }
        }

        //return jugadorPrincipal.MostrarInventario();

    }
}