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

    public class ServiceController : ApiController
    {
        private IServiceBusiness iServiceBusiness;

        public ServiceController(IServiceBusiness iServiceBusiness)
        {
            this.iServiceBusiness = iServiceBusiness;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(ServiceViewModel model)
        {
            var response = new SimpleResponse<ServiceViewModel>();
            response = iServiceBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int id)
        {
            var modelResult = iServiceBusiness.Read(id);
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(ServiceViewModel model)
        {
            var response = new SimpleResponse();
            response = iServiceBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            var result = iServiceBusiness.Delete(id);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iServiceBusiness.ReadAll();
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }
    }
}