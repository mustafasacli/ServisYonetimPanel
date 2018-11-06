namespace ServisYonetimPanel.Business
{
    using Dexter.Extensions;
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;
    using ServisYonetimPanel.Models.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServicePocoBusiness : BaseBusiness, IServicePocoBusiness
    {
        public ServicePocoBusiness() : base()
        {
        }

        public ServiceResponse<object> Add(ServicePocoModel poco)
        {
            var response = new ServiceResponse<object>() { ResponseCode = -1 };

            try
            {
                var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntity>(poco);

                var o = InternalAdd(entity);
                response.ResponseData = o;
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
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
                var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntity>(poco);

                var o = InternalUpdate(entity);
                response.ResponseData = (o as bool?).GetValueOrDefault();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
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
                //var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntity>(poco);

                var o = InternalDelete<ServiceEntity>(id);
                response.ResponseData = (o as bool?).GetValueOrDefault();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
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
                var entList = InternalGetList<ServiceEntity>();
                var modelList = entList.AsEnumerable().Select(s => GeneralMapperExtensions.Map<ServiceEntity, ServicePocoModel>(s)).ToList();

                response.ResponseData = (modelList ?? new List<ServicePocoModel> { }).AsEnumerable();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
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
                var o = InternalGet<ServiceEntity>(id);
                var result = GeneralMapperExtensions.Map<ServiceEntity, ServicePocoModel>(o);
                response.ResponseData = result ?? new ServicePocoModel { };
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }
    }
}