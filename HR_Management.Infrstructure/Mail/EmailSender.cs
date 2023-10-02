using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR_Management.Infrastructure.Mail
{
    public class EmailSender:IEmailSender
    {
        private readonly EmailSetting _emailSetting;

        public EmailSender(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress()
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.ForName

            };
            var message = MailHelper.CreateSingleEmail(from, to, email.subject, email.body, email.body);
            var response = await client.SendEmailAsync(message);
            return response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK;
        }
    }
}
