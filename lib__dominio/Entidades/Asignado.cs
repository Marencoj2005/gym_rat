namespace lib__dominio.Entidades
{
    public class Asignado
    {
        public int CedulaCoach { get; set; }
        public int IdClase { get; set; }

        public Coach Coach { get; set; }
        public Clase Clase { get; set; }
    }
}
// Compare this snippet from lib__dominio/Entidades/Coach.cs: