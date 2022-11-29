using backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

public class EmailSenderController : Controller
{
    private IEmailSender _emailSender;

    public EmailSenderController(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    [HttpPost, Route("SendEmail")]
    public async Task<IActionResult> SendEmailAsync(string recipientEmail)
    {
        try
        {
            var messageStatus = await _emailSender.SendEmailAsync(recipientEmail);
            return Ok(messageStatus);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}