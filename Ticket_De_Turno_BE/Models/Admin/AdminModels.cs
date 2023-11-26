namespace Ticket_De_Turno_BE.Models.Admin
{
    public class AdminModels
    {
        public class insertAsunto
        {
            public string ASUNTO { get; set; }
        }
        public class insertStatus
        {
            public string ESTATUS { get; set; }
        }
        public class insertNivel
        {
            public string DESCRIPCION { get; set; }
        }
        public class insertRoles
        {
            public string ROL { get; set; }
        }
        public class insertUsers
        {
            public string USER_NAME { get; set; }
            public string? PASSWORD {  get; set; }
            public int ID_ROL { get; set; }
        }

        public class getUser
        {
            public string? ID_USER { get; set; }
            public string? USER_NAME { get; set; }
        }
        public class deleteUser
        {
            public string USER_NAME { get; set; }
        }

        public class getUserAdmin
        {
            public int ID_USER { get; set; }
            public string USER_NAME { get; set; }
            public int ID_ROL { get; set; }
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
        }
    }
}
