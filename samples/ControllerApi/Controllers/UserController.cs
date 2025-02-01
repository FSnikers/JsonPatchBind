using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using ControllerApi.DTO;
using Microsoft.AspNetCore.Mvc;
using ControllerApi.Models;

namespace ControllerApi.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private static int LastId { get; set; } = 1;
    private static List<User> Users { get; set; } = new List<User>();

    public UserController() {}

    [HttpGet]
    public IActionResult GetUsers() { return Ok(Users); }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return Ok(user);
    }

    [HttpPatch]
    public IActionResult AddOrUpdateUser([Required][FromBody] UserDto userDto)
    {
        User? user = null;

        if (userDto.Id > 0)
        {
            user = Users.FirstOrDefault(u => u.Id == userDto.Id);
            if (user is null)
                return NotFound();

            Users.Remove(user);
        }

        Users.Add
        (
            (user ?? new User()) with
            {
                Id = user?.Id ?? LastId++,
                Name = userDto.Name,
                SurName = userDto.SurName.HasValue ? userDto.SurName.Value : user?.SurName,
                Age = userDto.Age.HasValue ? userDto.Age.Value : user?.Age,
                Address = userDto.Address.HasValue
                    ? userDto.Address.Value is null
                        ? null
                        : new Address
                        {
                            Country = userDto.Address.Value!.Country,
                            City = userDto.Address.Value!.City.HasValue ? userDto.Address.Value!.City.Value : user?.Address?.City,
                            Street = userDto.Address.Value!.Street.HasValue ? userDto.Address.Value!.Street.Value : user?.Address?.Street,
                            House = userDto.Address.Value!.House.HasValue ? userDto.Address.Value!.House.Value : user?.Address?.House
                        }
                    : user?.Address
            }
        );
        return Ok(user);
    }

}