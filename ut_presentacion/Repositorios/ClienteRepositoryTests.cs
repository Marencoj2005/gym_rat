using lib__dominio.Entidades;
using lib__repositorios.Interfaces;
using lib__repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using Xunit;
using gim_rat.Tests.Repositorios;

namespace lib__repositorios.Tests
{
    public class ClienteRepositoryTests
    {
        private readonly IConexion _conexion;

        // Constructor para configurar la base de datos en memoria para pruebas
        public ClienteRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<Conexion>()
                .UseInMemoryDatabase("TestDb")  // Nombre de la base de datos en memoria
                .Options;

            _conexion = new Conexion(options);  // Crear la instancia de Conexion
        }

        [Fact]
        public void Add_ShouldCallAddAndSaveChangesOnConexion()
        {
            // Arrange: Crear el repositorio y el cliente de prueba.
            var repository = new ClienteRepository(_conexion);
            var cliente1 = new Cliente { Cedula = 1, Nombre = "Test Cliente1", Email = "test1@example.com" };

            // Act: Llamar al método Add para agregar el cliente.
            repository.Add(cliente1);

            // Assert: Verificar que el cliente se haya guardado en la base de datos.
            var clienteEnDb = _conexion.Clientes.Find(1);  // Buscar el cliente por su cédula.
            Assert.NotNull(clienteEnDb);  // Verificar que el cliente no sea nulo.
            Assert.Equal(cliente1.Cedula, clienteEnDb.Cedula);  // Verificar que la cédula sea la misma.
            Assert.Equal(cliente1.Nombre, clienteEnDb.Nombre);  // Verificar que el nombre sea el mismo.
            Assert.Equal(cliente1.Email, clienteEnDb.Email);  // Verificar que el email sea el mismo.
        }
    }
}
