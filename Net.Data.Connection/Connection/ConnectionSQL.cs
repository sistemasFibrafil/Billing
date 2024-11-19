using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Net.Data.Connection
{
    public class ConnectionSQL : IConnectionSQL
    {
        private string ConnectionString { get; set; }
        private SqlConnection Connection { get; set; }

        public ConnectionSQL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["cnnSql"].ConnectionString;
        }
        public SqlConnection GetConnection()
        {
            try
            {
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                if (Connection.State.Equals(0))
                {
                    throw new Exception("No puede conectarse a la base de datos.");
                }
                return Connection;
            }
            catch (SqlException eq)
            {
                throw eq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
