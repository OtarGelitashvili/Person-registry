using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Person.Registry.Core.Infrastructure.Database.Configuration;

namespace Person.Registry.Core.Infrastructure.Database
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options) =>
            _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DatabaseContext"));

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserPhoneConfiguration());
            builder.ApplyConfiguration(new RelatedUserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
