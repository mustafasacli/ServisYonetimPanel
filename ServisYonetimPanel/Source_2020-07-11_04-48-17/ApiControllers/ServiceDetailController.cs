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

    public class ServiceDetailController : ApiController
    {
        private IServiceDetailBusiness iServiceDetailBusiness;

        public ServiceDetailController(IServiceDetailBusiness iServiceDetailBusiness)
        {
            this.iServiceDetailBusiness = iServiceDetailBusiness;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(ServiceDetailViewModel model)
        {
            var response = new SimpleResponse<ServiceDetailViewModel>();
            response = iServiceDetailBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int id)
        {
            var modelResult = iServiceDetailBusiness.Read(id);
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(ServiceDetailViewModel model)
        {
            var response = new SimpleResponse();
            response = iServiceDetailBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            var result = iServiceDetailBusiness.Delete(id);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iServiceDetailBusiness.ReadAll();
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }
    }
}