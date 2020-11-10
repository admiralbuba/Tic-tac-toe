using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPITicTacToe.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        MapContext db;

        public MapController(MapContext context)
        {
            db = context;
        }
        // GET: api/<ButtonsInfoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Map>>> Get()
        {
            return await db.Map.ToListAsync();
        }

        // GET api/<ButtonsInfoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ButtonsInfoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ButtonsInfoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ButtonsInfoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
