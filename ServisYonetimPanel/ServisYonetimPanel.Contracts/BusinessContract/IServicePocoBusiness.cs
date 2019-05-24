namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Models.Model;
    using SimpleInfra.Common.Response;
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