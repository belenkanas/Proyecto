using System;
using Library;

/// <summary>
/// Implementa el tipo IEfectos, este efecto hace que el pokémon enemigo esté dormido por un número aleatorio
/// de turnos y no atacará.
/// </summary>
public class Dormir : AplicarDaño, IEfectos
{
    public string nombreEfecto {get;} = "Dormir";
    public int turnosRestante { get; set; }

    /// <summary>
    /// Determina aleatoriamente cuantos turnos estará dormido el enemigo (entre 1 y 4)
    /// </summary>
    public Dormir()
    {
        turnosRestante = new Random().Next(1, 5);
    }

    /// <summary>
    /// Si el pokémon está dormido no atacará
    /// </summary>
    public void AplicarEfecto(IPokemon objetivo)
    {
        if (turnosRestante > 0)
        {
            objetivo.Estado = "Dormido";
            objetivo.EfectoActivo = this;
            turnosRestante--;
        }
        else
        {
            objetivo.Estado = "Normal";
        }
    }

}
