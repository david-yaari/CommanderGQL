using Microsoft.EntityFrameworkCore;
using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Platforms;
using GraphQL.Server.Ui.Voyager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connString = builder.Configuration.GetConnectionString("CommandConStr");
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer
    (builder.Configuration.GetConnectionString("CommandConStr"))
);
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<PlatformType>()
    .AddProjections();


var app = builder.Build();

//IConfiguration configuration = app.Configuration;
//IWebHostEnvironment environment = app.Environment;

app.MapGraphQL();
app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-voyager");

app.Run();
