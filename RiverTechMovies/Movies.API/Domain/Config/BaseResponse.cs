using System.Text.Json.Serialization;
using Movies.API.Domain.Helper;

namespace Movies.API.Domain.Config;

public class BaseResponse
{
    public string? Message { get; private set; }
    public bool Successful { get; private set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Info { get; private set; }

    public BaseResponse()
    {
        Successful = true;
    }

    public BaseResponse(object? info, string? message, bool successful)
    {
        Info = info;
        Message = message;
        Successful = successful;
    }

    public BaseResponse(string? message, bool succesful)
    {
        Message = message;
        Successful = succesful;
    }

    public static BaseResponse OK()
    {
        return new BaseResponse(ResponseMessages.OK, true);
    }

    public static BaseResponse OK(object? data)
    {
        return new BaseResponse(data, ResponseMessages.OK, true);
    }

    public static BaseResponse Created()
    {
        return new BaseResponse(ResponseMessages.CREATED, true);
    }

    public static BaseResponse Created(object? data)
    {
        return new BaseResponse(data, ResponseMessages.CREATED, true);
    }

    public static BaseResponse InternalServerError()
    {
        return new BaseResponse(ResponseMessages.INTERNAL_SERVER_ERROR, false);
    }

    public static BaseResponse InternalServerError(object? data)
    {
        return new BaseResponse(data, ResponseMessages.INTERNAL_SERVER_ERROR, false);
    }
}