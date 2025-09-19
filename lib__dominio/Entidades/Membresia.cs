using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    public class Membresia
    {
        [Key]
        public int IdMembresia { get; set; }
        public int CedulaCliente { get; set; }
        public int NitPlan { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public String? Estado { get; set; } // Activa, Vencida, Cancelada

        public Cliente Cliente { get; set; }
        public Plan Plan { get; set; }
    }
}