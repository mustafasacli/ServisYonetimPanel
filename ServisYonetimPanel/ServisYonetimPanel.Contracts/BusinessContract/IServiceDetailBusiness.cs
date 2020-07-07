namespace ServisYonetimPanel.Contracts.BusinessContract
{
    using ServisYonetimPanel.Models.Model;
    using SimpleInfra.Common.Response;
    using System.Collections.Generic;

    public interface IServiceDetailBusiness
    {
        ServiceResponse<int> Add(ServiceDetailModel serviceDetailModel);

        ServiceResponse<int> Update(ServiceDetailModel serviceDetailModel);

        ServiceResponse<int> Delete(int serviceDetailModelId);

        ServiceResponse<ServiceDetailModel> GetById(long detailId);

        ServiceResponse<IEnumerable<ServiceDetailModel>> GetAll();

        ServiceResponse<IEnumerable<ServiceDetailModel>> GetByServiceId(long serviceId);
    }
}