namespace API.Helpers;

public class ApiValidation : ApiResponse
{
    public ApiValidation() : base(400)
    {

    }

    public IEnumerable<string> Errors { get; set; }

}
