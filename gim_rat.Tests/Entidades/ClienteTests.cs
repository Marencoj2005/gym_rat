using Xunit;
using lib__dominio.Entidades;

namespace gim_rat.Tests.Entidades
{
    public class ClienteTests
    {
        [Fact]
        public void Cliente_Properties_CanBeSetAndGet()
        {
            // Arrange
            var cliente = new Cliente();
            var cedula = 12345;
            var nombre = "Juan Perez";
            var email = "juan.perez@example.com";
            var tipoUsuario = "Socio";
            var activo = true;

            // Act
            cliente.Cedula = cedula;
            cliente.Nombre = nombre;
            cliente.Email = email;
            cliente.TipoUsuario = tipoUsuario;
            cliente.Activo = activo;

            // Assert
            Assert.Equal(cedula, cliente.Cedula);
            Assert.Equal(nombre, cliente.Nombre);
            Assert.Equal(email, cliente.Email);
            Assert.Equal(tipoUsuario, cliente.TipoUsuario);
            Assert.Equal(activo, cliente.Activo);
        }
    }
}
