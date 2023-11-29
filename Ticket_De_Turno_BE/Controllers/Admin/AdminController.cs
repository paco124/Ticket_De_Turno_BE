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
        public ActionResult getUser(ID_data data)
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
        public ActionResult updateUser(updateUser data)
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
        [HttpGet]
        [Route("getRoles")]
        public ActionResult getRoles()
        {
            string apiName = "getRoles";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getRoles(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getAllUsers")]
        public ActionResult getAllUsers()
        {
            string apiName = "getAllUsers";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getAllUsers(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpPost]
        [Route("setEstatus")]
        public ActionResult setEstatus(setEstatus data)
        {
            string apiName = "setEstatus";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.setEstatus(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getDataChart1")]
        public ActionResult getDataChart1()
        {
            string apiName = "getDataChart1";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getDataChart1(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpGet]
        [Route("getDataChart2")]
        public ActionResult getDataChart2()
        {
            string apiName = "getDataChart2";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.getDataChart2(), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }

        [HttpPost]
        [Route("insertAsunto")]
        public ActionResult insertAsunto(insertCRUD data)
        {
            string apiName = "insertAsunto";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.insertAsunto(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
        [HttpPost]
        [Route("insertEstatus")]
        public ActionResult insertEstatus(insertCRUD data)
        {
            string apiName = "insertEstatus";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.insertEstatus(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
        [HttpPost]
        [Route("insertMunicipio")]
        public ActionResult insertMunicipio(insertCRUD data)
        {
            string apiName = "insertMunicipio";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.insertMunicipio(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
        [HttpPost]
        [Route("insertNivel")]
        public ActionResult insertNivel(insertCRUD data)
        {
            string apiName = "insertNivel";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.insertNivel(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
        [HttpPost]
        [Route("insertRol")]
        public ActionResult insertRol(insertCRUD data)
        {
            string apiName = "insertRol";

            try
            {
                return Ok(new { apiName, msg = "OK", data = methods.insertRol(data), error = false });
            }
            catch (Exception ex)
            {
                return Ok(new { apiName, msg = ex.Message, error = true });
            }
        }
    }
}
