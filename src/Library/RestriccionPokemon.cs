namespace Library;

public class RestriccionPokemon
{
    private List<string> pokemonsProhibidos;

    public RestriccionPokemon()
    {
        pokemonsProhibidos = new List<string>();
    }

    public void AgregarRestriccion(string nombrePokemon)
    {
        if (!pokemonsProhibidos.Contains(nombrePokemon))
        {
            pokemonsProhibidos.Add(nombrePokemon);
        }
    }

    public bool EstaElPokemonPermitido(string nombrePokemon)
    {
        foreach (var pokemon in pokemonsProhibidos)
        {
            if (pokemon == nombrePokemon)
                return false;
        }

        return true;
    }
}

//esto deberia hacerlo con el resto de clases de restriccion, no como lo habia hecho antes, tambien deberia modificar
//el catalogo para que  no se puede elegir pokemon cuando el usuario pone !agregarpokemon
// deberia modificar todas estas clases para que interactuen con el catalogo.