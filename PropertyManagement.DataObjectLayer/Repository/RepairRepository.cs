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
    public class RepairRepository: BaseRepository, IRepairRepository
    {
        private readonly string connectionString;
        public RepairRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<List<RepairList>> RepairList(int PropertyId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intPropertyId", PropertyId);
                var query = await sqlConnection.QueryAsync<RepairList>("usp_RepairList", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }
        public async Task<Repair> RepairById(int RepairId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intRepairId", RepairId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<Repair>("usp_RepairById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }

        public async Task SaveRepairData(int RepairId, int PropertyId, int UrgencyId, int RequestTypeId, int ServiceCategoryId, int ProfessionalServiceId, string Description,
                                                       string RepairReportedDate, string RepairCompletedDate, string TechnicianName, string RepairCost, int PaymentTypeId, string Notes, int StatusId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if (RepairId == 0)
                {
                    dynamicParameters.Add("@p_intPropertyId", PropertyId);
                    dynamicParameters.Add("@p_intUrgencyId", UrgencyId);
                    dynamicParameters.Add("@p_intRequestTypeId", RequestTypeId);
                    dynamicParameters.Add("@p_intServiceCategoryId", ServiceCategoryId);
                    dynamicParameters.Add("@p_intProfessionalServiceId", ProfessionalServiceId);
                    dynamicParameters.Add("@p_chrDescription", Description);
                    dynamicParameters.Add("@p_chrRepairReportedDate", RepairReportedDate);
                    dynamicParameters.Add("@p_chrRepairCompletedDate", RepairCompletedDate);
                    dynamicParameters.Add("@p_chrTechnicianName", TechnicianName);
                    dynamicParameters.Add("@p_chrRepairCost", RepairCost);
                    dynamicParameters.Add("@p_intPaymentTypeId", PaymentTypeId);
                    dynamicParameters.Add("@p_chrNotes", Notes);
                    await sqlConnection.ExecuteAsync("usp_RepairAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    dynamicParameters.Add("@p_intRepairId", RepairId);
                    dynamicParameters.Add("@p_intPropertyId", PropertyId);
                    dynamicParameters.Add("@p_intUrgencyId", UrgencyId);
                    dynamicParameters.Add("@p_intRequestTypeId", RequestTypeId);
                    dynamicParameters.Add("@p_intServiceCategoryId", ServiceCategoryId);
                    dynamicParameters.Add("@p_intProfessionalServiceId", ProfessionalServiceId);
                    dynamicParameters.Add("@p_chrDescription", Description);
                    dynamicParameters.Add("@p_chrRepairReportedDate", RepairReportedDate);
                    dynamicParameters.Add("@p_chrRepairCompletedDate", RepairCompletedDate);
                    dynamicParameters.Add("@p_chrTechnicianName", TechnicianName);
                    dynamicParameters.Add("@p_chrRepairCost", RepairCost);
                    dynamicParameters.Add("@p_intPaymentTypeId", PaymentTypeId);
                    dynamicParameters.Add("@p_chrNotes", Notes);
                    dynamicParameters.Add("@p_intStatusId", StatusId);
                    await sqlConnection.ExecuteAsync("usp_RepairUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}

