namespace ServisYonetimPanel.Business.Generic
{
    using Mst.Dexter.Extensions;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Data;
    using ServisYonetimPanel.Entity;
    using ServisYonetimPanel.Models.Model;
    using SimpleFileLogging;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Validation;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///
    /// </summary>
    public class ServiceDetailTypeBusiness : BaseGenericBusiness, IServiceDetailTypeBusiness
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceDetailTypeModel"></param>
        /// <returns></returns>
        public ServiceResponse<long> Add(ServiceDetailTypeModel serviceDetailTypeModel)
        {
            if (serviceDetailTypeModel == null)
            {
                return new ServiceResponse<long>
                {
                    ResponseCode = -1000,
                    ResponseMessage = "Model is null"
                };
            }

            if (serviceDetailTypeModel == default(ServiceDetailTypeModel))
            {
                return new ServiceResponse<long>
                {
                    ResponseCode = -1001,
                    ResponseMessage = "Model is default"
                };
            }

            var response = new ServiceResponse<long>()
            {
                Data = -1
            };

            try
            {
                var validationResult = serviceDetailTypeModel.Validate();

                if (validationResult.HasError)
                {
                    var message = GetValidationErrors(validationResult);
                    return new ServiceResponse<long>
                    {
                        ResponseCode = -2000,
                        ResponseMessage = message
                    };
                }

                var entity = GeneralMapperExtensions.Map<ServiceDetailTypeModel, ServiceDetailType>(serviceDetailTypeModel);
                entity.Id = 0;

                using (var repository = new ServisYonetimRepository<ServiceDetailType>())
                {
                    entity.DetailTypeName = entity.DetailTypeName.Trim();

                    if (repository.Any(q => q.DetailTypeName == entity.DetailTypeName && q.IsActive))
                    {
                        return new ServiceResponse<long>
                        {
                            ResponseCode = -3000,
                            ResponseMessage = "Entity is already exist with given name."
                        };
                    }

                    SetCreationValues(entity);
                    repository.Add(entity);
                    response.ResponseCode = repository.SaveChanges();
                    response.Data = entity.Id;
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
                SimpleFileLogger.Instance.Error(e);
            }

            return response;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceDetailTypeModelId"></param>
        /// <returns></returns>
        public ServiceResponse<int> Delete(int serviceDetailTypeModelId)
        {
            var response = new ServiceResponse<int>()
            {
                ResponseCode = -1,
                Data = -1
            };

            if (serviceDetailTypeModelId < 1)
            {
                response.ResponseCode = -1002;
                response.ResponseMessage = "id must be greater than 0.";
                return response;
            }

            try
            {
                using (var repository = new ServisYonetimRepository<ServiceDetailType>())
                {
                    if (repository.Any(q => q.Id == serviceDetailTypeModelId && q.IsActive))
                    {
                        return new ServiceResponse<int>
                        {
                            ResponseCode = -3000,
                            ResponseMessage = "Entity is not exist with given name."
                        };
                    }

                    var entity = repository.FirstOrDefault(q => q.Id == serviceDetailTypeModelId);
                    SetUpdateValues(entity, isDelete: true);
                    response.ResponseCode = repository.SaveChanges();
                    response.Data = response.ResponseCode;
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
                SimpleFileLogger.Instance.Error(e);
            }

            return response;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ServiceResponse<IEnumerable<ServiceDetailTypeModel>> GetAll()
        {
            var response = new ServiceResponse<IEnumerable<ServiceDetailTypeModel>>();

            try
            {
                using (var repository = new ServisYonetimRepository<ServiceDetailType>())
                {
                    var data = repository.GetAll(q => q.IsActive, asNoTracking: true)
                      .Select(q => new ServiceDetailTypeModel { })
                      .AsEnumerable();

                    response.Data = data;
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
                SimpleFileLogger.Instance.Error(e);
            }

            return response;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceResponse<ServiceDetailTypeModel> GetById(long id)
        {
            var response = new ServiceResponse<ServiceDetailTypeModel>();

            if (id < 1)
            {
                response.ResponseCode = -1002;
                response.ResponseMessage = "id must be greater than 0.";
                return response;
            }

            try
            {
                using (var repository = new ServisYonetimRepository<ServiceDetailType>())
                {
                    var data = repository.GetAll(q => q.Id == id && q.IsActive, asNoTracking: true)
                      .Select(q => new ServiceDetailTypeModel
                      {
                          Id = q.Id,
                          DetailTypeName = q.DetailTypeName
                      })
                      .FirstOrDefault();

                    response.Data = data;
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
                SimpleFileLogger.Instance.Error(e);
            }

            return response;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceDetailTypeModel"></param>
        /// <returns></returns>
        public ServiceResponse<int> Update(ServiceDetailTypeModel serviceDetailTypeModel)
        {
            if (serviceDetailTypeModel == null)
            {
                return new ServiceResponse<int>
                {
                    ResponseCode = -1000,
                    ResponseMessage = "Model is null"
                };
            }

            if (serviceDetailTypeModel == default(ServiceDetailTypeModel))
            {
                return new ServiceResponse<int>
                {
                    ResponseCode = -1001,
                    ResponseMessage = "Model is default"
                };
            }

            var response = new ServiceResponse<int>()
            {
                Data = -1
            };

            try
            {
                var validationResult = serviceDetailTypeModel.Validate();

                if (validationResult.HasError)
                {
                    var message = GetValidationErrors(validationResult);
                    return new ServiceResponse<int>
                    {
                        ResponseCode = -2000,
                        ResponseMessage = message
                    };
                }

                var entity = GeneralMapperExtensions.Map<ServiceDetailTypeModel, ServiceDetailType>(serviceDetailTypeModel);

                if (entity.Id < 1)
                {
                    return new ServiceResponse<int>
                    {
                        ResponseCode = -3000,
                        ResponseMessage = "Entity Id is invalid."
                    };
                }

                using (var repository = new ServisYonetimRepository<ServiceDetailType>())
                {
                    entity.DetailTypeName = entity.DetailTypeName.Trim();

                    if (repository.Any(q => q.Id != entity.Id && q.DetailTypeName == entity.DetailTypeName && q.IsActive))
                    {
                        return new ServiceResponse<int>
                        {
                            ResponseCode = -3000,
                            ResponseMessage = "Entity is already exist with given name."
                        };
                    }
                    var e = repository.FirstOrDefault(q => q.Id == entity.Id && q.IsActive);

                    if (e == null || e == default(ServiceDetailType))
                    {
                        return new ServiceResponse<int>
                        {
                            ResponseCode = -3001,
                            ResponseMessage = "Entity is not active."
                        };
                    }

                    serviceDetailTypeModel.MapTo(e);

                    SetUpdateValues(e);
                    repository.Update(e);
                    response.ResponseCode = repository.SaveChanges();
                }
            }
            catch (Exception e)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = e.Message;
                SimpleFileLogger.Instance.Error(e);
            }

            return response;
        }
    }
}