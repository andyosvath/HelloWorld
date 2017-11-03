using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    abstract class ObjectReaderWithConnection<T> : ObjectReaderBase<T>
    {
        //private static string m_connectionString = @"Data Source=YOUR_DB_HERE;Initial Catalog=Test;Integrated Security=True";
        private static string m_connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        protected override System.Data.IDbConnection GetConnection()
        {
            // update to get your connection here

            IDbConnection connection = new SqlConnection(m_connectionString);
            return connection;
        }
    }
}
