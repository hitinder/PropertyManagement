using System;
using System.Collections.Generic;
using System.Text;
using PropertyManagement.BusinessObjectLayer.ViewModels;
using PropertyManagement.DataObjectLayer;
using PropertyManagement.DataObjectLayer.Models;
using System.Threading.Tasks;

namespace PropertyManagement.BusinessObjectLayer
{
    public class CommonListService : ICommonListService
    {
        private readonly ICommonListRepository _commonListRepository;

        public CommonListService(ICommonListRepository commonListRepository)
        {
            _commonListRepository = commonListRepository;

        }
        public List<StatesViewModel> StatesList()
        {
            List<States> state = _commonListRepository.StatesList();

            List<StatesViewModel> statesVM = new List<StatesViewModel>();
            foreach (States s in state)
            {
                StatesViewModel sVM = new StatesViewModel();
                sVM.StateId = s.StateId;
                sVM.StateCode = s.StateCode;
                sVM.StateName = s.StateName;

                statesVM.Add(sVM);
            }

            return statesVM;
        }

        public List<PropertyTypeViewModel> PropertyTypeList()
        {
            List<PropertyType> type = _commonListRepository.PropertyTypeList();

            List<PropertyTypeViewModel> statesVM = new List<PropertyTypeViewModel>();
            foreach (PropertyType t in type)
            {
                PropertyTypeViewModel tVM = new PropertyTypeViewModel();
                tVM.PropertyTypeId = t.PropertyTypeId;
                tVM.PropertyTypeName = t.PropertyTypeName;

                statesVM.Add(tVM);
            }
            return statesVM;
        }

        public List<UrgencyTypeViewModel> UrgencyList()
        {
            List<UrgencyType> type = _commonListRepository.UrgencyList();

            List<UrgencyTypeViewModel> urgencyVM = new List<UrgencyTypeViewModel>();
            foreach (UrgencyType u in type)
            {
                UrgencyTypeViewModel uVM = new UrgencyTypeViewModel();
                uVM.UrgencyId = u.UrgencyId;
                uVM.UrgencyName = u.UrgencyName;

                urgencyVM.Add(uVM);
            }
            return urgencyVM;
        }
        public List<ServiceCategoryTypeViewModel> ServiceCategoryList()
        {
            List<ServiceCategoryType> type = _commonListRepository.ServiceCategoryList();

            List<ServiceCategoryTypeViewModel> serviceVM = new List<ServiceCategoryTypeViewModel>();
            foreach (ServiceCategoryType s in type)
            {
                ServiceCategoryTypeViewModel sVM = new ServiceCategoryTypeViewModel();
                sVM.ServiceCategoryId = s.ServiceCategoryId;
                sVM.ServiceCategoryName = s.ServiceCategoryName;

                serviceVM.Add(sVM);
            }
            return serviceVM;
        }

        public List<ProfessionalServiceTypeViewModel> ProfessionalServiceList()
        {
            List<ProfessionalServiceType> type = _commonListRepository.ProfessionalServiceList();

            List<ProfessionalServiceTypeViewModel> professionalVM = new List<ProfessionalServiceTypeViewModel>();
            foreach (ProfessionalServiceType p in type)
            {
                ProfessionalServiceTypeViewModel pVM = new ProfessionalServiceTypeViewModel();
                pVM.ProfessionalServiceId = p.ProfessionalServiceId;
                pVM.CompanyName = p.CompanyName;

                professionalVM.Add(pVM);
            }
            return professionalVM;
        }

        public List<RequestTypeViewModel> RequestTypeList()
        {
            List<RequestType> type = _commonListRepository.RequestTypeList();

            List<RequestTypeViewModel> requestVM = new List<RequestTypeViewModel>();
            foreach (RequestType r in type)
            {
                RequestTypeViewModel rVM = new RequestTypeViewModel();
                rVM.RequestTypeId = r.RequestTypeId;
                rVM.RequestTypeName = r.RequestTypeName;

                requestVM.Add(rVM);
            }
            return requestVM;
        }

        public List<PaymentMethodTypeViewModel> PaymentMethodList()
        {
            List<PaymentMethodType> type = _commonListRepository.PaymentMethodList();

            List<PaymentMethodTypeViewModel> paymentVM = new List<PaymentMethodTypeViewModel>();
            foreach (PaymentMethodType p in type)
            {
                PaymentMethodTypeViewModel pVM = new PaymentMethodTypeViewModel();
                pVM.PaymentMethodId = p.PaymentMethodId;
                pVM.PaymentMethodName = p.PaymentMethodName;

                paymentVM.Add(pVM);
            }
            return paymentVM;
        }
    
    public List<YearViewModel> YearList()
        {
            List<YearModel> years = _commonListRepository.YearList();

            List<YearViewModel> yearVM = new List<YearViewModel>();
            foreach (YearModel y in years)
            {
                YearViewModel yVM = new YearViewModel();
                yVM.YearId = y.YearId;
                yVM.Year = y.Year;

                yearVM.Add(yVM);
            }
            return yearVM;
        }
    
        public List<MonthViewModel> MonthList()
        {
            List<MonthModel> months = _commonListRepository.MonthList();

            List<MonthViewModel> monthVM = new List<MonthViewModel>();
        foreach (MonthModel m in months)
        {
            MonthViewModel mVM = new MonthViewModel();
            mVM.MonthId = m.MonthId;
            mVM.Month = m.Month;
            mVM.MonthAbbr = m.MonthAbbr;

            monthVM.Add(mVM);
        }
        return monthVM;
        }
    }
}

