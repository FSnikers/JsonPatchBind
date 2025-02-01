using JsonPatchBind;

namespace ControllerApi.DTO;

public class AddressDto
{
    public string Country { get; set; }

    public Optional<string> City { get; set; }

    public Optional<string> Street { get; set; }
    
    public Optional<int> House { get; set; }
}