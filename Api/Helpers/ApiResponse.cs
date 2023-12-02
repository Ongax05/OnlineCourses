
namespace API.Helpers;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessage(statusCode);
    }

    public ApiResponse()
    {
    }

    private string GetDefaultMessage(int statusCode)
    {
        return statusCode switch
        {
            400 => "Invalid request.",
            401 => "Unautorized user.",
            404 => "Not found.",
            500 => "Server internal error",
            _ => throw new NotImplementedException()
        };
    }
}
