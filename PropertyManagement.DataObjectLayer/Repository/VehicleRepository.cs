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
    public class VehicleRepository: BaseRepository, IVehicleRepository
    {
        private readonly string connectionString;

        public VehicleRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<List<Vehicle>> VehicleList(int TenantId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intTenantId", TenantId);
                var query = await sqlConnection.QueryAsync<Vehicle>("usp_VehicleList", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public async Task SaveVehicleData(int VehicleId, int TenantId, string Make, string Model, int Year, string LicensePlate, string StateRegistration, string Color, string Notes)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if (VehicleId > 0)
                {
                    dynamicParameters.Add("@p_intVehicleId", VehicleId);
                }

                dynamicParameters.Add("@p_intTenantId", TenantId);
                dynamicParameters.Add("@p_chrMake", Make);
                dynamicParameters.Add("@p_chrModel", Model);
                dynamicParameters.Add("@p_intYear", Year);
                dynamicParameters.Add("@p_chrLicensePlate", LicensePlate);
                dynamicParameters.Add("@p_chrStateRegistration", StateRegistration);
                dynamicParameters.Add("@p_chrColor", Color);
                dynamicParameters.Add("@p_chrNotes", Notes);

                if (VehicleId == 0)
                    await sqlConnection.ExecuteAsync("usp_VehicleAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_VehicleUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<Vehicle> VehicleById(int VehicleId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intVehicleId", VehicleId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<Vehicle>("usp_VehicleById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }
    }
}
