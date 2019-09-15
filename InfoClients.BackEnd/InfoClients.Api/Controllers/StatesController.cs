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
    public class StatesController : ControllerBase
    {
        private IStateService _service;

        public StatesController(IStateService service)
        {
            _service = service;
        }

        // GET: api/States
        [HttpGet]
        public IEnumerable<State> Get()
        {
            return _service.Get();
        }

        // GET: api/States/5
        [HttpGet("{id}", Name = "GetState")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetStateByCountry/{id}")]        
        public IEnumerable<State> GetByCountry(int id)
        {
            return _service.GetByCountry(id);
        }

        // POST: api/States
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/States/5
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
