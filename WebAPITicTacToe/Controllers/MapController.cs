using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_tac_toe.Models;
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
        // GET: api/<MapController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ButtonInfo>>> Get()
        {
            return await db.Map.ToListAsync();
        }

        // PATCH api/<MapController>/A00
        [HttpPatch]
        public IActionResult Patch(ButtonInfo buttonInfo)
        {
            try
            {
                var button = db.Map.FirstOrDefault(x => x.Id == buttonInfo.Id);
                button.Value = buttonInfo.Value;
                db.SaveChanges();
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(403);
            }

        }

        // PUT api/<MapController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
