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
    public class PropertyRepository: BaseRepository, IPropertyRepository
    {
        private readonly string connectionString;

        public PropertyRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

        public async Task<List<PropertyList>> PropertyList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var query = await sqlConnection.QueryAsync<PropertyList>("usp_PropertyList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }
        
        public List<PropertyList> PropertyList(int PropertyStatusId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intPropertyStatusId", PropertyStatusId);
                var query = sqlConnection.Query<PropertyList>("usp_PropertyList", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<PropertyList> PropertyListForLease()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                var query = sqlConnection.Query<PropertyList>("usp_PropertyListForLease", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public async Task<Property> PropertyById(int PropertyId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_intPropertyId", PropertyId);
                var query = await sqlConnection.QuerySingleOrDefaultAsync<Property>("usp_PropertyById", dynamicParameters, commandType: CommandType.StoredProcedure);
                return query;
            }
        }


        public async Task SavePropertyData(int PropertyId, int PropertyTypeId, string Address, string UnitNumber, string City, int StateId, string ZipCode, string PurchasePrice, string PurchaseDate, string SoldPrice, string SoldDate, string Notes, int StatusId)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                if(PropertyTypeId > 0)
                {
                    dynamicParameters.Add("@p_intPropertyId", PropertyId);
                    dynamicParameters.Add("@p_intStatusId", StatusId);
                }
                
                dynamicParameters.Add("@p_intPropertyTypeId", PropertyTypeId);
                dynamicParameters.Add("@p_chrAddress", Address);
                dynamicParameters.Add("@p_chrUnitNumber", UnitNumber);
                dynamicParameters.Add("@p_chrCity", City);
                dynamicParameters.Add("@p_intStateId", StateId);
                dynamicParameters.Add("@p_intZipCode", ZipCode);
                dynamicParameters.Add("@@p_chrPurchasePrice", PurchasePrice);
                dynamicParameters.Add("@p_chrPurchaseDate", PurchaseDate);
                dynamicParameters.Add("@p_chrSoldPrice", SoldPrice);
                dynamicParameters.Add("@p_chrSoldDate", SoldDate);
                dynamicParameters.Add("@p_chrNotes", Notes);
              

                if (PropertyTypeId == 0)
                    await sqlConnection.ExecuteAsync("usp_PropertyAdd", dynamicParameters, commandType: CommandType.StoredProcedure);
                else
                    await sqlConnection.ExecuteAsync("usp_PropertyUpdate", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
