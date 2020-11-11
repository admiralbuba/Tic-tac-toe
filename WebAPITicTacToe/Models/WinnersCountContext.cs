using Microsoft.EntityFrameworkCore;
using Tic_tac_toe.Models;

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
