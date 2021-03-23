using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using WebAPITicTacToe.Models;
using Browser.LogicTransfer;
using Microsoft.AspNetCore.Cors;
using Core;

namespace WebAPITicTacToe.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class WinnersCountController : ControllerBase
    {
        WinnersCountContext db;

        public WinnersCountController(WinnersCountContext context)
        {
            db = context;
        }
        // GET: api/<WinnersCountController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WinnersCount>>> Get()
        {
            return await db.WinnerCount.ToListAsync();
        }
        // PATCH: api/<WinnersCountController>
        [HttpPatch]
        public IActionResult Patch()
        {
            try
            {
                TicTacToe.Instance.ResetGame();
                LogicTransfer.Instance.GameState.WinnersCount.PlayerOWinCount = 0;
                LogicTransfer.Instance.GameState.WinnersCount.PlayerXWinCount = 0;
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(403);
            }
        }
    }
}
