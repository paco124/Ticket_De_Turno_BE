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
        public getAllUsers getUser(ID_data data)
        {
            try
            {
                int id_user = data.ID;
                var qry = $@"SELECT ID_USER AS ID, USER_NAME, R.ROL
                                FROM USERS U
                                LEFT JOIN ROLES R ON U.ID_ROL= R.ID_ROL
                                where ID_USER = {id_user}";
                return SQLService.SelectMethod<getAllUsers>(qry, ConnectionService.GetConnectionString()).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
        public dynamic updateUser(updateUser data)
        {
            try
            {
                string user_name = data.USER_NAME != null && data.USER_NAME.Any() ? string.Join("','", data.USER_NAME) : "";
                int id_rol = (int)data.ID_ROL;
                int id_user = (int)data.ID;

                var qry = $@"UPDATE USERS
                            SET  ID_ROL ={id_rol}, USER_NAME ='{user_name}'
                            WHERE ID_USER ={id_user}";
                return SQLService.UpdateMethod(qry, ConnectionService.GetConnectionString());
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
                int id_user = (int)data.id;

                var qry = $@"DELETE FROM USERS
                                WHERE ID_USER ='{id_user}'";
                return SQLService.DeleteMethod(qry, ConnectionService.GetConnectionString());
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
                                ON C.ID_ESTATUS = E.ID_ESTATUS";
                return SQLService.SelectMethod<getCitasForUser>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<getRoles> getRoles()
        {
            try
            {
                var qry = $@"SELECT ID_ROL AS ID, ROL FROM ROLES";
                return SQLService.SelectMethod<getRoles>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<getAllUsers> getAllUsers()
        {
            try
            {
                var qry = $@"SELECT ID_USER AS ID, USER_NAME, R.ROL
                                FROM USERS U
                                LEFT JOIN ROLES R ON U.ID_ROL= R.ID_ROL";
                return SQLService.SelectMethod<getAllUsers>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic setEstatus(setEstatus data)
        {
            try
            {
                string curp = data.curp != null && data.curp.Any() ? string.Join("','", data.curp) : "";

                int id_estatus = (int)data.ID;

                var qry = $@"UPDATE CITAS
                                SET  ID_ESTATUS = {id_estatus}
                                WHERE CURP ='{curp}'";
                return SQLService.UpdateMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<getDataChart1> getDataChart1()
        {
            try
            {
                var qry = $@"SELECT
                            COUNT(DISTINCT CASE WHEN C.ID_ESTATUS = 1 THEN C.CURP ELSE NULL END) AS RESUELTOS,
                            COUNT(DISTINCT CASE WHEN C.ID_ESTATUS = 2 THEN C.CURP ELSE NULL END) AS PENDIENTES,
                            COUNT(DISTINCT CASE WHEN C.ID_ESTATUS = 3 THEN C.CURP ELSE NULL END) AS CANCELADOS,
                            COUNT(DISTINCT C.CURP) AS TOTAL,
                            C.FECHA_RESERVADA AS FECHA
                            FROM CITAS C
                            GROUP BY C.FECHA_RESERVADA
                            ORDER BY C.FECHA_RESERVADA";
                return SQLService.SelectMethod<getDataChart1>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<getDataChart2> getDataChart2()
        {
            try
            {
                var qry = $@"SELECT 
                            DISTINCT A.ASUNTO AS ASUNTO, COUNT(*) AS CONTEO
                            FROM CITAS C
                            LEFT JOIN ASUNTO A ON C.ID_ASUNTO = A.ID_ASUNTO 
                            GROUP BY A.ASUNTO
                            ORDER BY A.ASUNTO";
                return SQLService.SelectMethod<getDataChart2>(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }

        public dynamic insertAsunto(insertCRUD data)
        {
            try
            {
                string asunto = data.DESCRIPCION != null && data.DESCRIPCION.Any() ? string.Join("','", data.DESCRIPCION) : "";
                var qry = $@"INSERT INTO ASUNTO(ASUNTO) VALUES('{asunto}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic insertEstatus(insertCRUD data)
        {
            try
            {
                string asunto = data.DESCRIPCION != null && data.DESCRIPCION.Any() ? string.Join("','", data.DESCRIPCION) : "";
                var qry = $@"INSERT INTO ESTATUS(ESTATUS) VALUES('{asunto}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic insertMunicipio(insertCRUD data)
        {
            try
            {
                string asunto = data.DESCRIPCION != null && data.DESCRIPCION.Any() ? string.Join("','", data.DESCRIPCION) : "";
                var qry = $@"INSERT INTO MUNICIPIO(MUNICIPIO) VALUES('{asunto}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic insertNivel(insertCRUD data)
        {
            try
            {
                string asunto = data.DESCRIPCION != null && data.DESCRIPCION.Any() ? string.Join("','", data.DESCRIPCION) : "";
                var qry = $@"INSERT INTO NIVELES(DESCRIPCION) VALUES('{asunto}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
        public dynamic insertRol(insertCRUD data)
        {
            try
            {
                string asunto = data.DESCRIPCION != null && data.DESCRIPCION.Any() ? string.Join("','", data.DESCRIPCION) : "";
                var qry = $@"INSERT INTO ROLES(ROL) VALUES('{asunto}')";
                return SQLService.InsertMethod(qry, ConnectionService.GetConnectionString());
            }
            catch
            {
                throw;
            }
        }
    }
}
