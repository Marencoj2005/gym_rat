namespace lib__dominio.Entidades
{
    public class Empleado
    {
        public int Cedula { get; set; }
        public String? Nombre { get; set; }
        public String? Rol { get; set; } // Recepcion, Fisioterapeuta, etc.
        public int SedeId { get; set; }

        public Sede Sede { get; set; }
    }
}
