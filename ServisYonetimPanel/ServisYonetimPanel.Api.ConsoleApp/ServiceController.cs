namespace ServisYonetimPanel.Api.ConsoleApp
{
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;
    using ServisYonetimPanel.Models.Model;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    [Route("api/[controller]")]
    public class ServiceController : BaseApiController
    {
        protected IServicePocoBusiness servicePocoBusiness;

        public ServiceController(IServicePocoBusiness servicePocoBusiness)
        {
            this.servicePocoBusiness = servicePocoBusiness;
        }

        // GET: api/Service
        [HttpGet]
        public IEnumerable<ServicePocoModel> GetList()
        {
            var result = servicePocoBusiness.GetServicePocos();
            //return new List<ServicePoco> { }.AsEnumerable();
            //return new string[] { "value1", "value2" };
            return result.ResponseData;
        }

        // GET: api/Service/5
        [HttpGet]
        public ServicePocoModel Get(object id)
        {
            var result = servicePocoBusiness.Get(id);
            //return new ServicePoco { };
            //return "value";
            return result.ResponseData;
        }

        // POST: api/Service
        [HttpPost]
        public object Post([FromBody] ServicePocoModel poco)
        {
            var result = new object();

            //method body
            var response = servicePocoBusiness.Add(poco);
            result = response.ResponseData;

            return result;
        }

        // PUT: api/Service/5
        [HttpPut]
        public bool Put(object id, [FromBody] ServicePocoModel poco)
        {
            var result = false;

            //method body
            var response = servicePocoBusiness.Update(poco);
            result = response.ResponseData;

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public bool Delete(object id)
        {
            var result = false;

            //method body
            var response = servicePocoBusiness.Delete(id);
            result = response.ResponseData;

            return result;
        }
    }
}