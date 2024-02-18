using Application.Models.DTO;
using AutoMapper;
using Infrastructure.Identity;

namespace Infrastructure.Mappers;

/// <summary>
/// Mapping profile for UserDto.
/// </summary>
public class UserMapper : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserMapper"/> class.
    /// </summary>
    public UserMapper()
    {
        this.CreateMap<ApplicationUser, UserDto>().ReverseMap();
    }
}
