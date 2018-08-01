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
    public interface IDependentRepository
    {
        Task<List<Dependent>> DependentList(int TenantId);
        Task<Dependent> DependentById(int DependentId);
        Task SaveDependentData(int DependentId, int TenantId, string FirstName, string LastName, string Gender, int Age, string Phone, string Email, string Notes);
    }
}
