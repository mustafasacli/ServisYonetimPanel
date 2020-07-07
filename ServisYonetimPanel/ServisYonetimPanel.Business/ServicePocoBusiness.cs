namespace ServisYonetimPanel.Business
{
    using Dexter.Extensions;
    using ServisYonetimPanel.Command;
    using ServisYonetimPanel.Common.Response;
    using Mst.Dexter.Extensions;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Models.Model;
    using SimpleFileLogging;
    using SimpleFileLogging.Enums;
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Net.FreeORM.EFValidation;

    public class ServicePocoBusiness : BaseBusiness, IServicePocoBusiness
    {
        private static object lockObj = new object();

        public ServicePocoBusiness()
        {
            SimpleFileLogger.Instance.LogDateFormatType = SimpleLogDateFormats.Hour;
        }

        public ServiceResponse<object> Add(ServicePocoModel poco)
        {
            var response = new ServiceResponse<object>() { ResponseCode = -1 };

            try
            {
                var validationResult = poco.Validate();
                if (validationResult.HasError)
                {
                    response.ResponseMessage = validationResult.ErrorMessage;
                    response.ResponseCode = -1002;
                    response.ResponseData = false;
                }

                Database.OpenConnection();
                var existCount = Database
                    .ExecuteScalar("select count(1) from serviceentity where name = @name and isactive = 1;",
                    inputArgs: new Dictionary<string, object> { { "@name", poco.Name } })
                    .ToInt();
                Database.CloseConnection();

                if (existCount > 0)
                {
                    response.ResponseData = -1001;
                    response.ResponseCode = -1001;
                    response.ResponseMessage = "Data with given name is already exist.";
                    return response;
                }

                var entity = GeneralMapperExtensions.Map<ServicePocoModel, ServiceEntityInsertCommand>(poco);

                lock (lockObj)
                {
                    entity.CreatedOn = DateTime.Now;
                    entity.MasterKey = entity.CreatedOn.Ticks.ToString("X");
                }

                entity.CreatedBy = 1;
                entity.IsActive = true;

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
                var validationResult = poco.Validate();
                if (validationResult.HasError)
                {
                    response.ResponseMessage = validationResult.ErrorMessage;
                    response.ResponseCode = -1002;
                    response.ResponseData = false;
                }

                var existCount = Database.ExecuteScalar("select count(1) from serviceentity where name = @name and isactive = 1 and id <> @id;",
                    inputArgs: new Dictionary<string, object> { { "@name", poco.Name }, { "@id", poco.Id } }).ToInt();

                if (existCount > 0)
                {
                    response.ResponseData = false;
                    response.ResponseCode = -1001;
                    response.ResponseMessage = "Record is not active.";
                    return response;
                }

                var entity = InternalGet<ServiceEntityUpdateCommand>(poco.Id);

                if (!entity.IsActive)
                {
                    response.ResponseCode = -1002;
                    return response;
                }

                if (!string.Equals(entity.Name, poco.Name))
                {
                    entity.Name = poco.Name;
                    entity.UpdatedOn = DateTime.Now;
                    entity.UpdatedBy = 1;

                var o = InternalUpdate(entity);
                response.ResponseData = (o as bool?).GetValueOrDefault();
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
                var cmd = new ServiceEntityDeleteCommand
                { Id = id.ToInt(), UpdatedOn = DateTime.Now, UpdatedBy = 1, IsActive = false };

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

                var modelList = entList.AsEnumerable().Select(s =>
                GeneralMapperExtensions.Map<ServiceGetCommand, ServicePocoModel>(s)).ToList();

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
                response.ResponseData = result ?? new ServicePocoModel { };
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