using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace App.Service
{
    public class Emailer : IMailer
    {
        
        public readonly IConfiguration _config;
        private readonly ILogger<IMailer> _logger;
        public SendGridClient _emailClient;
        public readonly string _apiKey;
        public readonly EmailAddress _sender;

        public Emailer(IConfiguration config, ILogger<IMailer> logger)
        {
            _logger = logger;
            _config = config;
            _apiKey = _config["SendGrid_ApiKey"];

            var configChildren = _config.GetChildren().ToList();

            foreach(var child in configChildren)
            {
                _logger.Log(LogLevel.Information, "Key:" + child.Key + ", Value:" + child.Value);
                
            }

            _emailClient = new SendGridClient(_apiKey);
            _sender = new EmailAddress(_config["ExternalProviders:SendGrid:SenderEmail"], _config["ExternalProviders:SendGrid:SenderName"]);
        }


        public async Task<Response> Send(string email, string name, string subject, string text)
        {
            
            return await _emailClient.SendEmailAsync(MailHelper.CreateSingleEmail(_sender, new EmailAddress(email, name), subject, text, text));
        }
    }
}


