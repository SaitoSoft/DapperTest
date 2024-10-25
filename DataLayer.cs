using Microsoft.Data.SqlClient;
using Dapper;
using DapperTest.Models.Models;
using System.Runtime.CompilerServices;
using System.Data;
using DapperTest.Data.Intefaces;
using System.Configuration;
using DapperTest.Data.Utility;
using Microsoft.Extensions.Options;

namespace DapperTest.Data.Implementation
{
    public class DataLayer :IDataLayer
    {
        private string _conn;
        private SqlConnection _sqlConnection;
        private readonly ConnectionOptions _options;

        public DataLayer(IOptions<ConnectionOptions> options)
        {
            _options = options.Value;
            _conn = _options.DefaultConnection;
            _sqlConnection = new SqlConnection(_conn);
        }

        public async Task<List<Employees>> GetEmployees()
        {
            var results = new List<Employees>();
            using (IDbConnection connection = new SqlConnection(_conn))
            {
                return (await connection.QueryAsync<Employees>(StaticData.GetAllEmployeesCmd, commandType: CommandType.StoredProcedure)).ToList();
            }
        }

        public async Task<bool> UpdateEmployee(int id, decimal salary) 
        {
            using (IDbConnection connection = new SqlConnection(_conn))
            {
                var queryParams = new DynamicParameters();
                queryParams.Add("@Id", id);
                queryParams.Add("@Salary", salary);

                await connection.QueryAsync<bool>(StaticData.UpdateEmployeeSalaryCmd, queryParams, commandType: CommandType.StoredProcedure);
                return true;
            }
        }


    }
}
