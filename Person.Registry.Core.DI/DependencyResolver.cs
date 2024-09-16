using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Person.Registry.Core.Application.Commands.UserManagement.CreateUser;
using Person.Registry.Core.Domain.UserManagement.Repositories;
using Person.Registry.Core.Infrastructure.Database;
using Person.Registry.Core.Infrastructure.Database.Repositories;

namespace Person.Registry.Core.DI
{
    public class DependencyResolver
    {
        private IConfiguration _configuration { get; }

        public DependencyResolver(IConfiguration configuration) =>
            _configuration = configuration;

        public IServiceCollection Resolve(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString(nameof(DatabaseContext));

            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString)
                                                                     .UseLazyLoadingProxies());

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddApplications(typeof(CreateUserCommand).Assembly);
            services.AddFluentValidation();
            return services;
        }
    }
}
