using System.ComponentModel.DataAnnotations;

namespace lib__dominio.Entidades
{
    public class HistorialFisico
    {
        [Key]
        public int IdHistorial { get; set; }
        public int CedulaCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public decimal MasaMuscular { get; set; }
    }
}
