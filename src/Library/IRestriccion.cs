namespace Library;

public interface IRestriccion
{
    public  string NombreRestriccion { get; set; }
    public void UsarRestriccion(JugadorPrincipal jugadorPrincipal, string nombre);
}