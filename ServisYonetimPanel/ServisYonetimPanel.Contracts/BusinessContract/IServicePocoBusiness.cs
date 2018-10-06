namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Entity;
    using System;
    using System.Collections.Generic;

    public interface IServicePocoBusiness
    {
        ServiceResponse<Guid> Add(ServicePoco poco);

        ServiceResponse<bool> Update(ServicePoco poco);

        ServiceResponse<bool> Delete(Guid id);

        ServiceResponse<ServicePoco> Get(Guid id);

        ServiceResponse<IEnumerable<ServicePoco>> GetServicePocos();
    }
}