namespace Syp.Web.Controllers
{
    using Syp.Business.Interfaces;
    using Syp.Controllers;
    using Syp.ViewModel;
    using SimpleInfra.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Web.Mvc;

    public class ServiceController : Controller
    {
        private IServiceBusiness iServiceBusiness;

        public ServiceController(IServiceBusiness iServiceBusiness)
        {
            this.iServiceBusiness = iServiceBusiness ;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var response = iServiceBusiness.ReadAll();
            return View(response.Data);
        }

        public ActionResult Create()
        {
            var model = new ServiceViewModel();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult CreatePost(ServiceViewModel model)
        {
            var response = iServiceBusiness.Create(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Create", model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var response = iServiceBusiness.Read(id);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(response.Data);
        }

        public ActionResult Edit(int id)
        {
            var response = iServiceBusiness.Read(id);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Edit",  response.Data);
        }

        [HttpPost]
        public ActionResult UpdatePost(ServiceViewModel model)
        {
            var response = iServiceBusiness.Update(model);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return View("Edit", model);
            }
        }

        public ActionResult Delete(int id)
        {
            var response = iServiceBusiness.Read(id);

            if (response.Data == null || response.ResponseCode < 1)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View("Delete", response.Data); 
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var response = iServiceBusiness.Delete(id);

            if (response.ResponseCode > 0)
            { return RedirectToAction("Index"); }
            else
            {
                ModelState.AddModelError(string.Empty, response.ResponseMessage);
                return RedirectToAction("Delete", new { id });
            }
        }

        [HttpGet]
        public ActionResult ReadAll()
        {
            var response = iServiceBusiness.ReadAll();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}