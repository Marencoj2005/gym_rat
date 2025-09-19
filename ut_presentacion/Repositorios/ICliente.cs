using lib_aplicaciones.Implementaciones;
using lib__dominio.Entidades;
using lib__repositorios.Implementaciones;
using lib__repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ClienteRepositoryTests
    {
        private IConexion _conexion = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Conexion>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _conexion = new Conexion(options);
        }

        [TestMethod]
        public void Add_ShouldCallAddAndSaveChangesOnConexion()
        {
            // Arrange
            var repository = new ClienteRepository(_conexion);
            var cliente1 = new Cliente { Cedula = 1, Nombre = "Test Cliente1", Email = "test1@example.com", TipoUsuario = "Socio", Activo = true };

            // Act
            repository.Add(cliente1);

            // Assert
            var clienteEnDb = _conexion.Clientes.Find(1);
            Assert.IsNotNull(clienteEnDb);
            Assert.AreEqual(cliente1.Cedula, clienteEnDb.Cedula);
            Assert.AreEqual(cliente1.Nombre, clienteEnDb.Nombre);
            Assert.AreEqual(cliente1.Email, clienteEnDb.Email);
        }
    }
}