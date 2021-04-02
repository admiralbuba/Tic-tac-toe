using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using WebAPITicTacToe.Models;
using Core;
using Browser.LogicTransfer;
using Microsoft.AspNetCore.SignalR;
using API.Hubs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPITicTacToe.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
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

        // POST api/<MapController>/A00
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Post(ButtonInfo buttonInfo)
        {
            try
            {
                var button = db.Map.FirstOrDefault(x => x.Id == buttonInfo.Id);
                button.Value = buttonInfo.Value;
                db.SaveChanges();
                TicTacToe.Instance.MakeTurn(buttonInfo.Id, buttonInfo.Value, LogicTransfer.Instance);
                return Ok(LogicTransfer.Instance.GameState);
            }
            catch
            {
                return StatusCode(403);
            }

        }

        // PATCH api/<MapController>
        [HttpPatch]
        public IActionResult Patch()
        {
            try
            {
                LogicTransfer.Instance.GameState.EndGame.CurrentWinner = null;
                LogicTransfer.Instance.GameState.EndGame.ShowEndGameMessage = false;
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(403);
            }
        }

        // DELETE api/<MapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
