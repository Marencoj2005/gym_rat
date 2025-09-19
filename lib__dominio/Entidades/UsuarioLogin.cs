using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib__dominio.Entidades
{
    public class UsuarioLogin
    {
        [Key]
        public int IdUsuario { get; set; }
        public int CedulaCliente { get; set; }
        public String? Email { get; set; }
        public String? PasswordHash { get; set; }
        public String? Rol { get; set; } // Cliente, Empleado, Admin

        public Cliente Cliente { get; set; }

    }
}
