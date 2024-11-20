namespace Library
{
    /// <summary>
    /// Item que cura a un Pokemon de efectos de ataques especiales (dormido, paralizado, envenenado o quemado).
    /// </summary>
    public class CuraTotal : IItem
    {
        public string NombreItem { get; }
        public int usosRestantes;

        public CuraTotal()
        {
            NombreItem = "Cura Total";
            usosRestantes = 2; // Inicializa usosRestantes con el máximo de usos
        }

        
        /// <summary>
        /// Metodo para quitar los efectos
        /// </summary>
        /// <param name="objetivo">Es el pokemon al que se le quitarán los efectos.</param>
        public void Usar(IPokemon objetivo)
        {
            if (usosRestantes > 0)
            {
                // Verifica si hay un efecto activo y que no sea "Dormido"
                if (objetivo.EfectoActivo != null && objetivo.EfectoActivo.nombreEfecto != "Dormir")
                {
                    objetivo.EfectoActivo = null;
                    objetivo.Estado = "Normal";
                    Console.WriteLine($"{objetivo.Nombre} ya no está bajo ningún efecto");
                    usosRestantes--;
                }
                else if (objetivo.EfectoActivo?.nombreEfecto == "Dormir")
                {
                    Console.WriteLine($"{objetivo.Nombre} está dormido y no puede recibir Cura Total.");
                }
                else
                {
                    Console.WriteLine($"{objetivo.Nombre} no tiene efectos activos.");
                }
            }
            else
            {
                Console.WriteLine("No se pueden usar más Cura Total en esta batalla.");
            }
        }

       
    }
}