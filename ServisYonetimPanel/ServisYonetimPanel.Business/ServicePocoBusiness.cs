namespace ServisYonetimPanel.Business
{
    using Dexter.Extensions;
    using ServisYonetimPanel.Command;
    using ServisYonetimPanel.Common.Response;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Models.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ServicePocoBusiness : BaseBusiness, IServicePocoBusiness
    {
        private static object lockObj = new object();

        public ServicePocoBusiness()
        {
        }

        public ServiceResponse<object> Add(ServicePocoModel poco)
        {
            var response = new ServiceResponse<object>() { ResponseCode = -1 };

            try
            {
                var existCount = rcDb.ExecuteScalar("select count(1) from serviceentity where name = @name and isactive = true;",
                    inputArgs: new Dictionary<string, object> { { "@name", poco.Name } }).ToInt();

                if (existCount > 0)
                {
                    response.ResponseCode = -1001;
                    response.ResponseMessage = "Data with given name is already exist.";
                    return response;
                }

                var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntityInsertCommand>(poco);

                lock (lockObj)
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.CreatedBy = 1;
                    entity.MasterKey = entity.CreatedOn.Ticks.ToString("X");
                }

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
                var existCount = rcDb.ExecuteScalar("select count(1) from serviceentity where name = @name and isactive = true and id <> @id;",
                    inputArgs: new Dictionary<string, object> { { "@name", poco.Name }, { "@id", poco.Id } }).ToInt();

                if (existCount > 0)
                {
                    response.ResponseCode = -1001;
                    response.ResponseMessage = "Data with given name is already exist.";
                    return response;
                }

                var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntityUpdateCommand>(poco);

                entity.UpdatedOn = DateTime.Now;
                entity.UpdatedBy = 1;

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
                var cmd = new ServiceEntityDeleteCommand
                { Id = id.ToInt(), UpdatedOn = DateTime.Now, UpdatedBy = 1, IsActive = false };

                var o = InternalUpdate(cmd);
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
                var entList = InternalGetList<ServiceGetCommand>();

                var modelList = entList.AsEnumerable().Select(s =>
                GeneralMapperExtensions.Map<ServiceGetCommand, ServicePocoModel>(s)).ToList();

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
                var o = InternalGet<ServiceGetCommand>(id);
                var result = GeneralMapperExtensions.Map<ServiceGetCommand, ServicePocoModel>(o);

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