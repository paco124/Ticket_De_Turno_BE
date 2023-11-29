namespace Ticket_De_Turno_BE.Models.User
{
    public class UserModels
    {
        public class BaseEntity
        {
            public int ID { get; set; }
        }

        public class getNiveles : BaseEntity
        {
            public string DESCRIPCION { get; set; }
        }

        public class getMunicipio : BaseEntity
        {
            public string MUNICIPIO { get; set; }
        }

        public class getAsunto : BaseEntity
        {
            public string ASUNTO { get; set; }
        }

        public class getEstatus : BaseEntity
        {
            public string ESTATUS { get; set; }
        }

        public class saveCita
        {
            public string CURP { get; set; }
            public string NOMBRE { get; set; }
            public string PATERNO { get; set; }
            public string MATERNO { get; set; }
            public string TELEFONO { get; set; }
            public int NIVEL { get; set; }
            public int MUNICIPIO { get; set; }
            public int ASUNTO { get; set; }
            public string FECHARESERVADA { get; set; }
            public int USER { get; set; }
        }
        public class postUser
        {
            public int USER { get; set; }
        }
        public class getCitasForUser
        {
            public string CURP { get; set; }
            public string NOMBRE { get; set; }
            public string PATERNO { get; set; }
            public string MATERNO { get; set; }
            public string TELEFONO { get; set; }
            public string NIVEL { get; set; }
            public string MUNICIPIO { get; set; }
            public string ASUNTO { get; set; }
            public DateTime FECHA { get; set; }
            public DateTime RESERVACION { get; set; }
            public string USUARIO { get; set; }
            public string ESTATUS { get; set; }
            public int NO_TURNO { get; set; }
        }
        public class cancelarCita : postUser
        {
            public string CURP { get; set;}
        }

        public class updateCita: cancelarCita
        {
            public string Fecha_reservada { get; set; }
        }

        public class getCitaForUpdate
        {
            public string nombre { get; set; }
            public string paterno { get; set; }
            public string materno { get; set; }
            public string telefono { get; set; }
            public string nivel { get; set; }
            public string municipio { get; set; }
            public string asunto { get; set; }
            public DateTime reservacion { get; set; }
        }
        public class getTurno
        {
            public int NO_TURNO { get; set; }
            public int ID_MUNICIPIO { get; set; }
        }
    }
    }
