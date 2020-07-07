namespace ServisYonetimPanel.Core.Web.UI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Entity;
    using ServisYonetimPanel.Models.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseApiController
    {
        protected IServicePocoBusiness servicePocoBusiness;

        public ServiceController(
            IServicePocoBusiness servicePocoBusiness, IHttpContextAccessor accessor)
            : base(accessor)
        {
            this.servicePocoBusiness = servicePocoBusiness;
        }

        // GET: api/Service
        [HttpGet]
        public IEnumerable<ServicePocoModel> GetList()
        {
            var result = servicePocoBusiness.GetServicePocos();
            // return new List<ServicePoco> { }.AsEnumerable();
            // return new string[] { "value1", "value2" };

            return result.ResponseData;
        }

        // GET: api/Service/5
        [HttpGet("{id}", Name = "Get")]
        public ServicePocoModel Get(object id)
        {
            var result = servicePocoBusiness.Get(id);
            //return new ServicePoco { };
            //return "value";
            return result.ResponseData;
        }

        // POST: api/Service
        [HttpPost]
        public object Post([FromBody] string name)//JObject jsonData)//ServicePocoModel poco)
        {
            var result = new object();
            // var poco = JsonConvert.DeserializeObject<ServicePocoModel>(jsonData.ToString());
            var poco = new ServicePocoModel { Name = name };
            //method body
            var response = servicePocoBusiness.Add(poco);
            result = response.ResponseData;

            return result;
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public bool Put(object id, [FromBody] ServicePocoModel poco)
        {
            var result = false;

            //method body
            var response = servicePocoBusiness.Update(poco);
            result = response.ResponseData;

            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
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
