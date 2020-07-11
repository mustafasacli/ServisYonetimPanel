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

    public class ServiceDetailBusiness : IServiceDetailBusiness
    {
        public ServiceDetailBusiness()
        {
        }

        public SimpleResponse<ServiceDetailViewModel> Create(ServiceDetailViewModel model)
        {
            var response = new SimpleResponse<ServiceDetailViewModel>();

            try
            {
                var validation = model.Validate();
                if (validation.HasError)
                {
                    return new SimpleResponse<ServiceDetailViewModel>
                    {
                        Data = model,
                        ResponseCode = BusinessResponseValues.ValidationErrorResult,
                        ResponseMessage = validation.AllValidationMessages
                    };
                }

                using(var context = new SypDbContext())
                {
                    var entity = SimpleMapper.Map<ServiceDetailViewModel, ServiceDetail>(model);
                    context.ServiceDetail.Add(entity);
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

        public SimpleResponse<ServiceDetailViewModel> Read(int id)
        {
            var response = new SimpleResponse<ServiceDetailViewModel>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceDetail
                        .AsNoTracking()
                        .FirstOrDefault(q =>  q.Id == id);

                    if (entity == null || entity == default(ServiceDetail))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    response.Data = SimpleMapper.Map<ServiceDetail,ServiceDetailViewModel>(entity);
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

        public SimpleResponse Update(ServiceDetailViewModel model)
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
                    var entity = context.ServiceDetail.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(ServiceDetail))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    SimpleMapper.MapTo(model, entity);
                    context.ServiceDetail.Attach(entity);
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

        public SimpleResponse Delete(ServiceDetailViewModel model)
        {
            var response = new SimpleResponse();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entity = context.ServiceDetail.FirstOrDefault(q =>  q.Id == model.Id);
                    if (entity == null || entity == default(ServiceDetail))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.ServiceDetail.Remove(entity);
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
                    var entity = context.ServiceDetail.FirstOrDefault(q =>  q.Id == id);
                    if (entity == null || entity == default(ServiceDetail))
                    {
                        response.ResponseCode = BusinessResponseValues.NullEntityValue;
                        response.ResponseMessage = "Kayıt bulunamadı.";
                        return response;
                    }

                    context.ServiceDetail.Remove(entity);
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

        public SimpleResponse<List<ServiceDetailViewModel>> ReadAll()
        {
            var response = new SimpleResponse<List<ServiceDetailViewModel>>();

            try
            {
                using (var context = new SypDbContext())
                {
                    var entities = context.ServiceDetail
                        .AsNoTracking()
                        .ToList() ?? new List<ServiceDetail>();

                    response.Data = SimpleMapper.MapList<ServiceDetail, ServiceDetailViewModel>(entities);
                    response.ResponseCode = response.Data.Count;
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = BusinessResponseValues.InternalError;
                response.ResponseMessage = "Okuma işleminde hata oluştu.";
                SimpleFileLogger.Instance.Error(ex);
            }

            response.Data =  response.Data ?? new List<ServiceDetailViewModel>();
            return response;
        }
    }
}