using lib__repositorios.Implementaciones;
using lib__repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib__dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ut_presentacion.Nucleo
{
    [TestClass] // ✅ Clase reconocida como prueba
    public class ClienteTests
    {
        private IConexion _conexion = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<Conexion>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _conexion = new Conexion(options);
        }

        [TestMethod]
        public void Cliente_Properties_CanBeSetAndGet()
        {
            var cliente1 = new Cliente
            {
                Cedula = 12345,
                Nombre = "Juan Perez",
                Email = "juan.perez@example.com",
                TipoUsuario = "Socio",
                Activo = true
            };

            _conexion.Clientes.Add(cliente1);
            _conexion.SaveChanges();

            var clienteGuardado1 = _conexion.Clientes.FirstOrDefault(c => c.Cedula == 12345);

            Assert.IsNotNull(clienteGuardado1);
            Assert.AreEqual(cliente1.Cedula, clienteGuardado1.Cedula);
            Assert.AreEqual(cliente1.Nombre, clienteGuardado1.Nombre);
            Assert.AreEqual(cliente1.Email, clienteGuardado1.Email);
            Assert.AreEqual(cliente1.TipoUsuario, clienteGuardado1.TipoUsuario);
            Assert.AreEqual(cliente1.Activo, clienteGuardado1.Activo);
        }


        [TestMethod]
            public void Listar_Clientes()
            {
                // Arrange: A�adir un cliente a la base de datos
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

                // Assert: Verificar que el cliente se guard� correctamente
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

                // Assert: Verificar que el nombre se actualiz�
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
