var builder = DistributedApplication.CreateBuilder(args);


var dbPassword = builder.AddParameter("DatabasePassword", secret: true);

var dbServer = builder.AddPostgres("dbServer", password: dbPassword);
var db = dbServer.AddDatabase("TodoApp");

dbServer.WithDataVolume()
    .WithPgAdmin();


builder.AddProject<Projects.TodoApp_Api>("todoapp-api")
    .WithReference(db)
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.TodoApp_WebApp>("todoapp-webapp")
    .WithReference(db)
    .WithExternalHttpEndpoints();


builder.AddProject<Projects.TodoAspireApp_Service_DatabaseMigration>("todoaspireapp-service-databasemigration")
    .WithReference(db);


builder.Build().Run();
