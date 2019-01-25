using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServisYonetimPanel.Contracts.BusinessContract;
using ServisYonetimPanel.Models.Model;
using System.Collections.Generic;

namespace ServisYonetimPanel.Core.Web.API.Controllers
{
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
        public ActionResult<IEnumerable<ServicePocoModel>> GetList()
        {
            var result = servicePocoBusiness.GetServicePocos();

            return Ok(result.ResponseData);
        }

        // GET: api/Service/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<ServicePocoModel> Get(object id)
        {
            var result = servicePocoBusiness.Get(id);
            //return new ServicePoco { };
            //return "value";
            return result.ResponseData;
        }

        // POST: api/Service
        [HttpPost]
        public ActionResult<object> Post([FromQuery] string name)//JObject jsonData)//ServicePocoModel poco)
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