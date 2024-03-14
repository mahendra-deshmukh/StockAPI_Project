using Microsoft.Data.SqlClient;
using System.Data;

namespace Stock_API_Application.DbUtils
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly String _connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionString = this._configuration.GetConnectionString("connection");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(this._connectionString);
        }
    }
}
