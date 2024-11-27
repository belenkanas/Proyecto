namespace Library;

public class prohibiciones
{
    public List<string> itemsProhibidos;
    public List<string> tiposProhibidos;
    public List<string> pokemonesProhibidos;


    public prohibiciones()
    {
        pokemonesProhibidos = new List<string>();
        tiposProhibidos = new List<string>();
        itemsProhibidos = new List<string>();
    }

    //por ahora lo dejo asi 
    //tengo que hacer que quede registrado, que se use solo antes de la batalla
    //pensarlo como en lista de espera pero adecuado a esto
    //en vez de agregar jugadores, agrego pokemones,tipos e items a una lista donde los prohibo

    public void prohibirPokemon(string nombrePokemon)
    {
        if (!pokemonesProhibidos.Contains(nombrePokemon))
        {
            pokemonesProhibidos.Add(nombrePokemon);
        }
    }

    public void prohibirTipo(string nombreTipo)
    {
        if (!tiposProhibidos.Contains(nombreTipo))
        {
            tiposProhibidos.Add(nombreTipo);
        }
    }

    public void prohibitItem(string nombreItem)
    {
        if (!itemsProhibidos.Contains(nombreItem))
        {
            itemsProhibidos.Add(nombreItem);
        }
    }
//pokemones permitidos, no pokemones prohibidos
    
    public bool PokemonPermitido(IPokemon pokemon)
    {
        return !pokemonesProhibidos.Contains(pokemon.Nombre);
    }

    public bool ItemsPermitidos(IItem item)
    {
        return !itemsProhibidos.Contains(item.NombreItem);
    }

    public bool TiposPermitidos(ITipo tipo)
    {
        return !tiposProhibidos.Contains(tipo.NombreTipo);
    }

}
