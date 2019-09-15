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
    public class CountriesController : ControllerBase
    {
        private ICountryService _service;

        public CountriesController(ICountryService service)
        {
            _service = service;
        }

        // GET: api/Countries
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _service.Get();
        }

        // GET: api/Countries/5
        [HttpGet("{id}", Name = "GetCountry")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Countries
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Countries/5
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
