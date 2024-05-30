var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TodoApp_Api>("todoapp-api");

builder.AddProject<Projects.TodoApp_WebApp>("todoapp-webapp");

builder.Build().Run();
