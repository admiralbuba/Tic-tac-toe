using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace WebAPITicTacToe.Models
{
    public class TurnsContext : DbContext
    {
        public DbSet<Turns> Turns { get; set; }
        public TurnsContext(DbContextOptions<TurnsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
