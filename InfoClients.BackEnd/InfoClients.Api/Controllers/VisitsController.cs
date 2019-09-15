using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoClients.Model;
using InfoClients.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoClients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private IVisitService _service;

        public VisitsController(IVisitService service)
        {
            _service = service;
        }

        // GET: api/Visits
        [HttpGet]
        public IEnumerable<Visit> Get()
        {
            return _service.Get();
        }

        // GET: api/Visits/5
        [HttpGet("{id}", Name = "GetVisit")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Visits
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Visits/5
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
