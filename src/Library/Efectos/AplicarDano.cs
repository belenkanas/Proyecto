using Library;

public abstract class AplicarDaño
{
    /// <summary>
    /// // Numero de turnos que durara el efecto
    /// </summary>
    private int turnosRestante = 3;
    
    /// <summary>
    /// La cantidad de turnos que está dormido el Pokémon se determina cuando recibe el ataque.
    /// </summary>
    public virtual void AplicarDañoPorTurno(IPokemon objetivo)
    {
        if (turnosRestante > 0)
        {
            int daño = (int)(objetivo.VidaActual * 0.05);

            objetivo.VidaActual -= daño;
            
            turnosRestante--;
        }
    }
}