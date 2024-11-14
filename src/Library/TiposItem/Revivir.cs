namespace Library
{
    /// <summary>
    /// Este tipo de Item logra que se reviva a un Pokemon con el 50% de su HP total.
    /// </summary>
    public class Revivir : IItem
    {
        public string NombreItem { get; }
        private int usosRestantes;
        private const int usosMaximos = 1;

        public Revivir()
        {
            NombreItem = "Revivir";
            usosRestantes = usosMaximos; 
        }

        /// <summary>
        /// Metodo para quitar los efectos
        /// </summary>
        /// <param name="VidaActual"></param>
        /// <param name="VidaTotal"></param>
        /// <returns></returns>
        public double Usar(double VidaActual, double VidaTotal)
        {
            if (usosRestantes > 0)
            {
                if (VidaActual == 0) // Compara si la vida es 0
                {
                    usosRestantes--; 
                    return VidaActual = VidaTotal * 0.5;
                }
                else
                {
                    Console.WriteLine("Solo se puede revivir cuando el pokemon está muerto");
                    return VidaActual; // Devuelve la vida actual sin cambios
                }
            }
            else
            {
                Console.WriteLine("No se pueden usar más 'Revivir' en esta batalla.");
                return VidaActual;
            }
        }
    }
}