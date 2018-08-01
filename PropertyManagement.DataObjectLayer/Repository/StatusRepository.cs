using PropertyManagement.DataObjectLayer;
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
    public class StatusRepository: BaseRepository, IStatusRepository
    {
        private readonly string connectionString;

        public StatusRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<List<Status>> StatusList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var query = await sqlConnection.QueryAsync<Status>("usp_StatusList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<Status> StatusList(int StatusTypeId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                 sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intStatusTypeId", StatusTypeId);
                var query =  sqlConnection.Query<Status>("usp_StatusList", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }


        public async Task SaveStatusData(string StatusName, int StatusId, int StatusType)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if (StatusId > 0)
                {
                    dynamicParameters.Add("@p_intStatusId", StatusId);
                }

                dynamicParameters.Add("@p_chrStatusName", StatusName);
                dynamicParameters.Add("@p_intStatusType", StatusType);

                if (StatusId == 0)
                    await sqlConnection.ExecuteAsync("usp_StatusAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_StatusUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Status> StatusById(int StatusId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intStatusId", StatusId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<Status>("usp_StatusById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }

    }
}
