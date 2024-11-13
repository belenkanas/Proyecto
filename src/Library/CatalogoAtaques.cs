namespace Library;

/// <summary>
/// Esta clase muestra la variedad de ataques disponibles para poder utilizar durante la batalla y el resto del programa.
/// Cada ataque es de un tipo de Pokemon y tiene su indice.
/// </summary>
public class CatalogoAtaques
{
    public List<Ataque> ataques { get; set; }

    public CatalogoAtaques()
    {
        ataques = new List<Ataque>();
        AgregarAtaques();
    }

    /// <summary>
    /// Agrega los ataques disponibles del programa en el catálogo.
    /// </summary>
    public void AgregarAtaques()
    {
        ataques.Add(new Ataque("Acua Jet", new Agua(), 25, true));
        ataques.Add(new Ataque("Burbuja", new Agua(), 25, false));
        ataques.Add(new Ataque("Pistola de agua", new Agua(), 6, false));
        ataques.Add(new Ataque("Hidrobomba", new Agua(), 90, true));

        ataques.Add(new Ataque("Chispa", new Electrico(), 7, false));
        ataques.Add(new Ataque("Impactrueno", new Electrico(), 8, false));
        ataques.Add(new Ataque("Rayo", new Electrico(), 55, true));
        ataques.Add(new Ataque("Trueno", new Electrico(), 100, true));

        ataques.Add(new Ataque("Ascuas", new Fuego(), 10, false));
        ataques.Add(new Ataque("Colmillo ígneo", new Fuego(), 10, false));
        ataques.Add(new Ataque("Llamarada", new Fuego(), 100, true));
        ataques.Add(new Ataque("Lanzallamas", new Fuego(), 55, true));

        ataques.Add(new Ataque("Canto helado", new Hielo(), 15, false));
        ataques.Add(new Ataque("Vaho gélido", new Hielo(), 9, false));
        ataques.Add(new Ataque("Rayo hielo", new Hielo(), 65, true));
        ataques.Add(new Ataque("Ventisca", new Hielo(), 100, true));
        
        ataques.Add(new Ataque("Hoja afilada", new Planta(), 15, false));
        ataques.Add(new Ataque("Látigo cepa", new Planta(), 7, false));
        ataques.Add(new Ataque("Bomba germen", new Planta(), 40, true));
        ataques.Add(new Ataque("Tormenta floral", new Planta(), 65, true));
        
        ataques.Add(new Ataque("Lanzarrocas", new Roca(), 12, false));
        ataques.Add(new Ataque("Avalancha", new Roca(), 50, true));
        ataques.Add(new Ataque("Roca afilada", new Roca(), 80, true));
        ataques.Add(new Ataque("Tumba rocas", new Roca(), 30, true));
        
        ataques.Add(new Ataque("Bofetón lodo", new Tierra(), 15, false));
        ataques.Add(new Ataque("Disparo lodo", new Tierra(), 6, false));
        ataques.Add(new Ataque("Bomba Fango", new Tierra(), 30, true));
        ataques.Add(new Ataque("Terremoto", new Tierra(), 100, true));
    }
}