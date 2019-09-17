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
    public class SalesPersonController : ControllerBase
    {
        ILogger logger = LogManager.GetCurrentClassLogger();
        private ISalePersonService _service;

        public SalesPersonController(ISalePersonService service)
        {
            _service = service;
        }
        // GET: api/SalesPerson
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

        // GET: api/SalesPerson/5
        [HttpGet("{id}", Name = "GetSalePerson")]
        public IActionResult Get(int id)
        {
            try
            {
                throw new NotImplementedException();
                
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message+" - "+ex.StackTrace);
                return BadRequest();
            }
           
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
