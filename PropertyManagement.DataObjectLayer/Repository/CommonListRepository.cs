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
    public class CommonListRepository: BaseRepository, ICommonListRepository
    {
        private readonly string connectionString;

        public CommonListRepository(IApplicationProperties applicationProperties) : base(applicationProperties)
        {
            connectionString = applicationProperties.ConnectionString;
        }

       public List<States> StatesList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                 sqlConnection.Open();
                var query =  sqlConnection.Query<States>("usp_StatesList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }
        public List<PropertyType> PropertyTypeList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<PropertyType>("usp_PropertyTypeList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<UrgencyType> UrgencyList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<UrgencyType>("usp_UrgencyList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<ServiceCategoryType> ServiceCategoryList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<ServiceCategoryType>("usp_ServiceCategoryList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<ProfessionalServiceType> ProfessionalServiceList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<ProfessionalServiceType>("usp_ProfessionalServiceList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<RequestType> RequestTypeList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<RequestType>("usp_RequestTypeList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<PaymentMethodType> PaymentMethodList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<PaymentMethodType>("usp_PaymentMethodList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<YearModel> YearList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<YearModel>("usp_YearList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }

        public List<MonthModel> MonthList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var query = sqlConnection.Query<MonthModel>("usp_MonthList", null, commandType: CommandType.StoredProcedure);
                return query.ToList();
            }
        }
    }
}
