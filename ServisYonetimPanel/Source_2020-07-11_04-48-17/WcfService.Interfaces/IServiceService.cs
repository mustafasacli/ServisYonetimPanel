namespace Syp.WcfService.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Syp.Dtos;
    
    [ServiceContract(Namespace = "http://127.0.0.1:8081/ServiceService")]
    public interface IServiceService
    {
        [OperationContract]
        SimpleResponse<ServiceDto> Create(ServiceDto dto);

        [OperationContract]
        SimpleResponse<ServiceDto> Read(int id);

        [OperationContract]
        SimpleResponse Update(ServiceDto dto);

        [OperationContract]
        SimpleResponse Delete(ServiceDto dto);

        [OperationContract]
        SimpleResponse Delete(int id);

        [OperationContract]
        SimpleResponse<List<ServiceDto>> ReadAll();
    }
}