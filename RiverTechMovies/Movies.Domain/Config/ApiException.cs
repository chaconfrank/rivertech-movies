using System.Net;

namespace Movies.Domain.Config;

public class ApiException : Exception
{
    public HttpStatusCode? StatusCode;
    public string? ExtraMessage;
    public ApiException()
    {
        StatusCode = HttpStatusCode.InternalServerError;
    }

    public ApiException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.InternalServerError;
    }

    public ApiException(string message, Exception inner)
        : base(message, inner)
    {
        StatusCode = HttpStatusCode.InternalServerError;
    }

    public ApiException(HttpStatusCode statusCode, string message, Exception inner)
        : base(message, inner)
    {
        this.StatusCode = statusCode;
    }

    public ApiException(HttpStatusCode statusCode, string message)
        : base(message)
    {
        this.StatusCode = statusCode;
    }

    public ApiException(HttpStatusCode statusCode, string message, string? extraMessage)
        : base(message)
    {
        this.StatusCode = statusCode;
        this.ExtraMessage = extraMessage;
    }
}