namespace Library;

/// <summary>
/// Tipo de pokemon, debil contra Electrico y Planta, resistente contra Agua, Fuego y Hielo
/// </summary>
public class Agua: ITipo
{
    public string NombreTipo { get; }

    public Agua()
    {
        NombreTipo = "Agua"; //Constructor, su nombre siempre será Agua. Esto es para evitar confusiones a la hora de especificar el tipo de pokemon.
    }
    public double Ponderador(ITipo tipoOponente) //Recibe como parámetro otros tipos de pokemones
    {
        if (tipoOponente.NombreTipo == "Fuego" || tipoOponente.NombreTipo == "Hielo" || tipoOponente.NombreTipo == "Agua")
        {
            return 2.0; 
        }
        else if (tipoOponente.NombreTipo == "Planta" || tipoOponente.NombreTipo=="Electrico")
        {
            return 0.5; 

        }
        return 1.0; //Si el fuego es enfrentado frente a otro tipo, el ponderador será neutro.
    }
}