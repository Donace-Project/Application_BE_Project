using System.Collections;
using System.Text.Json;

namespace Application_BE_Project.Shared;

public class ErrorDetails
{
    public string StatusCode { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public IDictionary Data {  get; set; }
}
