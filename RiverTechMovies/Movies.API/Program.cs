using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.API.Application.Movie.Mapper;
using Movies.API.Domain.Repository;
using Movies.API.Infraestructure;
using Movies.API.Infraestructure.GraphQL;
using Movies.API.Infraestructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MovieMapper));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddGraphQLServer().AddQueryType<QueryMovie>();


// Service repository

builder.Services.AddDbContext<Context>(opt 
    => opt.UseInMemoryDatabase("MoviesDb"));  
builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

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