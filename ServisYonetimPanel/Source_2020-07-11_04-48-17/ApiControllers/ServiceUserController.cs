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

    public class ServiceUserController : ApiController
    {
        private IServiceUserBusiness iServiceUserBusiness;

        public ServiceUserController(IServiceUserBusiness iServiceUserBusiness)
        {
            this.iServiceUserBusiness = iServiceUserBusiness;
        }

        [HttpPost]
        [Route("create")]
        public IHttpActionResult CreatePost(ServiceUserViewModel model)
        {
            var response = new SimpleResponse<ServiceUserViewModel>();
            response = iServiceUserBusiness.Create(model);
            return Json(response);
        }

        [HttpGet]
        [Route("detail")]
        public IHttpActionResult Detail(int id)
        {
            var modelResult = iServiceUserBusiness.Read(id);
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("update")]
        public IHttpActionResult UpdatePost(ServiceUserViewModel model)
        {
            var response = new SimpleResponse();
            response = iServiceUserBusiness.Update(model);
            return Json(response);
        }

        [HttpPost]
        [Route("delete")]
        public IHttpActionResult Delete(int id)
        {
            var result = iServiceUserBusiness.Delete(id);
            return Json(result);
        }

        [HttpGet]
        [Route("readall")]
        public IHttpActionResult ReadAll()
        {
            var modelResult = iServiceUserBusiness.ReadAll();
            return Json(modelResult, JsonRequestBehavior.AllowGet);
        }
    }
}