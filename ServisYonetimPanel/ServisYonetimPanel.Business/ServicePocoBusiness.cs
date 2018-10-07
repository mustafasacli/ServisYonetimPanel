namespace ServisYonetimPanel.Business
{
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;
    using ServisYonetimPanel.Models.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ServicePocoBusiness : IServicePocoBusiness
    {
        public ServiceResponse<Guid> Add(ServicePocoModel poco)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Update(ServicePocoModel poco)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<IEnumerable<ServicePocoModel>> GetServicePocos()
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<ServicePocoModel> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
