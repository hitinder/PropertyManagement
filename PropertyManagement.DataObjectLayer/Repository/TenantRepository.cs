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
    public class TenantRepository : BaseRepository, ITenantRepository
    {
        private readonly string connectionString;

        public TenantRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<List<TenantList>> TenantList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var query = await sqlConnection.QueryAsync<TenantList>("usp_TenantList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }


        public async Task<Tenant> TenantById(int TenantId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intTenantId", TenantId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<Tenant>("usp_TenantById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }


        public async Task SaveTenantData(int TenantId, string FirstName, string LastName, string DOB, int Age, string Gender, string DriverLicenseNo, string Phone, string Email,
                                            string EmergencyContact, int PropertyId, string MoveInDate, string MoveOutDate, decimal MonthlyRent, decimal DepositAmount,
                                            decimal DepositReturned, decimal DepositWithHold, string Notes, decimal ProratedRent, int StatusId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();

                if (TenantId > 0)
                {
                    dynamicParameters.Add("@p_intTenantId", TenantId);
                    dynamicParameters.Add("@p_intStatusId", StatusId);
                }              
                dynamicParameters.Add("@p_chrFirstName", FirstName);
                dynamicParameters.Add("@p_chrLastName", LastName);
                dynamicParameters.Add("@p_chrDOB", DOB);
                dynamicParameters.Add("@p_chrDriverLicenseNo", DriverLicenseNo);
                dynamicParameters.Add("@p_chrGender", Gender);
                dynamicParameters.Add("@p_chrEmail", Email);
                dynamicParameters.Add("@p_chrPhone", Phone);
                dynamicParameters.Add("@p_chrEmergencyContact", EmergencyContact);
                dynamicParameters.Add("@p_intAge", Age);
                dynamicParameters.Add("@p_intPropertyId", PropertyId);
                dynamicParameters.Add("@p_chrNotes", Notes);
                dynamicParameters.Add("@p_chrMoveInDate", MoveInDate);
                dynamicParameters.Add("@p_chrMoveOutDate", MoveOutDate);
                dynamicParameters.Add("@p_chrDepositAmount", DepositAmount);
                dynamicParameters.Add("@p_chrDepositWithHold", DepositWithHold);
                dynamicParameters.Add("@p_chrDepositReturned", DepositReturned);
                dynamicParameters.Add("@p_chrMontlyRent", MonthlyRent);
                dynamicParameters.Add("@p_chrProratedRent", ProratedRent);

                if(TenantId == 0)
                    await sqlConnection.ExecuteAsync("usp_TenantAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_TenantUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
