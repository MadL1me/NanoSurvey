using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Services.Domain
{
    public class NanoSurveyDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Result> Results { get; set; }
        
        public NanoSurveyDbContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=randompass123;");
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("nano");
            
            modelBuilder.Entity<Survey>()
                .HasMany(s => s.Questions)
                .WithMany(q => q.Surveys);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithMany(a => a.Questions);
            
            modelBuilder.Entity<Interview>()
                .HasMany(i => i.Results)
                .WithOne(r => r.Interview);
        }
    }
}