namespace Library;

public class Tierra: ITipo
{
    public string NombreTipo { get; }
    
    public Tierra()
    {
        NombreTipo = "Tierra";
    }      
    public double Ponderador(ITipo tipoOponente) //Recibe como parámetro otros tipos de pokemones
    {
        if (tipoOponente.NombreTipo == "Electrico")
        {
            return 2.0; 
        }
        else if (tipoOponente.NombreTipo == "Agua" || tipoOponente.NombreTipo=="Planta" || tipoOponente.NombreTipo=="Hielo")
        {
            return 0.5; //Debil ante Agua, Planta y Hielo

        }
        return 1.0; //Si es enfrentado frente a otro tipo, el ponderador será neutro.
    }
}