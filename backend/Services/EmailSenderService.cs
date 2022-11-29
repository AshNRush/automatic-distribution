using System.Net;
using System.Net.Mail;
using backend.Interfaces;
using backend.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace backend.Services;

public class EmailSenderService : IEmailSender
{
    private readonly SmtpSettings _smtpSettings;

    public EmailSenderService(IOptions<SmtpSettings> options)
    {
        _smtpSettings = options.Value;
    }
    
    public async Task<string> SendEmailAsync(string recipientEmail)
    {
        var message = new MimeMessage();
        message.From.Add(MailboxAddress.Parse(_smtpSettings.SenderEmail));
        message.To.Add(MailboxAddress.Parse(recipientEmail));
        message.Subject = "Подтверждение регистрации на портале UDV Summer School";
        message.Body = new TextPart("plain")
        {
            Text = "Чтобы подтвердить регистрацию, пройдите по этой ссылке: TODO"
        };

        var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
            await client.AuthenticateAsync(new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password));
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            return "Email sent successfully";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            client.Dispose();
        }
    }
}