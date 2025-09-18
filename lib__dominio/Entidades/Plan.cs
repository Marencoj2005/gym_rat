using System.Collections.Generic;

namespace lib__dominio.Entidades
{
    public class Plan
    {
        public int Nit { get; set; }
        public String? Nombre { get; set; }
        public String? TipoPlan { get; set; } // VIP, Basico, Incluido
        public bool Indefinido { get; set; }
        public decimal Precio { get; set; }

        public ICollection<Membresia> Membresias { get; set; }
    }
}