using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_tac_toe.Models;
using WebAPITicTacToe.Models;

namespace WebAPITicTacToe.Controllers
{
    [Route("api/[controller]")]
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
    }
}
