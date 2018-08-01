using PropertyManagement.Infrastructure.BaseClass.ApplicationProperties;
using PropertyManagement.Infrastructure.BaseClass;
using PropertyManagement.DataObjectLayer.Models;
using System.Collections.Generic;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace PropertyManagement.DataObjectLayer
{
    public class DependentRepository: BaseRepository, IDependentRepository
    {
        private readonly string connectionString;

        public DependentRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<List<Dependent>> DependentList(int TenantId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intTenantId", TenantId);
                var query = await sqlConnection.QueryAsync<Dependent>("usp_DependentList", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public async Task SaveDependentData(int DependentId, int TenantId, string FirstName, string LastName, string Gender, int Age, string Phone, string Email, string Notes)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if (DependentId > 0)
                {
                    dynamicParameters.Add("@p_intDependentId", DependentId);
                }
                dynamicParameters.Add("@p_intTenantId", TenantId);
                dynamicParameters.Add("@p_chrFirstNamee", FirstName);
                dynamicParameters.Add("@p_chrLastName", LastName);
                dynamicParameters.Add("@p_chrGender", Gender);
                dynamicParameters.Add("@p_intAge", Age);
                dynamicParameters.Add("@p_chrPhone", Phone);
                dynamicParameters.Add("@p_chrEmail", Email);
                dynamicParameters.Add("@p_chrNotes", Notes);

                if (DependentId == 0)
                    await sqlConnection.ExecuteAsync("usp_DependentAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_DependentUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Dependent> DependentById(int DependentId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intDependentId", DependentId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<Dependent>("usp_DependentById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }
    }
}
