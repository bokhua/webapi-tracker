using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class ClientViewController : Controller
    {
        private ClientViewContext _context;

        public ClientViewController(ClientViewContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ClientView> Get()
        {
            return _context.ClientViews.ToList();
        }

        [HttpGet("{id}", Name="GetClientView")]
        public IActionResult GetById(int id)
        {
            var item = _context.ClientViews.FirstOrDefault( x => x.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClientView item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            item.RemoteAddress = GetHeaderValue("X-Real-IP");
            item.RemotePort = GetHeaderValue("X-Real-Port");
            item.UserAgent = GetHeaderValue("User-Agent");
            item.Time = DateTime.Now;

            _context.ClientViews.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetClientView", new { id = item.Id }, item);
        }

        private string GetHeaderValue(string key)
        {
            return HttpContext.Request.Headers.ContainsKey(key) ? HttpContext.Request.Headers[key].ToString() : "";       
        }
    }
}