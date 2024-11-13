namespace Library;

/// <summary>
/// Esta interfaz define el tipo de pokémon y determina la potencia de los ataques según el tipo de pókemon que será atacado
/// </summary>
public interface ITipo
{
    public string NombreTipo { get;  }         //Nombre del tipo de pokémon
    
    
    /// <summary>
    /// Mediante este método, se analiza frente a qué tipos es debil el pokemon y con cuales es fuerte.
    /// El Ponderador indicará el tamaño del daño que se realizará.
    /// </summary>
    /// <param name="tipoOponente"></param>
    /// <returns></returns>
    public double Ponderador(ITipo tipoOponente);         //Define la efectividad de los ataques dependiendo del tipo
}