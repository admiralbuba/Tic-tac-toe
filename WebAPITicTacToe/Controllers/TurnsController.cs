using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tic_tac_toe.Models;
using WebAPITicTacToe.Models;

namespace WebAPITicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnsController : ControllerBase
    {
        TurnsContext db;

        public TurnsController(TurnsContext context)
        {
            db = context;
        }
        // GET: api/<TurnsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turns>>> Get()
        {
            return await db.Turns.ToListAsync();
        }
    }
}
