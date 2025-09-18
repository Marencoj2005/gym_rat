using lib__dominio.Entidades;
using lib__repositorios.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace gim_rat.Tests.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConexion _conexion;

        public ClienteRepository(IConexion conexion)
        {
            _conexion = conexion;
        }

        public void Add(Cliente cliente)
        {
            _conexion.Clientes.Add(cliente);
            _conexion.SaveChanges();
        }

        public Cliente GetById(int cedula)
        {
            return _conexion.Clientes.FirstOrDefault(c => c.Cedula == cedula);
        }

        public void Update(Cliente cliente)
        {
            _conexion.Clientes.Update(cliente);
            _conexion.SaveChanges();
        }

        public void Delete(int cedula)
        {
            var cliente = _conexion.Clientes.FirstOrDefault(c => c.Cedula == cedula);
            if (cliente != null)
            {
                _conexion.Clientes.Remove(cliente);
                _conexion.SaveChanges();
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _conexion.Clientes.ToList();
        }
    }
}
