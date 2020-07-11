namespace Syp.WcfService.Interfaces
{
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using Syp.Dtos;
    
    [ServiceContract(Namespace = "http://127.0.0.1:8081/ServiceUserService")]
    public interface IServiceUserService
    {
        [OperationContract]
        SimpleResponse<ServiceUserDto> Create(ServiceUserDto dto);

        [OperationContract]
        SimpleResponse<ServiceUserDto> Read(int id);

        [OperationContract]
        SimpleResponse Update(ServiceUserDto dto);

        [OperationContract]
        SimpleResponse Delete(ServiceUserDto dto);

        [OperationContract]
        SimpleResponse Delete(int id);

        [OperationContract]
        SimpleResponse<List<ServiceUserDto>> ReadAll();
    }
}