using ControllerApi.DTO;

namespace ControllerApi.Models;

public record User
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string? SurName { get; set; }
    
    public int? Age { get; set; }
    
    public Address? Address { get; set; }
}