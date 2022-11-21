namespace Movies.API.Infraestructure.Controller.Router;

public class RoutesPath
{
    public const string ApiRoute = "api";
    
    public static class Movies
    {
        public const string Add = "/movies";
        public const string Update = "/movies/{id}";
        public const string Get = "/movies/{id}";
        public const string GetAll = "/movies";
        
    }
}