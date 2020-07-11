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

    public class ServiceService : IServiceService
    {
        private IServiceBusiness iServiceBusiness;

        public ServiceService()
        {
            this.iServiceBusiness =
                SimpleIoC.Instance.GetInstance<IServiceBusiness>();
        }

        public SimpleResponse<ServiceDto> Create(ServiceDto dto)
        {
            var response = new SimpleResponse<ServiceDto>();

            try
            {
                var model = SimpleMapper.Map<ServiceDto, ServiceViewModel>(dto);
                var resp = iServiceBusiness.Create(model);
                response = new SimpleResponse<ServiceDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<ServiceViewModel, ServiceDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ServiceDto> Read(int id)
        {
            var response = new SimpleResponse<ServiceDto>();

            try
            {
                var resp  = iServiceBusiness.Read(id);
                var isNullOrDef = resp.Data == null || resp.Data == default(ServiceViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<ServiceViewModel, ServiceDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ServiceDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceDto, ServiceViewModel>(dto);
                response = iServiceBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ServiceDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceDto, ServiceViewModel>(dto);
                response = iServiceBusiness.Delete(model);
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
                response =  iServiceBusiness.Delete(id);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ServiceDto>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceDto>>();

            try
            {
                var resp = iServiceBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<ServiceViewModel, ServiceDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<ServiceDto>();
            return response;
        }
    }
}