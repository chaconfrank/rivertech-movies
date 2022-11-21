namespace Movies.API.Domain.Helper;

public static class ResponseMessages
{
    public const string? OK = nameof(OK);
    public const string? CREATED = nameof(CREATED);
    public const string? INTERNAL_SERVER_ERROR = nameof(INTERNAL_SERVER_ERROR);
    public const string INVALID_TOKEN = nameof(INVALID_TOKEN);
    public const string UNCAUGHT_ERROR = nameof(UNCAUGHT_ERROR);
    public const string USER_NOT_EXISTENT = nameof(USER_NOT_EXISTENT);
    public const string USERNAME_EXISTS = nameof(USERNAME_EXISTS);
    public const string IDENTIFICATION_EXISTS = nameof(IDENTIFICATION_EXISTS);
    public const string ROLENAME_EXISTS = nameof(ROLENAME_EXISTS);
    public const string WRONG_CREDENTIALS = nameof(WRONG_CREDENTIALS);
    public const string INACTIVE_USER = nameof(INACTIVE_USER);
    public const string FORBIDDEN = nameof(FORBIDDEN);
    public const string UNKNOW_ERROR = nameof(UNKNOW_ERROR);
    public const string NOT_AUTHORIZED = nameof(NOT_AUTHORIZED);
}
