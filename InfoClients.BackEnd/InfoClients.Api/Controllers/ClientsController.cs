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
    public class ClientsController : ControllerBase
    {
        private IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return _service.Get();
        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "GetClient")]
        public Client Get(int id)
        {
            return _service.Get(id);
        }

        // POST: api/Clients
        [HttpPost]
        public IActionResult Post([FromBody] Client value)
        {
            return Create(value);
            //var result = value;
        }


        private IActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _service.Add(client);
            if (result.ClientId != 0)
                return Ok(result);
            else return BadRequest();
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
