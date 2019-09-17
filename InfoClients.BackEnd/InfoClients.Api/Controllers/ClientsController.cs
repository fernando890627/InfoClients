using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoClients.Api.Utils;
using InfoClients.Model;
using InfoClients.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace InfoClients.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ClientsController : ControllerBase
    {
        private IClientService _service;
        ILogger logger = LogManager.GetCurrentClassLogger();
        public ClientsController(IClientService service)
        {
            _service = service;
        }

        // GET: api/Clients
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Client> lstClents = new List<Client>();
                foreach (var item in _service.Get())
                {
                    item.Nit = Encripter.Decrypt(item.Nit);
                    lstClents.Add(item);
                }
                return Ok(lstClents);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }

        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "GetClient")]
        public IActionResult Get(int id)
        {
            try
            {
                Client objClient = _service.Get(id);
                objClient.Nit = Encripter.Decrypt(objClient.Nit);
                return Ok(objClient);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }

        }

        // POST: api/Clients
        [HttpPost]
        public IActionResult Post([FromBody] Client value)
        {
            try
            {
                return Ok(Create(value));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }

            //var result = value;
        }
        
        private IActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            client.Nit = Encripter.Encrypt(client.Nit);
            var result = _service.Add(client);
            if (result.ClientId != 0)
                return Ok(result);
            else return BadRequest();
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client value)
        {
            try
            {
                value.ClientId = id;
                value.Nit = Encripter.Encrypt(value.Nit);
                _service.Update(value);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }
        }
    }
}
