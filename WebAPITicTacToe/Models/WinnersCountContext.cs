using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace WebAPITicTacToe.Models
{
    public class WinnersCountContext : DbContext
    {
        public DbSet<WinnersCount> WinnerCount { get; set; }
        public WinnersCountContext(DbContextOptions<WinnersCountContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
