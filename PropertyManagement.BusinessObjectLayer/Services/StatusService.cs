using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using PropertyManagement.DataObjectLayer;
using PropertyManagement.DataObjectLayer.Models;
using System.Threading.Tasks;


namespace PropertyManagement.BusinessObjectLayer
{
    public class StatusService: IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;

        }

        public async Task<List<StatusViewModel>> StatusList()
        {    
            List<Status> status  = await _statusRepository.StatusList();

            List<StatusViewModel> statusVM = new List<StatusViewModel>();
            foreach(Status s in status)
            {
                StatusViewModel sVM = new StatusViewModel();
                sVM.StatusId = s.StatusId;
                sVM.StatusName = s.StatusName;
                sVM.StatusType = s.StatusType;
                statusVM.Add(sVM);
            }

            return statusVM;
        }

        public  List<StatusViewModel> StatusList(int StatusTypeId)
        {
            List<Status> status = _statusRepository.StatusList(StatusTypeId);

            List<StatusViewModel> statusVM = new List<StatusViewModel>();
            foreach (Status s in status)
            {
                StatusViewModel sVM = new StatusViewModel();
                sVM.StatusId = s.StatusId;
                sVM.StatusName = s.StatusName;
                sVM.StatusType = s.StatusType;
                statusVM.Add(sVM);
            }

            return statusVM;
        }

        public async Task<StatusViewModel> StatusById(int StatusId)
        {
            var s = await _statusRepository.StatusById(StatusId);
         
            StatusViewModel sVM = new StatusViewModel();
                sVM.StatusId = s.StatusId;
                sVM.StatusName = s.StatusName;
                sVM.StatusType = s.StatusType;
           
            return sVM;
        }

        public async Task SaveStatusData(string StatusName, int StatusId, int StatusType)
        {
            await _statusRepository.SaveStatusData(StatusName, StatusId, StatusType);
        }

    }
}
