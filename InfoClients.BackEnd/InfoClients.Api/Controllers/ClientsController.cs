﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoClients.Api.Utils;
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
            List<Client> lstClents = new List<Client>();
            foreach (var item in _service.Get())
            {
                item.Nit = Encripter.Decrypt(item.Nit);
                lstClents.Add(item);
            }            
            return lstClents;
        }

        // GET: api/Clients/5
        [HttpGet("{id}", Name = "GetClient")]
        public Client Get(int id)
        {
            Client objClient= _service.Get(id);
            objClient.Nit = Encripter.Decrypt(objClient.Nit);
            return objClient;
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
                return BadRequest("Something went wrong!");
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
            catch(Exception ex)
            {
                return BadRequest("Something went wrong!");
            }                      
        }
    }
}
