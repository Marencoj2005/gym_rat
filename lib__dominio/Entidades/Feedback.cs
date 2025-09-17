using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    internal class Feedback
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
