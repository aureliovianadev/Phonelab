using Phonelab.API.DTOs;

namespace Phonelab.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}


