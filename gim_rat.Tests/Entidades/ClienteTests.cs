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
            var cliente1 = new Cliente();
            var cliente2 = new Cliente();
            var cedula = 12345;
            var nombre = "Juan Perez";
            var email = "juan.perez@example.com";
            var tipoUsuario = "Socio";
            var activo = true;

            // Act
            cliente1.Cedula = cedula;
            cliente2.Cedula = cedula;
            cliente1.Nombre = nombre;
            cliente2.Nombre = nombre;
            cliente1.Email = email;
            cliente2.Email = email;
            cliente1.TipoUsuario = tipoUsuario;
            cliente2.TipoUsuario= tipoUsuario;
            cliente1.Activo = activo;
            cliente2.Activo = activo;

            // Assert
            Assert.Equal(cedula, cliente1.Cedula);
            Assert.Equal(cedula, cliente2.Cedula);
            Assert.Equal(nombre, cliente1.Nombre);
            Assert.Equal(nombre, cliente2.Nombre);
            Assert.Equal(email, cliente1.Email);
            Assert.Equal(email, cliente2.Email);    
            Assert.Equal(tipoUsuario, cliente1.TipoUsuario);
            Assert.Equal(tipoUsuario, cliente2.TipoUsuario);
            Assert.Equal(activo, cliente1.Activo);
            Assert.Equal(activo, cliente2.Activo);
        }
        
    }
}
