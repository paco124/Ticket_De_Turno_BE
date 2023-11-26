using Microsoft.AspNetCore.Mvc;
using Ticket_De_Turno_BE.Methods.Admin;
using static Ticket_De_Turno_BE.Models.Admin.AdminModels;
using static Ticket_De_Turno_BE.Models.User.UserModels;

namespace Ticket_De_Turno_BE.Controllers.Admin
{
    [ApiController]
    [Route("Admin")]
    public class AdminController: ControllerBase
    {
        AdminMethods methods = new AdminMethods();


        [HttpPost]
        [Route("insertUser")]
        public ActionResult insertUser(insertUsers data)
        {
            string apiName = "insertUser";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.insertUser(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpPost]
        [Route("getUser")]
        public ActionResult getUser(getUser data)
        {
            string apiName = "getUser";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getUser(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
        [HttpPost]
        [Route("updateUser")]
        public ActionResult updateUser(insertUsers data)
        {
            string apiName = "updateUser";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.updateUser(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpPost]
        [Route("deleteUser")]
        public ActionResult deleteUser(deleteUser data)
        {
            string apiName = "deleteUser";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.deleteUser(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getCitasForAdmin")]
        public ActionResult getCitasForAdmin()
        {
            string apiName = "getCitasForAdmin";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getCitasForAdmin(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
    }
}
