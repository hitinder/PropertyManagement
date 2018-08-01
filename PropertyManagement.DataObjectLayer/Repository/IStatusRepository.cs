using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PropertyManagement.DataObjectLayer.Models;

namespace PropertyManagement.DataObjectLayer
{
    public interface IStatusRepository
    {
        Task<List<Status>> StatusList();
        List<Status> StatusList(int StatusTypeId);
        Task<Status> StatusById(int StatusId);
        Task SaveStatusData(string StatusName, int StatusId, int StatusType);
    }
}
