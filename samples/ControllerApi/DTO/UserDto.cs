using JsonPatchBind;

namespace ControllerApi.DTO;

public class UserDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public Optional<string> SurName { get; set; }
    
    public Optional<int> Age { get; set; }
    
    public Optional<AddressDto> Address { get; set; }
    
}