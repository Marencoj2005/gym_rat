using System.ComponentModel.DataAnnotations;

namespace lib__dominio.Entidades
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }
        public int CedulaCliente { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public String? MetodoPago { get; set; } // Efectivo, Tarjeta, etc.

        public Cliente Cliente { get; set; }
    }
}
