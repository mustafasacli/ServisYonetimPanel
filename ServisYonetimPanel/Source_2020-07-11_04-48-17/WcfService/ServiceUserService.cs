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

    public class ServiceUserService : IServiceUserService
    {
        private IServiceUserBusiness iServiceUserBusiness;

        public ServiceUserService()
        {
            this.iServiceUserBusiness =
                SimpleIoC.Instance.GetInstance<IServiceUserBusiness>();
        }

        public SimpleResponse<ServiceUserDto> Create(ServiceUserDto dto)
        {
            var response = new SimpleResponse<ServiceUserDto>();

            try
            {
                var model = SimpleMapper.Map<ServiceUserDto, ServiceUserViewModel>(dto);
                var resp = iServiceUserBusiness.Create(model);
                response = new SimpleResponse<ServiceUserDto>()
                {
                    ResponseCode = resp.ResponseCode,
                    ResponseMessage = resp.ResponseMessage,
                    RCode = resp.RCode
                };

                response.Data = SimpleMapper.Map<ServiceUserViewModel, ServiceUserDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ServiceUserDto> Read(int id)
        {
            var response = new SimpleResponse<ServiceUserDto>();

            try
            {
                var resp  = iServiceUserBusiness.Read(id);
                var isNullOrDef = resp.Data == null || resp.Data == default(ServiceUserViewModel);
                response.ResponseCode = isNullOrDef ? BusinessResponseValues.NullEntityValue : 1;
                response.RCode = resp.RCode;
                response.ResponseMessage = resp.ResponseMessage;
                if(!isNullOrDef)
                    response.Data = SimpleMapper.Map<ServiceUserViewModel, ServiceUserDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ServiceUserDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceUserDto, ServiceUserViewModel>(dto);
                response = iServiceUserBusiness.Update(model);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ServiceUserDto dto)
        {
            var response = new SimpleResponse();

            try
            {
                var model = SimpleMapper.Map<ServiceUserDto, ServiceUserViewModel>(dto);
                response = iServiceUserBusiness.Delete(model);
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
                response =  iServiceUserBusiness.Delete(id);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ServiceUserDto>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceUserDto>>();

            try
            {
                var resp = iServiceUserBusiness.ReadAll();

                response.ResponseCode = resp.ResponseCode;
                response.ResponseMessage = resp.ResponseMessage;
                response.RCode = resp.RCode;
                response.Data = SimpleMapper.MapList<ServiceUserViewModel, ServiceUserDto>(resp.Data);
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data = response.Data ?? new List<ServiceUserDto>();
            return response;
        }
    }
}