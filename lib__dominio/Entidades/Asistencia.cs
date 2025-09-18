using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    public class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int CedulaCliente { get; set; }
        public int IdClase { get; set; }
        public DateTime Fecha { get; set; }

        public Cliente Cliente { get; set; }
        public Clase Clase { get; set; }
    }
}
