using Xunit;
using Moq;
using lib__dominio.Entidades;
using lib__repositorios.Interfaces;
using lib__repositorios.Implementaciones;
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
            var cliente = new Cliente { Cedula = 1, Nombre = "Test Cliente", Email = "test@example.com" };

            // Act
            repository.Add(cliente);

            // Assert
            mockDbSet.Verify(m => m.Add(It.IsAny<Cliente>()), Times.Once);
            mockConexion.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
