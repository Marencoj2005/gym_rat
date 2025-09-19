using Xunit;
using Moq;
using lib__dominio.Entidades;
using lib__repositorios.Interfaces;
using lib_aplicaciones.Implementaciones;
using Microsoft.EntityFrameworkCore;

namespace gim_rat.Tests.Repositorios
{
    public class ClienteRepositoryTests
    {
        [Fact]
        public void Add_ShouldCallAddAndSaveChangesOnConexion()
        {
            // Arrange
            var mockConexion = new Mock<IConexion>();
            var mockDbSet = new Mock<DbSet<Cliente>>();

            mockConexion.Setup(c => c.Clientes).Returns(mockDbSet.Object);

            var repository = new ClienteRepository(mockConexion.Object);
            var cliente1 = new Cliente { Cedula = 1, Nombre = "Test Cliente1", Email = "test1@example.com" };
            //var cliente2 = new Cliente { Cedula = 2, Nombre = "Test Cliente2", Email = "test2@example.com" };
            // Act
            repository.Add(cliente1);
            //repository.Add(cliente2);

            // Assert
            mockDbSet.Verify(m => m.Add(It.IsAny<Cliente>()), Times.Once);
            mockConexion.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
