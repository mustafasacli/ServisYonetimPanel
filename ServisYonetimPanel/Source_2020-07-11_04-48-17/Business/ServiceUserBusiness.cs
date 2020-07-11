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

    public class ServiceUserBusiness : IServiceUserBusiness
    {
        public ServiceUserBusiness()
        {
        }

        public SimpleResponse<ServiceUserViewModel> Create(ServiceUserViewModel model)
        {
            var response = new SimpleResponse<ServiceUserViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<ServiceUserViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using(var context = new SypDbContext())
                {
                    var entity = SimpleMapper.Map<ServiceUserViewModel, ServiceUser>(model);
                    context.ServiceUser.Add(entity);
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

        public SimpleResponse<ServiceUserViewModel> Read(int id)
        {
            var response = new SimpleResponse<ServiceUserViewModel>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceUser
                        .AsNoTracking()
                        .FirstOrDefault(q =>  q.Id == id);

                    if (entity == null || entity == default(ServiceUser))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    response.Data = SimpleMapper.Map<ServiceUser,ServiceUserViewModel>(entity);
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

        public SimpleResponse Update(ServiceUserViewModel model)
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
                    var entity = context.ServiceUser.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(ServiceUser))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    SimpleMapper.MapTo(model, entity);
                    context.ServiceUser.Attach(entity);
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

        public SimpleResponse Delete(ServiceUserViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceUser.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(ServiceUser))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.ServiceUser.Remove(entity);
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
                    var entity = context.ServiceUser.FirstOrDefault(q =>  q.Id == id);
                    if (entity == null || entity == default(ServiceUser))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.ServiceUser.Remove(entity);
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

        public SimpleResponse<List<ServiceUserViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceUserViewModel>>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entities = context.ServiceUser
                        .AsNoTracking()
                        .ToList() ?? new List<ServiceUser>();

                    response.Data = SimpleMapper.MapList<ServiceUser, ServiceUserViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data =  response.Data ?? new List<ServiceUserViewModel>();
            return response;
        }
    }
}