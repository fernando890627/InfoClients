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

        [HttpGet("GetByClient/{id}")]
        public IEnumerable<Visit> GetByClient(int id)
        {
            return _service.GetByClient(id);
        }

        [HttpGet("GetByCity/{id}")]
        public IEnumerable<Visit> GetByCity(int id)
        {
            try
            {
                var test= _service.GetByCity(id);
                return test;
            }
            catch (Exception ex)
            {                
                string e = ex.Message;
                return new List<Visit>();
            }
            
        }

        // POST: api/Visits
        [HttpPost]
        public IActionResult Post([FromBody] Visit value)
        {
            return Create(value);
        }

        private IActionResult Create(Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _service.Add(visit);
            if (result.ClientId != 0)
                return Ok(result);
            else return BadRequest();
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
