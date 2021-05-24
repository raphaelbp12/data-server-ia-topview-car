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
        public DbSet<PopulationModel> Populations { get; set; }
        public DbSet<GenerationModel> Generations { get; set; }

        // relational data

        public DbSet<PopulationGenerationModel> PopulationGenerations { get; set; }
        public DbSet<GenerationCarModel> GenerationCars { get; set; }
        public DbSet<CarScoreModel> CarScores { get; set; }
        public DbSet<ParentsModel> Parents { get; set; }
    }
}