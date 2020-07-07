using ServisYonetimPanel.Contracts.BusinessContract;
using ServisYonetimPanel.Models.Model;
using SimpleInfra.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisYonetimPanel.Business.Generic
{
    public class ServiceDetailBusiness : IServiceDetailBusiness
    {
        public ServiceResponse<int> Add(ServiceDetailModel serviceDetailModel)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<int> Delete(int serviceDetailModelId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<IEnumerable<ServiceDetailModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ServiceDetailModel> GetById(long detailId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<IEnumerable<ServiceDetailModel>> GetByServiceId(long serviceId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<int> Update(ServiceDetailModel serviceDetailModel)
        {
            throw new NotImplementedException();
        }
    }
}
