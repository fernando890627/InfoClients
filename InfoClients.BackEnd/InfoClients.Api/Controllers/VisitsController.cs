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
    public class VisitsController : ControllerBase
    {
        private IVisitService _service;
        ILogger logger = LogManager.GetCurrentClassLogger();
        public VisitsController(IVisitService service)
        {
            _service = service;
        }

        // GET: api/Visits
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

        // GET: api/Visits/5
        [HttpGet("{id}", Name = "GetVisit")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("GetByClient/{id}")]
        public IActionResult GetByClient(int id)
        {
            try
            {
                return Ok(_service.GetByClient(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpGet("GetByCity/{id}")]
        public IActionResult GetByCity(int id)
        {
            try
            {
                return Ok(_service.GetByCity(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message + " - " + ex.StackTrace);
                return BadRequest();
            }

        }

        // POST: api/Visits
        [HttpPost]
        public IActionResult Post([FromBody] Visit value)
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
