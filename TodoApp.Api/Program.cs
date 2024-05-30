using Microsoft.AspNetCore.Http.HttpResults;
using TodoAspireApp.Application;
using TodoAspireApp.Application.UseCases.Authentication;
using TodoAspireApp.Application.UseCases.Authentication.Authenticate;
using TodoAspireApp.Application.UseCases.Authentication.Register;
using TodoAspireApp.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddInfrastructureDependencies();
builder.AddApplicationDependencies();

var app = builder.Build();

app.MapDefaultEndpoints();
app.UseHttpsRedirection();

app.MapPost("/users", async Task<Results<Created<RegisterUseCaseResponse>, Conflict, BadRequest>> (RegisterUserApiRequest request, RegisterUseCase useCase) =>
{

    try
    {
        var useCaseResponse = await useCase.Execute(new (name: request.Name, email: request.Email, password: request.Password));
        return TypedResults.Created<RegisterUseCaseResponse>("", useCaseResponse);
    }
    catch (Exception ex)
    {
        return TypedResults.Conflict();
    }
});

app.MapPost("/sessions", async Task<Results<Created<AuthenticateUseCaseResponse>, Conflict, BadRequest>> (AuthenticateUserApiRequest request, AuthenticateUseCase useCase) =>
{

    try
    {
        var useCaseResponse = await useCase.Execute(new (email: request.Email, password: request.Password));
        return TypedResults.Created<AuthenticateUseCaseResponse>("",useCaseResponse);
    }
    catch (Exception ex)
    {
        return TypedResults.Conflict();
    }
});

app.Run();

public class RegisterUserApiRequest(string name, string email, string password)
{
    public string Name { get; internal set; } = name;
    public string Email { get; internal set; } = email;
    public string Password { get; internal set; } = password;
}

public class AuthenticateUserApiRequest(string email, string password)
{
    public string Email { get; internal set; } = email;
    public string Password { get; internal set; } = password;
}