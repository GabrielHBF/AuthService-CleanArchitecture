using AuthService.Application.Abstractions;
using AuthService.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Application.Features.Auth.Register;
public record RegisterUserCommand(
    string Name,
    string Email,
    string Password
) : IRequest<string>;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailService _emailService;

    public RegisterUserHandler(UserManager<ApplicationUser> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
    }

    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userManager.FindByEmailAsync(request.Email);
        if (userExists != null)
        {
            throw new Exception("E-mail já cadastrado.");
        }

        var user = new ApplicationUser
        {
            UserName = request.Email, 
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Falha ao criar usuário: {errors}");
        }

        await _emailService.SendEmailAsync(request.Email, "Bem-vindo!", "Sua conta foi criada com sucesso.");

        return user.Id;
    }
}