
namespace Ticket_De_Turno_BE.Services
{
    public class ConnectionService
    {
        private static string conn = "";

        private ConnectionService()
        {
            conn = "Server=LAPTOP-I1ML5UUE\\SQLEXPRESS; Database=Ticket; Integrated Security=True; TrustServerCertificate=True";
        }

        public static string GetConnectionString()
        {
            if (conn == "")
            {
                new ConnectionService();
            }
            return conn;
        }
    }
}

