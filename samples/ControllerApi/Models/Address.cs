using JsonPatchBind;

namespace ControllerApi.Models;

public record Address
{
    public string Country { get; set; }

    public string? City { get; set; }

    public string? Street { get; set; }
    
    public int? House { get; set; }
}