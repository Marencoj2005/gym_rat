using lib__dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using lib__repositorios.Interfaces;
using lib__repositorios.Implementaciones;
using gim_rat.Tests.Nucleo;
namespace gim_rat.Tests.Entidades
{
    [TestClass]
    public class ClienteTests
    {
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

            [TestMethod]
            public void Ejecutar()
            {
                Assert.AreEqual(cedula, cliente1.Cedula);
                Assert.AreEqual(cedula, cliente2.Cedula);
                Assert.AreEqual(nombre, cliente1.Nombre);
                Assert.AreEqual(nombre, cliente2.Nombre);
                Assert.AreEqual(email, cliente1.Email);
                Assert.AreEqual(email, cliente2.Email);
                Assert.AreEqual(tipoUsuario, cliente1.TipoUsuario);
                Assert.AreEqual(tipoUsuario, cliente2.TipoUsuario);
                Assert.AreEqual(activo, cliente1.Activo);
                Assert.AreEqual(activo, cliente2.Activo);
            }
            public bool Listar()
        {
            this.lista = this.iConexion!.Notas!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Notas()!;
            this.iConexion!.Notas!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.NotaFinal =
            (this.entidad.Nota1 +
            this.entidad.Nota2 +
            this.entidad.Nota3 +
            this.entidad.Nota4 +
            this.entidad.Nota5) / 5;
            var entry = this.iConexion!.Entry<Notas>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Notas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }

}
}
