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

    public class ServiceDetailService : IServiceDetailService
    {
        private IServiceDetailBusiness iServiceDetailBusiness;

        public ServiceDetailService()
        {
            this.iServiceDetailBusiness =
                SimpleIoC.Instance.GetInstance<IServiceDetailBusiness>();
        }

        public SimpleResponse<ServiceDetailDto> Create(ServiceDetailDto dto)
        {
            var response = new SimpleResponse<ServiceDetailDto>();

            try
            {
                var model = SimpleMapper.Map<ServiceDetailDto, ServiceDetailViewModel>(dto);
                var resp = iServiceDetailBusiness.Create(model);
                response = new SimpleResponse<ServiceDetailDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<ServiceDetailViewModel, ServiceDetailDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ServiceDetailDto> Read(int id)
        {
            var response = new SimpleResponse<ServiceDetailDto>();

            try
            {
                var resp  = iServiceDetailBusiness.Read(id);
                var isNullOrDef = resp.Data == null || resp.Data == default(ServiceDetailViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<ServiceDetailViewModel, ServiceDetailDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ServiceDetailDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceDetailDto, ServiceDetailViewModel>(dto);
                response = iServiceDetailBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ServiceDetailDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceDetailDto, ServiceDetailViewModel>(dto);
                response = iServiceDetailBusiness.Delete(model);
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
                response =  iServiceDetailBusiness.Delete(id);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ServiceDetailDto>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceDetailDto>>();

            try
            {
                var resp = iServiceDetailBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<ServiceDetailViewModel, ServiceDetailDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<ServiceDetailDto>();
            return response;
        }
    }
}