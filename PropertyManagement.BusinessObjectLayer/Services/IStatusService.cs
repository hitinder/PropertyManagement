using System;
using System.Collections.Generic;
using System.Text;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using System.Threading.Tasks;

namespace PropertyManagement.BusinessObjectLayer
{
    public interface IStatusService
    {
        Task<List<StatusViewModel>> StatusList();
        List<StatusViewModel> StatusList(int StatusTypeId);
        Task<StatusViewModel> StatusById(int StatusId);
        Task SaveStatusData(string StatusName, int StatusId, int StatusType);
    }


}
