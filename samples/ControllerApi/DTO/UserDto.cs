using System.ComponentModel.DataAnnotations;
using JsonPatchBind;
using JsonPatchBind.ValidationAttributes;

namespace ControllerApi.DTO;

public class UserDto
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    [ValidateOptional(typeof(StringLengthAttribute), 32)]
    [ValidateOptional(typeof(RegularExpressionAttribute), "\\d+")]
    public Optional<string> SurName { get; set; }
    
    public Optional<int> Age { get; set; }
    
    public Optional<AddressDto> Address { get; set; }
    
}