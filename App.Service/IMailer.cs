using System.Threading.Tasks;
using SendGrid;

namespace App.Service
{
    public interface IMailer
    {
        Task<Response> Send(string email, string name, string subject, string text);
    }
}
