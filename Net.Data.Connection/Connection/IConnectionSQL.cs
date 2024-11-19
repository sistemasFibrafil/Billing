using System.Data.SqlClient;

namespace Net.Data.Connection
{
    public interface IConnectionSQL
    {
        SqlConnection GetConnection();
    }
}
