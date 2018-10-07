namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Models.Model;
    using System;
    using System.Collections.Generic;

    public interface IServicePocoBusiness
    {
        ServiceResponse<Guid> Add(ServicePocoModel poco);

        ServiceResponse<bool> Update(ServicePocoModel poco);

        ServiceResponse<bool> Delete(Guid id);

        ServiceResponse<ServicePocoModel> Get(Guid id);

        ServiceResponse<IEnumerable<ServicePocoModel>> GetServicePocos();
    }
}