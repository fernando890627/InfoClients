using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class StatesController : ControllerBase
    {
        private IStateService _service;
        ILogger logger = LogManager.GetCurrentClassLogger();
        public StatesController(IStateService service)
        {
            _service = service;
        }

        // GET: api/States
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }


        }

        // GET: api/States/5
        [HttpGet("{id}", Name = "GetState")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetStateByCountry/{id}")]        
        public IActionResult GetByCountry(int id)
        {
            try
            {
                return Ok(_service.GetByCountry(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }
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
