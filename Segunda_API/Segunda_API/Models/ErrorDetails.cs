using System.Text.Json;

namespace Segunda_API.Models;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Trace { get; set; } // empilhamento do erro
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
