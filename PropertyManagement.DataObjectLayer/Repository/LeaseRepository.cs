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
    public class LeaseRepository: BaseRepository, ILeaseRepository
    {
        private readonly string connectionString;

        public LeaseRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<List<LeaseList>> LeaseList(int Year, int Month)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intYear", Year);
                dynamicParameters.Add("@p_intMonth", Month);
                var query = await sqlConnection.QueryAsync<LeaseList>("usp_LeaseList", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }
        public async Task<List<PropertiesForLease>> PropertiesForLease()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                var query = await sqlConnection.QueryAsync<PropertiesForLease>("usp_LeasePropertiesList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }
        
        public async Task<Lease> LeaseById(int LeaseId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intLeaseId", LeaseId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<Lease>("usp_LeaseById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }
        
                public async Task LeaseAdd(int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId)
                {
                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        await sqlConnection.OpenAsync();
                        var dynamicParameters = new DynamicParameters();
                        dynamicParameters.Add("@p_intPropertyId", PropertyId);
                        dynamicParameters.Add("@p_intTenantId", TenantId);
                        dynamicParameters.Add("@p_chrLeaseBeginDate", LeaseBeginDate);
                        dynamicParameters.Add("@p_chrLeaseEndDate", LeaseEndDate);
                        dynamicParameters.Add("@p_chrMonthlyLease", MonthlyLease);
                        dynamicParameters.Add("@p_chrProratedAmount", ProratedAmount);
                        dynamicParameters.Add("@p_chrProratedFromDate", ProratedFromDate);
                        dynamicParameters.Add("@p_chrProratedToDate", ProratedToDate);
                        dynamicParameters.Add("@p_chrNotes", Notes);
                        dynamicParameters.Add("@p_intStatusId", StatusId);
                        await sqlConnection.ExecuteAsync("usp_LeaseAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                    }
                }

        public async Task LeaseUpdate(int LeaseId, int PropertyId, int TenantId, string LeaseBeginDate, string LeaseEndDate, decimal MonthlyLease, decimal ProratedAmount, string ProratedFromDate, string ProratedToDate, string Notes, int StatusId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intLeaseId", LeaseId);
                dynamicParameters.Add("@p_intPropertyId", PropertyId);
                dynamicParameters.Add("@p_intTenantId", TenantId);
                dynamicParameters.Add("@p_chrLeaseBeginDate", LeaseBeginDate);
                dynamicParameters.Add("@p_chrLeaseEndDate", LeaseEndDate);
                dynamicParameters.Add("@p_chrMonthlyLease", MonthlyLease);
                dynamicParameters.Add("@p_chrProratedAmount", ProratedAmount);
                dynamicParameters.Add("@p_chrProratedFromDate", ProratedFromDate);
                dynamicParameters.Add("@p_chrProratedToDate", ProratedToDate);
                dynamicParameters.Add("@p_chrNotes", Notes);
                dynamicParameters.Add("@p_intStatusId", StatusId);
                await sqlConnection.ExecuteAsync("usp_LeaseUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
