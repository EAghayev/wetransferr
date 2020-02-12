using Core.Services.Rest;
using System;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Services.Rest
{
    public class EmailService : IEmailService
    {
        public async Task Send(string toEmail, string toName, string templateId, object data)
        {
            var client = new SendGridClient("ApiKey");

            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("FromMail", "FromTitle");
            sendGridMessage.AddTo(toEmail, toName);

            sendGridMessage.SetTemplateId(templateId);
            sendGridMessage.SetTemplateData(data);

            await client.SendEmailAsync(sendGridMessage);
        }
    }
}