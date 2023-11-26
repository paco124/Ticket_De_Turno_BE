using Microsoft.AspNetCore.Mvc;
using Ticket_De_Turno_BE.Methods.User;
using static Ticket_De_Turno_BE.Models.Login.LoginModels;
using static Ticket_De_Turno_BE.Models.User.UserModels;

namespace Ticket_De_Turno_BE.Controllers.User
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        UserMethods methods = new UserMethods();

        [HttpPost]
        [Route("SaveCita")]
        public ActionResult SaveCita(saveCita data)
        {
            string apiName = "SaveCita";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.SaveCita(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getNiveles")]
        public ActionResult getNiveles()
        {
            string apiName = "getNiveles";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getNiveles(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getMunicipios")]
        public ActionResult getMunicipios()
        {
            string apiName = "getMunicipios";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getMunicipios(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getAsuntos")]
        public ActionResult getAsuntos()
        {
            string apiName = "getAsuntos";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getAsuntos(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getEstatus")]
        public ActionResult getEstatus()
        {
            string apiName = "getEstatus";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getEstatus(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }



        [HttpPost]
        [Route("getCitasForUser")]
        public ActionResult getCitasForUser(postUser data)
        {
            string apiName = "getCitasForUser";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getCitasForUser(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
        [HttpPost]
        [Route("cancelarCita")]
        public ActionResult cancelarCita(cancelarCita data)
        {
            string apiName = "cancelarCita";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.cancelarCita(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpPost]
        [Route("updateCita")]
        public ActionResult updateCita(saveCita data)
        {
            string apiName = "updateCita";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.updateCita(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpPost]
        [Route("validarCitaForGet")]
        public ActionResult validarCitaForGet(cancelarCita data)
        {
            string apiName = "validarCitaForGet";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.validarCitaForGet(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpPost]
        [Route("getCitasForUpdate")]
        public ActionResult getCitasForUpdate(cancelarCita data)
        {
            string apiName = "getCitasForUpdate";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getCitasForUpdate(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
    }
}
