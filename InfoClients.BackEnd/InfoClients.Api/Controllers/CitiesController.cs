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
    public class CitiesController : ControllerBase
    {
        ILogger logger = LogManager.GetCurrentClassLogger();
        private ICityService _service;
        public CitiesController(ICityService service)
        {
            _service = service;
        }

        // GET: api/Cities
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

        // GET: api/Cities/5
        [HttpGet("{id}", Name = "GetCity")]
        public string Get(int id)
        {
            return "value";
        }

        //[HttpGet("{id}", Name = "GetCityByState")]
        [HttpGet("GetCityByState/{id}")]        
        public IActionResult GetBySatate(int id)
        {
            try
            {
                return Ok(_service.GetByState(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }
            
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
