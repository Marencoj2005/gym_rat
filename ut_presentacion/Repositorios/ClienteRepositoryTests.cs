using lib__dominio.Entidades;
using lib__repositorios.Interfaces;
using lib__repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using lib_aplicaciones.Implementaciones;

namespace lib__repositorios.Tests
{
    public class ClienteRepositoryTests
    {
        private readonly IConexion _conexion;

        // Constructor para configurar la base de datos en memoria para pruebas
        public ClienteRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<Conexion>()
                .Options;

            _conexion = new Conexion(options);
        }

        public void Add_ShouldCallAddAndSaveChangesOnConexion()
        {
            // Arrange: Crear el repositorio y el cliente de prueba.
            var repository = new ClienteRepository(_conexion);
            var cliente1 = new Cliente { Cedula = 1, Nombre = "Test Cliente1", Email = "test1@example.com" };

            // Act: Llamar al m�todo Add para agregar el cliente.
            repository.Add(cliente1);

            // Assert: Verificar que el cliente se haya guardado en la base de datos.
            var clienteEnDb = _conexion.Clientes.Find(1);  // Buscar el cliente por su c�dula.
            Assert.AreEqual(cliente1.Cedula, clienteEnDb.Cedula);  // Verificar que la c�dula sea la misma.
            Assert.AreEqual(cliente1.Nombre, clienteEnDb.Nombre);  // Verificar que el nombre sea el mismo.
            Assert.AreEqual(cliente1.Email, clienteEnDb.Email);  // Verificar que el email sea el mismo.
        }
    }
}
