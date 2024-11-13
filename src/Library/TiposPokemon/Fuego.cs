namespace Library;

/// <summary>
/// Tipo de Pokemon, débil frente a Agua y Tierra, resistente frente a Fuego y Planta
/// </summary>
public class Fuego: ITipo
{
    public string NombreTipo { get;} 

    public Fuego()
    {
        NombreTipo = "Fuego";
    }

    public double Ponderador(ITipo tipoOponente) //Recibe como parámetro otros tipos de pokemones
    {
        if ( tipoOponente.NombreTipo == "Fuego" || tipoOponente.NombreTipo== "Planta")
        {
            return 2.0; 
        }
        else if (tipoOponente.NombreTipo == "Tierra" || tipoOponente.NombreTipo=="Agua" || tipoOponente.NombreTipo=="Roca")
        {
            return 0.5; //Fuego es debil ante la Tierra y Agua

        }
        return 1.0; //Si el fuego es enfrentado frente a otro tipo, el ponderador será neutro.
    }
}