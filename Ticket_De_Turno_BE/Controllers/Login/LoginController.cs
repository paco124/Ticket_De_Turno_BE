using Microsoft.AspNetCore.Mvc;
using Ticket_De_Turno_BE.Methods.Login;
using static Ticket_De_Turno_BE.Models.Login.LoginModels;

namespace Ticket_De_Turno_BE.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        LoginMethods methods = new LoginMethods();


        [HttpPost]
        [Route("validarUser")]
        public ActionResult validarUser(validarUser user)
        {
            string apiName = "validarUser";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getUser(user), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
    }
}
