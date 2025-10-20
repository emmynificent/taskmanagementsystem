        using MailKit.Net.Smtp;
        using MimeKit;
        using MailKit.Security;
        using TaskManagementSystem.Interface;
        using Microsoft.Extensions.Configuration;
        using TaskManagementSystem.Models;
using Microsoft.Extensions.Options;

namespace TaskManagementSystem.Repository
        {
            public class MailServiceRepository : IEmailService
            {
                
                private readonly EmailSettings _emailSettings;
                private readonly IConfiguration _configuration;

                public MailServiceRepository(IConfiguration configuration)

                {
                    _configuration = configuration;
                }
                public async Task<string> SendEmailAsync(string ReceiverEmail, string subject, string body)
                {
                
                try
                {
                    var smtpServer = _configuration["EmailSettings:SmtpServer"];
                    var port = int.Parse(_configuration["EmailSettings:Port"]);
                    var senderEmail = _configuration["EmailSettings:UserName"];
                    var password = _configuration["EmailSettings:Password"];
                
                    // var smtpServer = _emailSettings.SmtpServer;
                // var port = _emailSettings.Port;
                // var password = _emailSettings.Password;
                // var senderEmail = _emailSettings.UserName;
                if (string.IsNullOrEmpty(password))
                {
                    throw new Exception("Password is not configured. Check the configuration settings.");
                }
                
                var email = new MimeMessage();

                        email.From.Add(new MailboxAddress("", senderEmail));
                        email.To.Add(new MailboxAddress("", ReceiverEmail));
                        email.Subject = subject;
                        email.Body = new TextPart("html") {Text = body};

                        using var client = new SmtpClient();
                        await client.ConnectAsync(smtpServer, port, SecureSocketOptions.StartTls);
                        await client.AuthenticateAsync(senderEmail, password);
                        await client.SendAsync(email);
                        await client.DisconnectAsync(true);

                        return "Email Sent Successfully";
                    }
                
                catch (Exception ex)
                {

                    return $"Email sending failed for this reason. Error: {ex.Message}";
                } 
                }
            } 
        }