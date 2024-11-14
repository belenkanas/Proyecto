namespace Library;

/// <summary>
/// De tipo IEfectos, hace que el pokemon atacado pierda 5% de su HP total cada turno. 
/// </summary>
public class Envenenar : AplicarDaño, IEfectos
{
    public string nombreEfecto {get; set;} = "Envenenar";                    
    
    /// <summary>
    /// El Pokémon puede seguir atacando, pero indica que está "envenenado"
    /// </summary>
    /// <param name="objetivo"></param>
    public void AplicarEfecto(IPokemon objetivo)
    {
    objetivo.Estado = "Envenenado";                     
    }
    
    /// <summary>
    /// Si un Pokémon está envenenado perderá el 5% de su HP total cada turno. El objetivo es el pokemón enemigo.
    /// </summary>
    /// <param name="objetivo"></param>
   

}
