using static Ticket_De_Turno_BE.Models.Admin.AdminModels;
using Ticket_De_Turno_BE.Services;
using System.ComponentModel;
using Microsoft.AspNetCore.Components;

namespace Ticket_De_Turno_BE.Methods.Admin
{
    public class AdminMethods
    {
        public dynamic insertAsunto(insertAsunto data)
        {
            try
            {
                string asunto = data.ASUNTO != null && data.ASUNTO.Any() ? string.Join("','", data.ASUNTO) : "";
                var qry = $@"INSERT INTO ASUNTO(ASUNTO) VALUES('{asunto}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public dynamic insertStatus(insertStatus data)
        {
            try
            {
                string estatus = data.ESTATUS != null && data.ESTATUS.Any() ? string.Join("','", data.ESTATUS) : "";
                var qry = $@"INSERT INTO ESTATUS(ESTATUS) VALUES('{estatus}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic insertNivel(insertNivel data)
        {
            try
            {
                string nivel = data.DESCRIPCION != null && data.DESCRIPCION.Any() ? string.Join("','", data.DESCRIPCION) : "";
                var qry = $@"INSERT INTO NIVELES(DESCRIPTION) VALUES('{nivel}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic insertRoles(insertRoles data)
        {
            try
            {
                string rol = data.ROL != null && data.ROL.Any() ? string.Join("','", data.ROL) : "";
                var qry = $@"INSERT INTO ROLES(ROL) VALUES('{rol}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic insertUser(insertUsers data)
        {
            try
            {
                string user_name = data.USER_NAME != null && data.USER_NAME.Any() ? string.Join("','", data.USER_NAME) : "";
                string pass = data.PASSWORD != null && data.PASSWORD.Any() ? string.Join("','", data.PASSWORD) : "";
                int id_rol = (int)data.ID_ROL;
                var qry = $@"INSERT INTO USERS(USER_NAME,PASSWORD,ID_ROL) VALUES ('{user_name}','{pass}',{id_rol});";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public getUserAdmin getUser(getUser data)
        {
            try
            {
                string user_name = data.USER_NAME != null && data.USER_NAME.Any() ? string.Join("','", data.USER_NAME) : "";
                string id_user = data.ID_USER != null && data.ID_USER.Any() ? string.Join("','", data.ID_USER) : "";
                var user = "";
                if (user_name != null && user_name != "")
                {
                    user = $"WHERE USER_NAME ='{user_name}'";
                }
                if (id_user != null && id_user != "")
                {
                    user = $"WHERE ID_USER = {id_user}";
                }
                var qry = $@"SELECT ID_USER,USER_NAME, ID_ROL FROM USERS
                            {user}";
                return SQLService.SelectMethod<getUserAdmin>(qry, ConnectionService.GetConnectionString()).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        public dynamic updateUser(insertUsers data)
        {
            try
            {
                string user_name = data.USER_NAME != null && data.USER_NAME.Any() ? string.Join("','", data.USER_NAME) : "";
                int id_rol = (int)data.ID_ROL;

                var qry = $@"UPDATE USERS
                            SET  ID_ROL ={id_rol}
                            WHERE USER_NAME ='{user_name}'";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic deleteUser(deleteUser data)
        {
            try
            {
                string user_name = data.USER_NAME != null && data.USER_NAME.Any() ? string.Join("','", data.USER_NAME) : "";

                var qry = $@"DELETE FROM USERS
                                WHERE USER_NAME ='{user_name}'";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<getCitasForUser> getCitasForAdmin()
        {
            try
            {
                var qry = $@"SELECT CURP,NOMBRE,PATERNO,MATERNO,TELEFONO,N.DESCRIPCION AS NIVEL,
                                M.MUNICIPIO,A.ASUNTO,FECHA_CARGA AS FECHA,
                                FECHA_RESERVADA AS RESERVACION, U.USER_NAME AS USUARIO, E.ESTATUS
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
                                ON C.ID_ESTATUS = E.ID_ESTATUS";
                return SQLService.SelectMethod<getCitasForUser>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
    }
}
