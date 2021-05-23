using Microsoft.EntityFrameworkCore;

namespace DatabaseModels
{
    public class CarContext : DbContext
    {
        public CarContext (DbContextOptions<CarContext> options) : base(options)
        {
        }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<ScoreModel> Scores { get; set; }
    }
}