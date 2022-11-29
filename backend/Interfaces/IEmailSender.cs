namespace backend.Interfaces;

public interface IEmailSender
{
    Task<string> SendEmailAsync(string recipientEmail);
}