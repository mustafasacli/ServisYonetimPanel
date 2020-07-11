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

    public class ServiceBusiness : IServiceBusiness
    {
        public ServiceBusiness()
        {
        }

        public SimpleResponse<ServiceViewModel> Create(ServiceViewModel model)
        {
            var response = new SimpleResponse<ServiceViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<ServiceViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using(var context = new SypDbContext())
                {
                    var entity = SimpleMapper.Map<ServiceViewModel, Service>(model);
                    context.Service.Add(entity);
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

        public SimpleResponse<ServiceViewModel> Read(int id)
        {
            var response = new SimpleResponse<ServiceViewModel>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.Service
                        .AsNoTracking()
                        .FirstOrDefault(q =>  q.Id == id);

                    if (entity == null || entity == default(Service))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    response.Data = SimpleMapper.Map<Service,ServiceViewModel>(entity);
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

        public SimpleResponse Update(ServiceViewModel model)
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
                    var entity = context.Service.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(Service))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    SimpleMapper.MapTo(model, entity);
                    context.Service.Attach(entity);
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

        public SimpleResponse Delete(ServiceViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.Service.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(Service))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.Service.Remove(entity);
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
                    var entity = context.Service.FirstOrDefault(q =>  q.Id == id);
                    if (entity == null || entity == default(Service))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.Service.Remove(entity);
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

        public SimpleResponse<List<ServiceViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceViewModel>>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entities = context.Service
                        .AsNoTracking()
                        .ToList() ?? new List<Service>();

                    response.Data = SimpleMapper.MapList<Service, ServiceViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data =  response.Data ?? new List<ServiceViewModel>();
            return response;
        }
    }
}