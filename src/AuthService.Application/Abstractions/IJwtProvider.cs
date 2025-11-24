using AuthService.Domain.Entities;

namespace AuthService.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(ApplicationUser user);
}