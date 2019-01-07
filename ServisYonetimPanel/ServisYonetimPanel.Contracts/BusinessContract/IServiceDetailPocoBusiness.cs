namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Models.Model;
    using System.Collections.Generic;

    public interface IServiceDetailPocoBusiness
    {
        ServiceResponse<object> Add(ServiceDetailPocoModel poco);

        ServiceResponse<bool> Update(ServiceDetailPocoModel poco);

        ServiceResponse<bool> Delete(long id);

        ServiceResponse<IEnumerable<ServiceDetailPocoModel>> GetServiceDetailPocos(long masterId);

        ServiceResponse<IEnumerable<ServiceDetailPocoModel>> GetServiceDetailPocosBYMasterKey(string masterKey);

        ServiceResponse<ServiceDetailPocoModel> Get(object id);
    }
}