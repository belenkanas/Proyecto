namespace Library;

/// <summary>
/// Este tipo de efecto hace que el pokemón objetivo pierda 10% de su HP cada turno.
/// </summary>
public class Quemar : AplicarDaño, IEfectos
{
    public string nombreEfecto {get; set;} = "Quemar";
    
    /// <summary>
    /// // Numero de turnos que durara el efecto
    /// </summary>
    private int turnosRestante = 3;
    public void AplicarEfecto(IPokemon objetivo)
    {
        objetivo.Estado = "Envenenado"; 
    }
    
    /// <summary>
    /// Si un Pokémon está quemado perderá el 10% de su HP total cada turno. Resta de a uno los turnos que le queda.
    /// </summary>
    /// <param name="objetivo"></param>
    public override void AplicarDañoPorTurno(IPokemon objetivo)
    {
        if(turnosRestante > 0)
        {
            int daño = (int)(objetivo.VidaActual * 0.10);
            objetivo.VidaActual -= daño;
            turnosRestante--;                           
        }
    }

}
