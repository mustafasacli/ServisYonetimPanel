namespace ServisYonetimPanel.Api.ConsoleApp
{
    using ServisYonetimPanel.Business;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;
    using ServisYonetimPanel.Models.Model;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Description;

    [RoutePrefix("service")]
    public class ServiceController : BaseApiController
    {
        protected IServicePocoBusiness servicePocoBusiness;

        public ServiceController()
        {
            this.servicePocoBusiness = new ServicePocoBusiness();
        }

        /*
         
        [ResponseType(typeof(List<ServiceDataVM>))]
        [AcceptVerbs("GET")]
        public IHttpActionResult
             */

        // GET: api/Service
        //[ResponseType(typeof(IEnumerable<ServicePocoModel>))]
        [HttpGet]
        [Route("GetList")]
        //[AcceptVerbs("GET")]
        public IHttpActionResult GetList()
        {
            var result = servicePocoBusiness.GetServicePocos();
            //return new List<ServicePoco> { }.AsEnumerable();
            //return new string[] { "value1", "value2" };
            return Json(result);//result.ResponseData;
        }

        // GET: api/Service/5
        //[AcceptVerbs("GET")]
        [HttpGet]
        //[ResponseType(typeof(ServicePocoModel))]
        [Route("Get")]
        public IHttpActionResult Get(object id)
        {
            var result = servicePocoBusiness.Get(id);
            //return new ServicePoco { };
            //return "value";
            return Json(result);//result.ResponseData;
        }

        // POST: api/Service
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post([FromBody] ServicePocoModel poco)
        {
            // var result = new object();

            //method body
            var response = servicePocoBusiness.Add(poco);
            //var result = response.ResponseData;

            return Json(response);//return result;
        }

        // PUT: api/Service/5
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put(object id, [FromBody] ServicePocoModel poco)
        {
            var result = false;

            //method body
            var response = servicePocoBusiness.Update(poco);
            //result = response.ResponseData;

            return Json(result);//result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(object id)
        {
            //var result = false;

            //method body
            var response = servicePocoBusiness.Delete(id);
            //result = response.ResponseData;

            return Json(response);//result;
        }
    }
}