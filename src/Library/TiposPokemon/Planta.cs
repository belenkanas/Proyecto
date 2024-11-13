namespace Library;

/// <summary>
/// Tipo de Pokemon, débil contra Fuego y Hielo, resistente contra Agua, Electrico, Planta y Tierra.
/// </summary>
public class Planta: ITipo
{
    public string NombreTipo { get; }
    
    public Planta()
    {
        NombreTipo = "Planta";
    } 
    public double Ponderador(ITipo tipoOponente) //Recibe como parámetro otros tipos de pokemones
    {
        if (tipoOponente.NombreTipo == "Tierra" || tipoOponente.NombreTipo == "Agua" || tipoOponente.NombreTipo == "Electrico" || tipoOponente.NombreTipo == "Planta" )
        {
            return 2.0; 
        }
        else if (tipoOponente.NombreTipo == "Hielo" || tipoOponente.NombreTipo=="Fuego")
        {
            return 0.5; //Debil ante Hielo y Fuego

        }
        return 1.0; //Si es enfrentado frente a otro tipo, el ponderador será neutro.
    }
}