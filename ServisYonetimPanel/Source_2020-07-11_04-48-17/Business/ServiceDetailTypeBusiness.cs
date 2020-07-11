namespace Syp.Business
{
    using SimpleInfra.Common.Core;
    using SimpleFileLogging;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Mapping;
    using SimpleInfra.Validation;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using Syp.ViewModel;
    using Syp.Entity;
    using Syp.Business.Interfaces;
    using Syp.Context;

    public class ServiceDetailTypeBusiness : IServiceDetailTypeBusiness
    {
        public ServiceDetailTypeBusiness()
        {
        }

        public SimpleResponse<ServiceDetailTypeViewModel> Create(ServiceDetailTypeViewModel model)
        {
            var response = new SimpleResponse<ServiceDetailTypeViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<ServiceDetailTypeViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using(var context = new SypDbContext())
                {
                    var entity = SimpleMapper.Map<ServiceDetailTypeViewModel, ServiceDetailType>(model);
                    context.ServiceDetailType.Add(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Ekleme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<ServiceDetailTypeViewModel> Read(int id)
        {
            var response = new SimpleResponse<ServiceDetailTypeViewModel>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceDetailType
                        .AsNoTracking()
                        .FirstOrDefault(q =>  q.Id == id);

                    if (entity == null || entity == default(ServiceDetailType))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    response.Data = SimpleMapper.Map<ServiceDetailType,ServiceDetailTypeViewModel>(entity);
                    response.ResponseCode = 1;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Update(ServiceDetailTypeViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse
                    {
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceDetailType.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(ServiceDetailType))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    SimpleMapper.MapTo(model, entity);
                    context.ServiceDetailType.Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Güncelleme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse Delete(ServiceDetailTypeViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceDetailType.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(ServiceDetailType))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.ServiceDetailType.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
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
                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceDetailType.FirstOrDefault(q =>  q.Id == id);
                    if (entity == null || entity == default(ServiceDetailType))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.ServiceDetailType.Remove(entity);
                    response.ResponseCode = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Silme işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            return response;
        }

        public SimpleResponse<List<ServiceDetailTypeViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceDetailTypeViewModel>>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entities = context.ServiceDetailType
                        .AsNoTracking()
                        .ToList() ?? new List<ServiceDetailType>();

                    response.Data = SimpleMapper.MapList<ServiceDetailType, ServiceDetailTypeViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data =  response.Data ?? new List<ServiceDetailTypeViewModel>();
            return response;
        }
    }
}