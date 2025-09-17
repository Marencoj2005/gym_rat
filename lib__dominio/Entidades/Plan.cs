using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Plan
    {
        public int Nit { get; set; }
        public string Nombre { get; set; }
        public string TipoPlan { get; set; }
        public bool Indefinido { get; set; }
        public decimal Precio { get; set; }

        public ICollection<Membresia> Membresias { get; set; }
    }
}
