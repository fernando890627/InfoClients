using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoClients.Model;
using InfoClients.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoClients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CitiesController : ControllerBase
    {

        private ICityService _service;

        public CitiesController(ICityService service)
        {
            _service = service;
        }

        // GET: api/Cities
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return _service.Get();
        }

        // GET: api/Cities/5
        [HttpGet("{id}", Name = "GetCity")]
        public string Get(int id)
        {
            return "value";
        }

        //[HttpGet("{id}", Name = "GetCityByState")]
        [HttpGet("GetCityByState/{id}")]        
        public IQueryable<City> GetBySatate(int id)
        {
            return _service.GetByState(id);
        }
        
        // POST: api/Cities
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
