using EMailSenderWithSendGrid.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using System.Net.Mail;

namespace EMailSenderWithSendGrid.Services
{
    public class EmailService
    {
        private readonly Serilog.ILogger _logger; 
        private readonly string _apiKey;

        public EmailService(IConfiguration configuration)
        {
            _logger = Log.ForContext<EmailService>();
            _apiKey = configuration["EmailSenderAPIKey"];
        }
        public async Task<bool> SendEmailAsync(EmailRequest emailRequest)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var from = new EmailAddress(emailRequest.FromMail, emailRequest.FromName);
                var to = new EmailAddress(emailRequest.Recipient);
                var msg = MailHelper.CreateSingleEmail(from, to, emailRequest.Subject, emailRequest.Body, emailRequest.Body);
                var response = await client.SendEmailAsync(msg);
                if (response.Headers.TryGetValues("X-Message-Id", out var messageIds))
                {
                    string messageId = messageIds.FirstOrDefault();
                    _logger.Information($"Email sent. Message ID: {messageId}");
                }
                else
                {
                    _logger.Warning("Email sent but X-Message-Id header not found.");
                }
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                _logger.Error($"Email could not be sent. Error: {e.Message} | Details: {emailRequest.ToString()}");
                return false;
            }

        }
    }
}
