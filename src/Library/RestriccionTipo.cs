namespace Library;

public class restriccionTipo 
{
    private List<string> tiposProhibidos;

    public restriccionTipo()
    {
        tiposProhibidos = new List<string>();
    }

    public void AgregarRestriccion(string nombrePokemon)
    {
        if (!tiposProhibidos.Contains(nombrePokemon))
        {
            tiposProhibidos.Add(nombrePokemon);
        }
    }

    public bool EstaElTipoPermitido(string nombrePokemon)
    {
        foreach (var pokemon in tiposProhibidos)
        {
            if (pokemon == nombrePokemon)
                return false;
        }

        return true;
    }
}