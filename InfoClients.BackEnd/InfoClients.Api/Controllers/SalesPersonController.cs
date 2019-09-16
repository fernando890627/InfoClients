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
    public class SalesPersonController : ControllerBase
    {
        private ISalePersonService _service;

        public SalesPersonController(ISalePersonService service)
        {
            _service = service;
        }
        // GET: api/SalesPerson
        [HttpGet]
        public IEnumerable<SalePerson> Get()
        {
            return _service.Get();
        }

        // GET: api/SalesPerson/5
        [HttpGet("{id}", Name = "GetSalePerson")]
        public SalePerson Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST: api/SalesPerson
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/SalesPerson/5
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
