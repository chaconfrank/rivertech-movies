using Movies.API.Domain.Entity;

namespace Movies.API.Infraestructure.GraphQL;

public class MovieType : ObjectType<Movie>
{
    protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
    {
        descriptor.Field(_ => _._id);
        descriptor.Field(_ => _.Id);
        descriptor.Field(_ => _.Key);
        descriptor.Field(_ => _.Name);
        descriptor.Field(_ => _.Description);
        descriptor.Field(_ => _.Rate);
        descriptor.Field(_ => _.Length);
        descriptor.Field(_ => _.Img);
        descriptor.Field(_ => _.Genres);
    }
}