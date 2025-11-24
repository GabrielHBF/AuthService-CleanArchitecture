using AuthService.Application.Abstractions;
using AuthService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Features.Auth.Login;

public record LoginUserQuery(string Email, string Password) : IRequest<string>;


public class LoginUserHandler : IRequestHandler<LoginUserQuery, string>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginUserHandler(UserManager<ApplicationUser> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
    
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
         
            throw new Exception("Credenciais inválidas.");
        }

        var token = _jwtProvider.Generate(user);

        return token;
    }
}