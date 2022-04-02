using System.Threading.Tasks;
using Analyzer.Lextatico.Infra.Services.Models.EmailService;

namespace Analyzer.Lextatico.Infra.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
