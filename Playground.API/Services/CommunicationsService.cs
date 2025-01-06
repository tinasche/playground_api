using MailKit.Net.Smtp;
using MimeKit;
using Playground.API.Models.Dtos;

namespace Playground.API.Services;

public class CommunicationsService
{
    private readonly IConfiguration _config;

    public CommunicationsService(IConfiguration configuration)
    {
        _config = configuration;
    }
    public string? SendEmail(SendEmailDto sendEmailDto)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Whelson Unified System", _config["MailConfig:Username"]));
        message.To.Add(new MailboxAddress("Test Client", sendEmailDto.Email));
        message.Subject = sendEmailDto.Subject;
        message.Body = new TextPart("plain")
        {
            Text = sendEmailDto.Body
        };
        
        var result = MailAuthenticator(message);
        
        return result;
    }

    private string? MailAuthenticator(MimeMessage message)
    {
        using (var client = new SmtpClient())
        {
            client.Connect(_config.GetSection("MailConfig")["Host"], 587, false);
            client.Authenticate(_config.GetSection("MailConfig")["Username"], _config.GetSection("MailConfig")["Password"]);
            var result = client.Send(message);
            client.Disconnect(true);
            return result;
        }
    }
}