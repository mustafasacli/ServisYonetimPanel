namespace ServisYonetimPanel.Core.Web.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        protected IServicePocoBusiness servicePocoBusiness;

        public ServiceController(IServicePocoBusiness servicePocoBusiness)
        {
            this.servicePocoBusiness = servicePocoBusiness;
        }

        // GET: api/Service
        [HttpGet]
        public IEnumerable<ServicePoco> GetList()
        {
            var result = servicePocoBusiness.GetServicePocos();
            //return new List<ServicePoco> { }.AsEnumerable();
            //return new string[] { "value1", "value2" };
            return result.ResponseData;
        }

        // GET: api/Service/5
        [HttpGet("{id}", Name = "Get")]
        public ServicePoco Get(Guid id)
        {
            var result = servicePocoBusiness.Get(id);
            //return new ServicePoco { };
            //return "value";
            return result.ResponseData;
        }

        // POST: api/Service
        [HttpPost]
        public Guid Post([FromBody] ServicePoco poco)
        {
            var result = Guid.Empty;

            //method body
            var response = servicePocoBusiness.Add(poco);
            result = response.ResponseData;

            return result;
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] ServicePoco poco)
        {
            var result = false;

            //method body
            var response = servicePocoBusiness.Update(poco);
            result = response.ResponseData;

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var result = false;

            //method body
            var response = servicePocoBusiness.Delete(id);
            result = response.ResponseData;


            return result;
        }
    }
}
