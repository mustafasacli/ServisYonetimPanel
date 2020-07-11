namespace Syp.WcfService.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Syp.Dtos;
    
    [ServiceContract(Namespace = "http://127.0.0.1:8081/ServiceDetailTypeService")]
    public interface IServiceDetailTypeService
    {
        [OperationContract]
        SimpleResponse<ServiceDetailTypeDto> Create(ServiceDetailTypeDto dto);

        [OperationContract]
        SimpleResponse<ServiceDetailTypeDto> Read(int id);

        [OperationContract]
        SimpleResponse Update(ServiceDetailTypeDto dto);

        [OperationContract]
        SimpleResponse Delete(ServiceDetailTypeDto dto);

        [OperationContract]
        SimpleResponse Delete(int id);

        [OperationContract]
        SimpleResponse<List<ServiceDetailTypeDto>> ReadAll();
    }
}