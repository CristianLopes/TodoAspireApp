using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoAspireApp.Application.UseCases.Authentication.Authenticate;
using TodoAspireApp.Application.UseCases.Authentication.Register;

namespace TodoAspireApp.Application
{
    public static class DependencyInjection
    {
        public static IHostApplicationBuilder AddApplicationDependencies(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped<RegisterUseCase>();
            builder.Services.AddScoped<AuthenticateUseCase>();

            return builder;
        }
    }
}
