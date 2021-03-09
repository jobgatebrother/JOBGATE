using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Service
{
    public class EmailSender : IEmailSender
    {
        private SmtpEmailOption _options;
        public EmailSender(IConfiguration configuration)
        {
           _options =  configuration.GetSection("EmailSettings").Get<SmtpEmailOption>();
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("JOBGATE", _options.Username));
            message.To.Add(new MailboxAddress("User", email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlMessage;
            message.Body = bodyBuilder.ToMessageBody();

            using(var client = new SmtpClient())
            {
                await client.ConnectAsync(_options.Host, _options.Port);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_options.Username, _options.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
