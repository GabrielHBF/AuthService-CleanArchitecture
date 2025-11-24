using AuthService.Application.Abstractions;

namespace AuthService.Infrastructure.Services;
public class EmailService : IEmailService
{
    public Task SendEmailAsync(string email, string subject, string message)
    {
        Console.WriteLine($"--- EMAIL ENVIADO ---");
        Console.WriteLine($"Para: {email}");
        Console.WriteLine($"Assunto: {subject}");
        Console.WriteLine($"Mensagem: {message}");
        Console.WriteLine($"---------------------");

        return Task.CompletedTask;
    }
}