namespace Library;

/// <summary>
/// De tipo IEfectos, hace que el Pokemón objetivo pueda atacar o no aleatoriamente.
/// Usa el tipo Random.
/// </summary>
public class Paralizar : IEfectos
{
    public string nombreEfecto {get;} = "Paralizar";

    public void AplicarEfecto (IPokemon objetivo)
    {
        objetivo.Estado = "Paralizado";
        objetivo.EfectoActivo = this;
    }

    /// <summary>
    ///  Si el Pokémon puede atacar o no se determina cuando intenta atacar.
    /// </summary>
    public bool PuedeAtacar()
    {
        Random random = new Random();
        return random.Next(0, 2) == 1;
    }
}

