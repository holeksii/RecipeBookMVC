using System.Threading.Tasks;
namespace RecipeBook.Business.Services;

public interface IEmailService
{
    void SendEmail(string subject, string toEmail,
        string templateName, List<KeyValuePair<string, string>> placeHolders);
}