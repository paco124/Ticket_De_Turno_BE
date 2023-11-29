using static Ticket_De_Turno_BE.Models.User.UserModels;
using Ticket_De_Turno_BE.Services;
using Microsoft.AspNetCore.Localization;
using static Ticket_De_Turno_BE.Models.Login.LoginModels;

namespace Ticket_De_Turno_BE.Methods.User
{
    public class UserMethods
    {

        public IEnumerable<getNiveles> getNiveles()
        {
            try
            {
                string qry = $@"SELECT ID_NIVEL AS ID,DESCRIPCION  FROM NIVELES";
                return SQLService.SelectMethod<getNiveles>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<getMunicipio> getMunicipios()
        {
            try
            {
                string qry = $@"SELECT ID_MUNICIPIO AS ID,MUNICIPIO FROM MUNICIPIO";
                return SQLService.SelectMethod<getMunicipio>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<getAsunto> getAsuntos()
        {
            try
            {
                string qry = $@"SELECT ID_ASUNTO AS ID, ASUNTO FROM ASUNTO";
                return SQLService.SelectMethod<getAsunto>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<getEstatus> getEstatus()
        {
            try
            {
                string qry = $@"SELECT ID_ESTATUS AS ID, ESTATUS FROM ESTATUS";
                return SQLService.SelectMethod<getEstatus>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic SaveCita(saveCita data)
        {
            try
            {
                string curp = data.CURP != null && data.CURP.Any() ? string.Join("','", data.CURP) : "";
                string nombre = data.NOMBRE != null && data.NOMBRE.Any() ? string.Join("','", data.NOMBRE) : "";
                string paterno = data.PATERNO != null && data.PATERNO.Any() ? string.Join("','", data.PATERNO) : "";
                string materno = data.MATERNO != null && data.MATERNO.Any() ? string.Join("','", data.MATERNO) : "";
                string telefono = data.TELEFONO != null && data.TELEFONO.Any() ? string.Join("','", data.TELEFONO) : "";
                int nivel = data.NIVEL;
                int municipio = data.MUNICIPIO;
                int asunto = data.ASUNTO;
                string fecha_reservada = data.FECHARESERVADA != null && data.FECHARESERVADA.Any() ? string.Join("','", data.FECHARESERVADA) : "";
                int user = data.USER;
                var qryTurno = $@"WITH DatosOrdenados AS (
                                SELECT ID_MUNICIPIO, NO_TURNO,
                                    ROW_NUMBER() OVER (PARTITION BY ID_MUNICIPIO ORDER BY NO_TURNO DESC) AS NumFila
                                FROM CITAS
                            )
                            SELECT
                                ID_MUNICIPIO,NO_TURNO
                            FROM DatosOrdenados
                            WHERE NumFila = 1
                            AND ID_MUNICIPIO ={municipio}";
                var turno = SQLService.SelectMethod<getTurno>(qryTurno, ConnectionService.GetConnectionString()).FirstOrDefault();
                int noTurno = 0;
                if (turno == null)
                {
                    noTurno = 1;
                }
                else
                {
                    noTurno = (int)turno.NO_TURNO + 1;
                }
                

                var qry = $@"INSERT INTO CITAS(CURP,NOMBRE,PATERNO,MATERNO,TELEFONO,ID_NIVEL,ID_MUNICIPIO,
                             ID_ASUNTO,FECHA_CARGA,FECHA_RESERVADA, ID_USER,ID_ESTATUS,NO_TURNO) VALUES 
                             ('{curp}','{nombre}','{paterno}','{materno}',{telefono},{nivel},{municipio},
                             {asunto},GETDATE(),'{fecha_reservada}',{user},2,{noTurno})";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<getCitasForUser> getCitasForUser(postUser data)
        {
            int user = data.USER;
            try
            {
                var qry = $@"SELECT CURP,NOMBRE,PATERNO,MATERNO,TELEFONO,N.DESCRIPCION AS NIVEL,
                                M.MUNICIPIO,A.ASUNTO,FECHA_CARGA AS FECHA,
                                FECHA_RESERVADA AS RESERVACION, U.USER_NAME AS USUARIO, E.ESTATUS,NO_TURNO
                                FROM CITAS C
                                LEFT JOIN NIVELES N
                                ON C.ID_NIVEL = N.ID_NIVEL
                                LEFT JOIN MUNICIPIO M
                                ON C.ID_MUNICIPIO = M.ID_MUNICIPIO
                                LEFT JOIN ASUNTO A
                                ON C.ID_ASUNTO = A.ID_ASUNTO
                                LEFT JOIN USERS U
                                ON C.ID_USER = U.ID_USER
                                LEFT JOIN ESTATUS E
                                ON C.ID_ESTATUS = E.ID_ESTATUS
                                WHERE C.ID_USER = {user}";
                return SQLService.SelectMethod<getCitasForUser>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic cancelarCita(cancelarCita data)
        {
            int user = data.USER;
            string curp = data.CURP;
            try
            {
                var qry = $@"UPDATE CITAS
                                SET ID_ESTATUS = 3
                                WHERE ID_USER = {user}
                                AND CURP ='{curp}'";
                return SQLService.UpdateMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic updateFechaCita(updateCita data)
        {
            int user = data.USER;
            string curp = data.CURP;
            string fecha_reservada = data.Fecha_reservada;
            try
            {
                var qry = $@"UPDATE CITAS
                                SET FECHA_RESERVADA  = {fecha_reservada}
                                WHERE ID_USER = {user}
                                AND CURP ='{curp}'";
                return SQLService.UpdateMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public dynamic updateCita(saveCita data)
        {
            string curp = data.CURP != null && data.CURP.Any() ? string.Join("','", data.CURP) : "";
            string nombre = data.NOMBRE != null && data.NOMBRE.Any() ? string.Join("','", data.NOMBRE) : "";
            string paterno = data.PATERNO != null && data.PATERNO.Any() ? string.Join("','", data.PATERNO) : "";
            string materno = data.MATERNO != null && data.MATERNO.Any() ? string.Join("','", data.MATERNO) : "";
            string telefono = data.TELEFONO != null && data.TELEFONO.Any() ? string.Join("','", data.TELEFONO) : "";
            int nivel = data.NIVEL;
            int municipio = data.MUNICIPIO;
            int asunto = data.ASUNTO;
            string fecha_reservada = data.FECHARESERVADA != null && data.FECHARESERVADA.Any() ? string.Join("','", data.FECHARESERVADA) : "";
            int user = data.USER;
            try
            {
                var qry = $@"UPDATE CITAS
                            SET NOMBRE = '{nombre}', PATERNO = '{paterno}', MATERNO= '{materno}', TELEFONO = '{telefono}', ID_NIVEL = {nivel},
                            ID_MUNICIPIO = {municipio}, ID_ASUNTO = {asunto}, FECHA_RESERVADA = '{fecha_reservada}'
                            WHERE ID_USER = {user}
                            AND CURP ='{curp}'";
                return SQLService.UpdateMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<cancelarCita> validarCitaForGet(cancelarCita data)
        {
            string curp = data.CURP != null && data.CURP.Any() ? string.Join("','", data.CURP) : "";
            int user = data.USER;
            try
            {
                var qry = $@"SELECT CURP,ID_USER AS 'USER' FROM CITAS
                            WHERE ID_USER = {user}
                            AND CURP ='{curp}'";
                return SQLService.SelectMethod<cancelarCita>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<getCitaForUpdate> getCitasForUpdate(cancelarCita data)
        {
            string curp = data.CURP != null && data.CURP.Any() ? string.Join("','", data.CURP) : "";
            int user = data.USER;
            try
            {
                var qry = $@"SELECT NOMBRE,PATERNO,MATERNO,TELEFONO,N.DESCRIPCION AS NIVEL,
                                M.MUNICIPIO,A.ASUNTO,
                                FECHA_RESERVADA AS RESERVACION
                                FROM CITAS C
                                LEFT JOIN NIVELES N
                                ON C.ID_NIVEL = N.ID_NIVEL
                                LEFT JOIN MUNICIPIO M
                                ON C.ID_MUNICIPIO = M.ID_MUNICIPIO
                                LEFT JOIN ASUNTO A
                                ON C.ID_ASUNTO = A.ID_ASUNTO
                                WHERE C.ID_USER = {user}
								AND CURP ='{curp}'";
                return SQLService.SelectMethod<getCitaForUpdate>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
    }
}
