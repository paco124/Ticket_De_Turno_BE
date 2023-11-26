namespace Ticket_De_Turno_BE.Models.Login
{
    public class LoginModels
    {
        public class validarUser
        {
            public string USERNAME { get; set; }
            public string PASSWORD { get; set; }
        }

        public class getUser
        {
            public int ID_USER { get; set; }
            public string USER_NAME { get; set; }
            public int ID_ROL { get; set; }
        }

    }
}
