using lib__dominio.Entidades;

namespace lib__repositorios.Interfaces
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        Cliente GetById(int cedula);
        void Update(Cliente cliente);
        void Delete(int cedula);
        IEnumerable<Cliente> GetAll();
    }
}
