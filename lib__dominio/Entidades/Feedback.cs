namespace lib__dominio.Entidades
{
    public class Feedback
    {
        public int IdFeedback { get; set; }
        public int CedulaCliente { get; set; }
        public int IdClase { get; set; }
        public string Comentario { get; set; }
        public int Calificacion { get; set; }
        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }
        public Clase Clase { get; set; }
    }
}
