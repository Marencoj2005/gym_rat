using Microsoft.VisualStudio.TestTools.UnitTesting;
using lib__dominio.Entidades;
using gim_rat.Tests.Nucleo;
using lib__repositorios.Interfaces;
using lib__repositorios.Implementaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace gim_rat.Tests.Entidades
{
    [TestClass]
    public class ClienteTests
    {
        private IConexion _conexion;

        [TestMethod]
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
            cliente2.TipoUsuario = tipoUsuario;
            cliente1.Activo = activo;
            cliente2.Activo = activo;

            // Guardar los clientes en la base de datos en memoria
            _conexion.Clientes.Add(cliente1);
            _conexion.Clientes.Add(cliente2);
            _conexion.SaveChanges();

            // Assert
            var clienteGuardado1 = _conexion.Clientes.FirstOrDefault(c => c.Cedula == cedula);
            var clienteGuardado2 = _conexion.Clientes.FirstOrDefault(c => c.Cedula == cedula);

            Assert.IsNotNull(clienteGuardado1);
            Assert.AreEqual(cedula, clienteGuardado1.Cedula);
            Assert.AreEqual(nombre, clienteGuardado1.Nombre);
            Assert.AreEqual(email, clienteGuardado1.Email);
            Assert.AreEqual(tipoUsuario, clienteGuardado1.TipoUsuario);
            Assert.AreEqual(activo, clienteGuardado1.Activo);

            Assert.IsNotNull(clienteGuardado2);
            Assert.AreEqual(cedula, clienteGuardado2.Cedula);
            Assert.AreEqual(nombre, clienteGuardado2.Nombre);
            Assert.AreEqual(email, clienteGuardado2.Email);
            Assert.AreEqual(tipoUsuario, clienteGuardado2.TipoUsuario);
            Assert.AreEqual(activo, clienteGuardado2.Activo);
        }

        [TestMethod]
        public void Listar_Clientes()
        {
            // Arrange: Añadir un cliente a la base de datos
            var cliente = new Cliente { Cedula = 12345, Nombre = "Juan Perez" };
            _conexion.Clientes.Add(cliente);
            _conexion.SaveChanges();

            // Act: Listar los clientes
            var lista = _conexion.Clientes.ToList();

            // Assert: Verificar que hay al menos un cliente
            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void Guardar_Cliente()
        {
            // Arrange: Crear un cliente nuevo
            var cliente = new Cliente { Cedula = 67890, Nombre = "Maria Lopez" };

            // Act: Guardar el cliente en la base de datos
            _conexion.Clientes.Add(cliente);
            _conexion.SaveChanges();

            // Assert: Verificar que el cliente se guardó correctamente
            var clienteGuardado = _conexion.Clientes.FirstOrDefault(c => c.Cedula == 67890);
            Assert.IsNotNull(clienteGuardado);
            Assert.AreEqual("Maria Lopez", clienteGuardado.Nombre);
        }

        [TestMethod]
        public void Modificar_Cliente()
        {
            // Arrange: Crear un cliente y guardarlo
            var cliente = new Cliente { Cedula = 67890, Nombre = "Carlos Garcia" };
            _conexion.Clientes.Add(cliente);
            _conexion.SaveChanges();

            // Act: Modificar el cliente
            cliente.Nombre = "Carlos Fernandez";
            var entry = _conexion.Entry(cliente);
            entry.State = EntityState.Modified;
            _conexion.SaveChanges();

            // Assert: Verificar que el nombre se actualizó
            var clienteModificado = _conexion.Clientes.FirstOrDefault(c => c.Cedula == 67890);
            Assert.IsNotNull(clienteModificado);
            Assert.AreEqual("Carlos Fernandez", clienteModificado.Nombre);
        }

        [TestMethod]
        public void Borrar_Cliente()
        {
            // Arrange: Crear un cliente y guardarlo
            var cliente = new Cliente { Cedula = 67890, Nombre = "Ana Sanchez" };
            _conexion.Clientes.Add(cliente);
            _conexion.SaveChanges();

            // Act: Borrar el cliente
            _conexion.Clientes.Remove(cliente);
            _conexion.SaveChanges();

            // Assert: Verificar que el cliente fue borrado
            var clienteBorrado = _conexion.Clientes.FirstOrDefault(c => c.Cedula == 67890);
            Assert.IsNull(clienteBorrado);
        }
    }

}