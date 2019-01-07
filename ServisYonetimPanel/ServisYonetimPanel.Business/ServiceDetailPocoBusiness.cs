using Dexter.Extensions;
using ServisYonetimPanel.Command;
using ServisYonetimPanel.Common.Response;
using ServisYonetimPanel.Contracts.BusinessContract;
using ServisYonetimPanel.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServisYonetimPanel.Business
{
    public class ServiceDetailPocoBusiness : BaseBusiness, IServiceDetailPocoBusiness
    {
        public ServiceDetailPocoBusiness()
        {
        }

        public ServiceResponse<object> Add(ServiceDetailPocoModel poco)
        {
            var response = new ServiceResponse<object>() { ResponseCode = -1 };

            try
            {
                var existCount = rcDb.ExecuteScalar("select count(1) from servicedetailentity where detailkey = @name and isactive = true and masterid = @masterid;",
                    inputArgs: new Dictionary<string, object> { { "@name", poco.DetailKey }, { "@masterid", poco.MasterId } }).ToInt();

                if (existCount > 0)
                {
                    response.ResponseCode = -1001;
                    response.ResponseMessage = "Data with given name is already exist.";
                    return response;
                }

                var entity = GeneralMapperExtensions.Map<ServiceDetailPocoModel, ServiceDetailEntityInsertCommand>(poco);

                entity.CreatedOn = DateTime.Now;
                entity.CreatedBy = 1;

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

        public ServiceResponse<bool> Update(ServiceDetailPocoModel poco)
        {
            var response = new ServiceResponse<bool>() { ResponseCode = -1 };

            try
            {
                var existCount = rcDb.ExecuteScalar("select count(1) from servicedetailentity where detailkey = @name and isactive = true and masterid = @masterid and id <> @id;",
                    inputArgs: new Dictionary<string, object> { { "@name", poco.DetailKey }, { "@masterid", poco.MasterId }, { "@id", poco.Id } }).ToInt();

                if (existCount > 0)
                {
                    response.ResponseCode = -1001;
                    response.ResponseMessage = "Data with given name is already exist.";
                    return response;
                }

                var entity = GeneralMapperExtensions.Map<ServiceDetailPocoModel, ServiceDetailEntityUpdateCommand>(poco);

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

        public ServiceResponse<bool> Delete(long id)
        {
            var response = new ServiceResponse<bool>() { ResponseCode = -1 };

            try
            {
                var cmd = new ServiceEntityDeleteCommand
                { Id = id, UpdatedOn = DateTime.Now, UpdatedBy = 1, IsActive = false };

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

        public ServiceResponse<IEnumerable<ServiceDetailPocoModel>> GetServiceDetailPocos(long masterId)
        {
            var response = new ServiceResponse<IEnumerable<ServiceDetailPocoModel>>() { ResponseCode = -1 };

            try
            {
                var entList = InternalGetListWithParam<ServiceGetCommand>("select * from servicedetailentity where masterid = @masterid and isactive = true;",
                    inputs: new Dictionary<string, object> { { "@masterid", masterId } });

                var modelList = entList.AsEnumerable().Select(s =>
                GeneralMapperExtensions.Map<ServiceGetCommand, ServiceDetailPocoModel>(s)).ToList();

                response.ResponseData = (modelList ?? new List<ServiceDetailPocoModel> { }).AsEnumerable();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<IEnumerable<ServiceDetailPocoModel>> GetServiceDetailPocosBYMasterKey(string masterKey)
        {
            var response = new ServiceResponse<IEnumerable<ServiceDetailPocoModel>>() { ResponseCode = -1 };

            try
            {
                var entList = InternalGetListWithParam<ServiceGetCommand>("select sde.* from servicedetailentity sde inner join serviceentity se on sde.MasterId = se.Id where se.MasterKey = @masterkey and sde.isactive = true;",
                    inputs: new Dictionary<string, object> { { "@masterkey", masterKey } });

                var modelList = entList.AsEnumerable().Select(s =>
                GeneralMapperExtensions.Map<ServiceGetCommand, ServiceDetailPocoModel>(s)).ToList();

                response.ResponseData = (modelList ?? new List<ServiceDetailPocoModel> { }).AsEnumerable();
                response.ResponseCode = 1;
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
            }

            return response;
        }

        public ServiceResponse<ServiceDetailPocoModel> Get(object id)
        {
            var response = new ServiceResponse<ServiceDetailPocoModel>() { ResponseCode = -1 };

            try
            {
                var o = InternalGet<ServiceGetCommand>(id);
                var result = GeneralMapperExtensions.Map<ServiceGetCommand, ServiceDetailPocoModel>(o);
                response.ResponseData = result ?? new ServiceDetailPocoModel { };
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