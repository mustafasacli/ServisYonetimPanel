namespace ServisYonetimPanel.Api.ConsoleApp
{
    using ServisYonetimPanel.Business;
    using ServisYonetimPanel.Contracts.BusinessContract;
    using ServisYonetimPanel.Models.Model;
    using System.Web.Http;

    [RoutePrefix("service")]
    public class ServiceController : BaseApiController
    {
        protected IServicePocoBusiness servicePocoBusiness;

        public ServiceController()
        {
            this.servicePocoBusiness = new ServicePocoBusiness();
        }

        [HttpGet]
        [Route("GetList")]
        //[AcceptVerbs("GET")]
        public IHttpActionResult GetList()
        {
            var result = servicePocoBusiness.GetServicePocos();

            return Json(result);//result.ResponseData;
        }

        // GET: api/Service/5
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(long? id)
        {
            var result = servicePocoBusiness.Get(id);

            return Json(result);
        }

        // POST: api/Service
        [HttpPost]
        [Route(Name = "Post")]
        public IHttpActionResult Post([FromUri] string name)//ServicePocoModel poco)
        {
            //method body
            var poco = new ServicePocoModel { Name = name };
            var response = servicePocoBusiness.Add(poco);
            //var result = response.ResponseData;

            return Json(response);//return result;
        }

        // PUT: api/Service/5
        [HttpPut]
        [Route(Name = "Put")]
        public IHttpActionResult Put(object id, [FromBody] ServicePocoModel poco)
        {
            var result = false;

            //method body
            var response = servicePocoBusiness.Update(poco);
            //result = response.ResponseData;

            return Json(result);//result;
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(long? id)
        {
            //var result = false;

            //method body
            var response = servicePocoBusiness.Delete(id);
            //result = response.ResponseData;

            return Json(response);//result;
        }
    }
}