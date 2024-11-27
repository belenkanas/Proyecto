
namespace Library;

public class restriccionItem
{
    private List<string> itemsProhibidos;

    public restriccionItem()
    {
        itemsProhibidos = new List<string>();
    }

    public void AgregarRestriccion(string nombreItem)
    {
        if (!itemsProhibidos.Contains(nombreItem))
        {
            itemsProhibidos.Add(nombreItem);
        }
    }

    public bool EstaPermitidoElItem(string nombreItem)
    {
        foreach (var pokemon in itemsProhibidos)
        {
            if (pokemon == nombreItem)
                return false;
        }

        return true;
    }
}
