using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace Ticket_De_Turno_BE.Services
{
    public class SQLService
    {
        public static IEnumerable<T> SelectMethod<T>(string qry, string connectionString)
        {
            IEnumerable<DataRow> datalist;
            DataColumnCollection Columns;
            using (var cnx = new SqlConnection(connectionString))
            {
                try
                {
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(qry, cnx);
                    cmd.CommandTimeout = 600;
                    SqlDataReader reader = cmd.ExecuteReader();

                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    Columns = dataTable.Columns;
                    datalist = dataTable.Select();
                }
                catch (Exception)
                {
                    cnx.Close();
                    cnx.Dispose();
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                }
            }
            foreach (var x in datalist)
            {
                var obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in (obj?.GetType()?.GetProperties()?.ToList() ?? new List<PropertyInfo>()))
                {
                    try
                    {
                        if (Columns.Contains(prop.Name) && !object.Equals(x[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, x[prop.Name], null);
                        }
                    }
                    catch
                    {

                    }
                }
                yield return obj;
            }
        }

        public static int InsertMethod(string query, string connectionString)
        {
            try
            {
                //Agregar select scope identity
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    try
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand(query, cnx);
                        cmd.CommandTimeout = 1000;
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    catch (Exception)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        throw;
                    }
                    finally
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int UpdateMethod(string query, string connectionString)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    try
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand(query, cnx);
                        cmd.CommandTimeout = 1000;
                        return Convert.ToInt32(cmd.ExecuteNonQuery());
                    }
                    catch (Exception)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        throw;
                    }
                    finally
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteMethod(string query, string connectionString)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    try
                    {
                        cnx.Open();
                        SqlCommand cmd = new SqlCommand(query, cnx);
                        cmd.CommandTimeout = 1000;
                        return Convert.ToInt32(cmd.ExecuteNonQuery());
                    }
                    catch (Exception)
                    {
                        cnx.Close();
                        cnx.Dispose();
                        throw;
                    }
                    finally
                    {
                        cnx.Close();
                        cnx.Dispose();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
