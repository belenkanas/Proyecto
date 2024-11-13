namespace Library;

/// <summary>
/// Tipo de Pokemon, indica en su Ponderador frente a cuales es débil, fuerte o inmune para su ataque.
/// </summary>
public class Roca: ITipo
{
    public string NombreTipo { get; }

    public Roca()  //Constructor del tipo, siempre su nombre será Acero.
    {
        NombreTipo = "Roca";
    }
    public double Ponderador(ITipo tipoOponente) //Recibe como parámetro otros tipos de pokemones
    {
        if (tipoOponente.NombreTipo == "Fuego")
        {
            return 2.0; //El acero es fuerte ante el hielo.
        }
        else if (tipoOponente.NombreTipo == "Agua" || tipoOponente.NombreTipo == "Planta" || tipoOponente.NombreTipo == "Tierra")
        {
            return 0.5; //Es debil frente al fuego

        }
        return 1.0; //Si es enfrentado frente a otro tipo, el ponderador será neutro.
    }
}