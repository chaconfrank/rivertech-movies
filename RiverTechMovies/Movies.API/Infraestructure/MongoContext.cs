using MongoDB.Driver;
using Movies.API.Domain.Config;
using Movies.API.Domain.Context;
using Movies.API.Domain.Entity;

namespace Movies.API.Infraestructure;

public class MongoContext : ICatalogContext
{
    private const string MovieCollectionName = "movies";

    public MongoContext(DatabaseSettings mongoDbConfiguration)
    {
        var client = new MongoClient(mongoDbConfiguration.ConnectionString);
        var database = client.GetDatabase(mongoDbConfiguration.DatabaseName);

        this.Movies = database.GetCollection<Movie>(MovieCollectionName);
    }
    public IMongoCollection<Movie> Movies { get; }
}