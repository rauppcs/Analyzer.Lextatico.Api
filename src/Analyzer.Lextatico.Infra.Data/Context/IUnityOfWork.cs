using System.Threading;
using System.Threading.Tasks;

namespace Analyzer.Lextatico.Infra.Data.Context
{
    public interface IUnityOfWork
    {
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
