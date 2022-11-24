using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movies.API.Infraestructure.GraphQL;

namespace Movies.API.Domain.Entity;

[Node(
    IdField = nameof(Id),
    NodeResolverType = typeof(MovieResolver),
    NodeResolver = nameof(MovieResolver.ResolveAsync))]
public class Movie
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }
    
    [BsonElement("id")]
    public int? Id { get; set; }
    
    [BsonElement("key")]
    public string? Key { get; set; }
    
    [BsonElement("name")]
    public string? Name { get; set; }
    
    [BsonElement("description")]
    public string? Description { get; set; }
    
    [BsonElement("rate")]
    public string? Rate { get; set; }
    
    [BsonElement("length")]
    public string? Length { get; set; }
    
    [BsonElement("img")]
    public string? Img { get; set; }
    
    [BsonElement("genres")]
    public List<String>? Genres { get; set; }}