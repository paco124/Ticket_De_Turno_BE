using Ticket_De_Turno_BE.Services;
using static Ticket_De_Turno_BE.Models.Login.LoginModels;


namespace Ticket_De_Turno_BE.Methods.Login
{
    public class LoginMethods
    {
        public getUser getUser(validarUser data)
        {
            try
            {
                string username = data.USERNAME != null && data.USERNAME.Any() ? string.Join("','", data.USERNAME) : "";
                string pass = data.PASSWORD != null && data.PASSWORD.Any() ? string.Join("','", data.PASSWORD) : "";

                string qry = $@"SELECT ID_USER,USER_NAME,ID_ROL 
                                FROM USERS
                                WHERE USER_NAME ='{username}'
                                AND PASSWORD ='{pass}'";
                return SQLService.SelectMethod<getUser>(qry, ConnectionService.GetConnectionString()).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
