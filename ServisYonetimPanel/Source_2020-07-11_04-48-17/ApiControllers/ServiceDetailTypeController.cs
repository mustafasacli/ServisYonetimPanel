namespace Syp.Web.Controllers
{
    using Syp.ViewModel;
    using Syp.Business.Interfaces;
    using Syp.Dtos;
    using SimpleInfra.Common.Response;
    using SimpleInfra.Validation;
    using SimpleInfra.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    public class ServiceDetailTypeController : ApiController
    {
        private IServiceDetailTypeBusiness iServiceDetailTypeBusiness;

        public ServiceDetailTypeController(IServiceDetailTypeBusiness iServiceDetailTypeBusiness)
        {
            this.iServiceDetailTypeBusiness = iServiceDetailTypeBusiness;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(ServiceDetailTypeViewModel model)
        {
            var response = new SimpleResponse<ServiceDetailTypeViewModel>();
            response = iServiceDetailTypeBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int id)
        {
            var modelResult = iServiceDetailTypeBusiness.Read(id);
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(ServiceDetailTypeViewModel model)
        {
            var response = new SimpleResponse();
            response = iServiceDetailTypeBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            var result = iServiceDetailTypeBusiness.Delete(id);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iServiceDetailTypeBusiness.ReadAll();
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }
    }
}