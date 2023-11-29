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

        //public class getUser
        //{
        //    public string? ID_USER { get; set; }
        //    public string? USER_NAME { get; set; }
        //}
        public class deleteUser
        {
            public int id { get; set; }
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
            public int NO_TURNO {  get; set; }
        }

        public class ID_data
        {
            public int ID { get; set; }
        }
        public class getRoles : ID_data
        {
            public string ROL { get; set; }
        }
        public class getAllUsers : ID_data
        {
            public string USER_NAME { get; set; }
            public string ROL { get; set; }
        }
        public class updateUser:ID_data
        {
            public string USER_NAME { get; set; }
            public int ID_ROL { get; set; }
        }
        public class setEstatus : ID_data
        {
            public string curp { get; set; }
        }
        public class getDataChart1
        {
            public int RESUELTOS { get; set; }
            public int PENDIENTES { get; set; }
            public int CANCELADOS { get; set; }
            public int TOTAL {  get; set; }
            public DateTime FECHA { get; set; }
        }

        public class getDataChart2
        {
            public string  ASUNTO { get; set; }
            public int CONTEO { get; set; }
        }

        public class insertCRUD
        {
            public string DESCRIPCION { get; set; }
        }
    }
}
