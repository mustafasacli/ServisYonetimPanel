namespace ServisYonetimPanel.Business
{
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicePocoBusiness : IServicePocoBusiness
    {
        public ServiceResponse<Guid> Add(ServicePoco poco)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Update(ServicePoco poco)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<IEnumerable<ServicePoco>> GetServicePocos()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ServicePoco> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
