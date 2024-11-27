namespace Library;

/// <summary>
/// Hereda de la interfaz IRestriccion ciertas propiedades y métodos.
/// </summary>
public class RestriccionItem: IRestriccion
{
    public string NombreRestriccion { get; set; }

    public RestriccionItem()
    {
        this.NombreRestriccion = "Restricción de NO jugar con cierto item";
    }
    
    /// <summary>
    /// Método para eliminar del catálogo de Items, el item que el jugador no requiera
    /// para la partida.
    /// </summary>
    /// <param name="jugadorPrincipal">Usuario que eligirá la restriccion</param>
    /// <param name="nombre">Item que no quiere que aparezca disponible, lo indica por su nombre.</param>
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
    
    //Comentarios de dicho método.
    //La lógica planteada indica que se fija item por item en el inventario del jugador, y el cual coincida con el nombre dado
    //será eliminado de las opciones.
}