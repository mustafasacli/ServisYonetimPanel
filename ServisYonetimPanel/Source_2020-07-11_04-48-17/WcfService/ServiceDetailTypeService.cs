namespace Syp.WcfService
{
    using SimpleInfra.Business.Core;
    using SimpleInfra.Common.Core;
    using SimpleInfra.IoC;
    using SimpleFileLogging;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Mapping;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Syp.Dtos;
    using Syp.Business.Interfaces;
    using Syp.WcfService.Interfaces;
    using Syp.ViewModel;

    public class ServiceDetailTypeService : IServiceDetailTypeService
    {
        private IServiceDetailTypeBusiness iServiceDetailTypeBusiness;

        public ServiceDetailTypeService()
        {
            this.iServiceDetailTypeBusiness =
                SimpleIoC.Instance.GetInstance<IServiceDetailTypeBusiness>();
        }

        public SimpleResponse<ServiceDetailTypeDto> Create(ServiceDetailTypeDto dto)
        {
            var response = new SimpleResponse<ServiceDetailTypeDto>();

            try
            {
                var model = SimpleMapper.Map<ServiceDetailTypeDto, ServiceDetailTypeViewModel>(dto);
                var resp = iServiceDetailTypeBusiness.Create(model);
                response = new SimpleResponse<ServiceDetailTypeDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<ServiceDetailTypeViewModel, ServiceDetailTypeDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ServiceDetailTypeDto> Read(int id)
        {
            var response = new SimpleResponse<ServiceDetailTypeDto>();

            try
            {
                var resp  = iServiceDetailTypeBusiness.Read(id);
                var isNullOrDef = resp.Data == null || resp.Data == default(ServiceDetailTypeViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<ServiceDetailTypeViewModel, ServiceDetailTypeDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ServiceDetailTypeDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceDetailTypeDto, ServiceDetailTypeViewModel>(dto);
                response = iServiceDetailTypeBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ServiceDetailTypeDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceDetailTypeDto, ServiceDetailTypeViewModel>(dto);
                response = iServiceDetailTypeBusiness.Delete(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(int id)
        {
            var response = new SimpleResponse();

            try
            {
                response =  iServiceDetailTypeBusiness.Delete(id);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ServiceDetailTypeDto>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceDetailTypeDto>>();

            try
            {
                var resp = iServiceDetailTypeBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<ServiceDetailTypeViewModel, ServiceDetailTypeDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<ServiceDetailTypeDto>();
            return response;
        }
    }
}