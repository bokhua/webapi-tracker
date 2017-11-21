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
        private readonly ClientViewContext _context = new ClientViewContext();

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

            item.RemoteAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            item.RemotePort = HttpContext.Connection.RemotePort;
            item.UserAgent = HttpContext.Request.Headers.ContainsKey("User-Agent") ? HttpContext.Request.Headers["User-Agent"].ToString() : "";
            item.Time = DateTime.Now;

            _context.ClientViews.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetClientView", new { id = item.Id }, item);
        }
    }
}