namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Models.Model;
    using SimpleInfra.Common.Response;
    using System.Collections.Generic;

    public interface IServiceDetailTypeBusiness
    {
        ServiceResponse<long> Add(ServiceDetailTypeModel serviceDetailTypeModel);

        ServiceResponse<int> Update(ServiceDetailTypeModel serviceDetailTypeModel);

        ServiceResponse<int> Delete(int serviceDetailTypeModelId);

        ServiceResponse<ServiceDetailTypeModel> GetById(long id);

        ServiceResponse<IEnumerable<ServiceDetailTypeModel>> GetAll();
    }
}