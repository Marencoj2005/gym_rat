using System.ComponentModel.DataAnnotations.Schema;

    namespace lib__dominio.Entidades
    { 
                public class Asignado
        {

            public int CedulaCoach { get; set; }
            public int IdClase { get; set; }

            public Coach Coach { get; set; } = null!;
            public Clase Clase { get; set; } = null!;
        }

    }
