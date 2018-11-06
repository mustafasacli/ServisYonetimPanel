namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Models.Model;
    using System;
    using System.Collections.Generic;

    public interface IServicePocoBusiness
    {
        ServiceResponse<object> Add(ServicePocoModel poco);

        ServiceResponse<bool> Update(ServicePocoModel poco);

        ServiceResponse<bool> Delete(object id);

        ServiceResponse<ServicePocoModel> Get(object id);

        ServiceResponse<IEnumerable<ServicePocoModel>> GetServicePocos();
    }
}