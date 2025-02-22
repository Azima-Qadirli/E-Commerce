using Microsoft.Extensions.Configuration;
using MiniE_Commerce.Application.Abstractions.Services;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MiniE_Commerce.Infrastructure.Services
{
    public class MailService : IMailService
    {
        readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            mail.Subject = subject;
            mail.Body = body;
            foreach (var to in tos)
                mail.To.Add(to);
            mail.From = new(_configuration["Mail:Username"], "Azima ECommerce", System.Text.Encoding.UTF8);

            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];
            await smtp.SendMailAsync(mail);
        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Hello,dear customer<br>If you have forgetten your password, you may use the link below!<br><strong><a target=\"_blank\" href = \"..../");
            mail.AppendLine(_configuration["ClientUrl"]);
            mail.AppendLine("update-password/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">Click here to request a new password...</a></strong><br><br><span style=\\\"font-size:12px;\\\">Note:If this request has not been made by you, please do not take this email seriously!</span><br><br><br><br>Azima ECommerce");
            await SendMailAsync(to, "ResetPassword", mail.ToString());
        }
    }
}
