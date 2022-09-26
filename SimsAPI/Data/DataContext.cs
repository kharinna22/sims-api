using Microsoft.EntityFrameworkCore;
using SimsAPI.Models;

namespace SimsAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        // These properties act like tables
        public DbSet<Sim> Sims { get; set; }
    }
}
