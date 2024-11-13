namespace Library;

/// <summary>
/// Por el principio ISP, esta interfaz representa los efectos de Dormir, Paralizar, Envenenar o Quemar que podrán usar los ataques especiales. 
/// </summary>
public interface IEfectos
{
    public string nombreEfecto {get; set;}  
    void AplicarEfecto(IPokemon objetivo); 
}   