namespace lib__dominio.Entidades
{
    internal class DatosFisicos
    {
        public int Id { get; set; }
        public int CedulaCliente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public decimal GrasaCorporal { get; set; }
        public decimal MasaMuscular { get; set; }
        public int Metabolismo { get; set; }
        public decimal Agua { get; set; }

        public Cliente Cliente { get; set; }

    }
}
