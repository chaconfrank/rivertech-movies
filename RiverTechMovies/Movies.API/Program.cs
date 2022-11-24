using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using Movies.API.Application.Movie.Mapper;
using Movies.API.Domain.Config;
using Movies.API.Domain.Context;
using Movies.API.Domain.Entity;
using Movies.API.Domain.Repository;
using Movies.API.Infraestructure;
using Movies.API.Infraestructure.GraphQL;
using Movies.API.Infraestructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MovieMapper));
builder.Services.AddMediatR(typeof(Program));


// Service repository
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("MongoConnection"));

builder.Services.AddSingleton(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value);

// Repositories
builder.Services.AddSingleton<ICatalogContext, MongoContext>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// GraphQL
builder.Services
    .AddSingleton(sp =>
    {
        DatabaseSettings? mongoDbConfiguration = null;
        
        var mongoConnectionUrl = new MongoUrl(mongoDbConfiguration?.ConnectionString);
        var mongoClientSettings = MongoClientSettings.FromUrl(mongoConnectionUrl);
        mongoClientSettings.ClusterConfigurator = cb =>
        {
            // This will print the executed command to the console
            cb.Subscribe<CommandStartedEvent>(e =>
            {
                Console.WriteLine($"{e.CommandName} - {e.Command.ToJson()}");
            });
        };
        var client = new MongoClient(mongoClientSettings);
        var database = client.GetDatabase(mongoDbConfiguration?.DatabaseName);
        return database.GetCollection<Movie>("movies");
    })
    .AddGraphQLServer()
    .AddQueryType<QueryMovie>()
    .AddGlobalObjectIdentification()
    .AddMongoDbFiltering()
    .AddMongoDbSorting()
    .AddMongoDbProjections()
    .AddMongoDbPagingProviders();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGraphQL("/graphql");
app.Run();