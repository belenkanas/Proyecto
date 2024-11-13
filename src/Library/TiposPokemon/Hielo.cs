namespace Library;

/// <summary>
/// Tipo de Pokemon, débil contra Fuego, resistente contra Hielo.
/// </summary>
public class Hielo: ITipo
{
    public string NombreTipo { get; }
    
    public Hielo()
    {
        NombreTipo = "Hielo";
    } 
    public double Ponderador(ITipo tipoOponente) //Recibe como parámetro otros tipos de pokemones
    {
        if (tipoOponente.NombreTipo == "Hielo")
        {
            return 2.0; 
        }
        else if (tipoOponente.NombreTipo == "Roca" || tipoOponente.NombreTipo=="Fuego")
        {
            return 0.5; //Debil ante Acero y Fuego

        }
        return 1.0; //Si es enfrentado frente a otro tipo, el ponderador será neutro.
    }
}