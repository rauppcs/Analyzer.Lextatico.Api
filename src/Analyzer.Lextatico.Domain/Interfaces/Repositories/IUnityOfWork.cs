using System.Threading;
using System.Threading.Tasks;

namespace Analyzer.Lextatico.Domain.Interfaces.Repositories
{
    public interface IUnityOfWork
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
