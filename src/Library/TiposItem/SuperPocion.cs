namespace Library;

/// <summary>
/// Con este tipo de Item, se pueden usar hasta 4 y cada una recupera 70 puntos de HP.
/// </summary>
public class SuperPocion: IItem
{
    public string NombreItem { get; }
    private int usosRestantes;
    private const int usosMaximos = 4;

    public SuperPocion()
    {
        NombreItem = "Super Pocion";
        usosRestantes = usosMaximos; // Inicializa el contador de usos
    }

    /// <summary>
    /// Método para curar, recibe la vida actual y la total del pokemón e intenta reestablecerla.
    /// </summary>
    /// <param name="VidaActual"></param>
    /// <param name="VidaTotal"></param>
    /// <returns></returns>
    public double Usar(double VidaActual, double VidaTotal)
    {
        if (usosRestantes > 0)
        {
            if (VidaActual < VidaTotal - 70)
            {
                usosRestantes--; // Reduce el contador de usos
                return VidaActual + 70; // Si la diferencia es mayor a 70, se curan 70 puntos
            }
            else
            {
                usosRestantes--; // Reduce el contador de usos
                return VidaTotal; // Si no, se cura hasta el máximo (VidaTotal)
            }
        }
        else
        {
            Console.WriteLine("No se pueden usar más 'Super Pocion' en esta batalla.");
            return VidaActual; // Devuelve la vida actual sin cambios
        }
    }
}