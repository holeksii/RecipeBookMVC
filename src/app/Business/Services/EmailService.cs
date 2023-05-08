using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using RecipeBook.Business.Models;

namespace RecipeBook.Business.Services;

public class EmailService : IEmailService
{
    private readonly SMTPConfigModel _smtpConfig;
    private readonly string _templatePath;

    public EmailService(IOptions<SMTPConfigModel> smtpConfig)
    {
        _smtpConfig = smtpConfig.Value;
        _templatePath = "..\\Business\\EmailTemplates\\{0}.html";
    }

    public void SendEmail(string subject, string toEmail,
        string templateName, List<KeyValuePair<string, string>> placeHolders)
    {
        string template = string.Format(_templatePath, templateName);
        EmailOptions emailOptions = new EmailOptions
        {
            Subject = subject,
            Body = UpdatePlaceHolders(GetEmailBody(template), placeHolders),
            ToEmail = toEmail
        };
        SendEmail(emailOptions);
    }

    private void SendEmail(EmailOptions emailOptions)
    {
        var client = new SmtpClient(_smtpConfig.Host, _smtpConfig.Port)
        {
            Credentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password),
            EnableSsl = _smtpConfig.EnableSSL
        };
        MailMessage mail = new MailMessage
        {
            Subject = emailOptions.Subject,
            Body = emailOptions.Body,
            From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
            IsBodyHtml = _smtpConfig.IsBodyHtml
        };
        mail.To.Add(emailOptions.ToEmail);
        client.Send(mail);
    }

    private string GetEmailBody(string templateName)
    {
        return File.ReadAllText(templateName);
    }

    private string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> placeHolders)
    {
        if(!string.IsNullOrEmpty(text) && placeHolders != null)
        {
            foreach(var placeHolder in placeHolders)
            {
                if(text.Contains(placeHolder.Key))
                {
                    text = text.Replace(placeHolder.Key, placeHolder.Value);
                }
            }
        }
        return text;
    }
}