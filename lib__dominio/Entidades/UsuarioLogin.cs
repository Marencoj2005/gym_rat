using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    public class UsuarioLogin
    {
        public int IdUsuario { get; set; }
        public int CedulaCliente { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Rol { get; set; } // Cliente, Empleado, Admin

        public Cliente Cliente { get; set; }

    }
}
