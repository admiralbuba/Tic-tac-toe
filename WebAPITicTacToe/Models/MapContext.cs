using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPITicTacToe.Models
{
    public class MapContext : DbContext
    {
        public DbSet<Map> Map { get; set; }
        public MapContext(DbContextOptions<MapContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
