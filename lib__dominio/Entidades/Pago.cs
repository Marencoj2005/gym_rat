namespace lib__dominio.Entidades
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int CedulaCliente { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } // Efectivo, Tarjeta, etc.

        public Cliente Cliente { get; set; }
    }
}
