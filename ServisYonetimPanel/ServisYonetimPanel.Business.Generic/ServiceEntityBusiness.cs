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
    public class ServiceEntityBusiness : IServiceEntityBusiness
    {
        public ServiceResponse<int> Add(ServiceModel serviceModel)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<int> Delete(object serviceDetailModelId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<IEnumerable<ServiceModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ServiceModel> GetById(long detailId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<int> Update(ServiceModel serviceModel)
        {
            throw new NotImplementedException();
        }
    }
}
