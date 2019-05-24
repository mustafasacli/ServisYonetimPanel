namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Models.Model;
    using SimpleInfra.Common.Response;
    using System.Collections.Generic;

    public interface IServiceEntityBusiness
    {
        ServiceResponse<int> Add(ServiceModel serviceModel);

        ServiceResponse<int> Update(ServiceModel serviceModel);

        ServiceResponse<int> Delete(object serviceDetailModelId);

        ServiceResponse<ServiceModel> GetById(long detailId);

        ServiceResponse<IEnumerable<ServiceModel>> GetAll();
    }
}