namespace ServisYonetimPanel.Business
{
    using Mst.Dexter.Extensions;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;
    using ServisYonetimPanel.Models.Model;
    using SimpleFileLogging;
    using SimpleFileLogging.Enums;
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServicePocoBusiness : BaseBusiness, IServicePocoBusiness
    {
        public ServicePocoBusiness() : base()
        {
            SimpleFileLogger.Instance.LogDateFormatType = SimpleLogDateFormats.Hour;
        }

        public ServiceResponse<object> Add(ServicePocoModel poco)
        {
            var response = new ServiceResponse<object>() { ResponseCode = -1 };

            try
            {
                var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntityInsertCommand>(poco);

                entity.CreatedOn = DateTime.Now;
                entity.CreatedBy = 1;

                var o = InternalAdd(entity);
                response.Data = o;
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                SimpleFileLogger.Instance.Error(e);
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<bool> Update(ServicePocoModel poco)
        {
            var response = new ServiceResponse<bool>() { ResponseCode = -1 };

            try
            {
                var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntityUpdateCommand>(poco);

                entity.UpdatedOn = DateTime.Now;
                entity.UpdatedBy = 1;

                var o = InternalUpdate(entity);
                response.Data = (o as bool?).GetValueOrDefault();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                SimpleFileLogger.Instance.Error(e);
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<bool> Delete(object id)
        {
            var response = new ServiceResponse<bool>() { ResponseCode = -1 };

            try
            {
                var cmd = new ServiceEntityDeleteCommand { GId = (Guid)id, UpdatedBy = 1, IsActive = false };
                cmd.UpdatedOn = DateTime.Now;

                var o = InternalUpdate(cmd);
                response.Data = (o as bool?).GetValueOrDefault();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                SimpleFileLogger.Instance.Error(e);
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<IEnumerable<ServicePocoModel>> GetServicePocos()
        {
            var response = new ServiceResponse<IEnumerable<ServicePocoModel>>() { ResponseCode = -1 };

            try
            {
                var entList = InternalGetList<ServiceGetCommand>();
                var modelList = entList.AsEnumerable().Select(s => GeneralMapperExtensions.Map<ServiceGetCommand, ServicePocoModel>(s)).ToList();

                response.Data = (modelList ?? new List<ServicePocoModel> { }).AsEnumerable();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                SimpleFileLogger.Instance.Error(e);
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<ServicePocoModel> Get(object id)
        {
            var response = new ServiceResponse<ServicePocoModel>() { ResponseCode = -1 };

            try
            {
                var o = InternalGet<ServiceGetCommand>(id);
                var result = GeneralMapperExtensions.Map<ServiceGetCommand, ServicePocoModel>(o);
                response.Data = result ?? new ServicePocoModel { };
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                SimpleFileLogger.Instance.Error(e);
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }
    }
}