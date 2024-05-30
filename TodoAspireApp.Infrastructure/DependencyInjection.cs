using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoAspireApp.Application.Interfaces.Persistence;
using TodoAspireApp.Application.Interfaces.Security;
using TodoAspireApp.Infrastructure.Persistence;
using TodoAspireApp.Infrastructure.Security;

namespace TodoAspireApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IHostApplicationBuilder AddInfrastructureDependencies(this IHostApplicationBuilder builder)
        {
            builder.AddNpgsqlDbContext<ApplicationDbContext>("TodoApp");

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPasswordEncryption, PasswordEncryption>();

            return builder;
        }
    }
}
