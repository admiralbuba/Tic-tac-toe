using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace WebAPITicTacToe.Models
{
    public class MapContext : DbContext
    {
        public DbSet<ButtonInfo> Map { get; set; }
        public MapContext(DbContextOptions<MapContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
