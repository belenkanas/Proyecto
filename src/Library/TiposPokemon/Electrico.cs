namespace Library;

/// <summary>
/// Tipo de Pokemon, débil contra Tierra, inmunne con Electrico.
/// </summary>
public class Electrico: ITipo
{
    public string NombreTipo { get;  } 
    
    public Electrico()
    {
        NombreTipo = "Electrico";
    }
    public double Ponderador(ITipo tipoOponente) //Recibe como parámetro otros tipos de pokemones
    {
        if (tipoOponente.NombreTipo == "Electrico")
        {
            return 0; //Es inmune su daño ante el eléctrico
        }
        else if (tipoOponente.NombreTipo == "Tierra" )
        {
            return 0.5; //Es debil ante la Tierra
        }
        else if (tipoOponente.NombreTipo == "Electrico")
        {
            return 0; //Es inmune a ataques Electricos
        }
        return 1.0; //Si el fuego es enfrentado frente a otro tipo, el ponderador será neutro.
    }
}    