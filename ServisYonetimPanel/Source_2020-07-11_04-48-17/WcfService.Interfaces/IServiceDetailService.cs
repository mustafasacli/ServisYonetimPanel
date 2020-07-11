namespace Syp.WcfService.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Syp.Dtos;
    
    [ServiceContract(Namespace = "http://127.0.0.1:8081/ServiceDetailService")]
    public interface IServiceDetailService
    {
        [OperationContract]
        SimpleResponse<ServiceDetailDto> Create(ServiceDetailDto dto);

        [OperationContract]
        SimpleResponse<ServiceDetailDto> Read(int id);

        [OperationContract]
        SimpleResponse Update(ServiceDetailDto dto);

        [OperationContract]
        SimpleResponse Delete(ServiceDetailDto dto);

        [OperationContract]
        SimpleResponse Delete(int id);

        [OperationContract]
        SimpleResponse<List<ServiceDetailDto>> ReadAll();
    }
}