namespace lib__dominio.Entidades
{
    internal class HistorialFisico
    {
        public int IdHistorial { get; set; }
        public int CedulaCliente { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public decimal MasaMuscular { get; set; }

        public Cliente Cliente { get; set; }
    }
}
