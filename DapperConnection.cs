using Dapper;
using DapperExtensions;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;
using System.Data;

namespace BlogProject
{
    public class DapperConnection
    {
        private readonly IConfiguration _config;

        public DapperConnection(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get {
                return new SqliteConnection(_config.GetConnectionString("BloggingDatabase"));
            }
        }
    }
}