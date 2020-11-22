using System.Threading.Tasks;
using Deskly.DNT.Application;
using Deskly.DNT.Functional;

namespace Deskly.DNT.Configuration
{
    public interface IKeyValueService : IApplicationService
    {
        Task SetValueAsync(string key, string value);
        Task<Maybe<string>> LoadValueAsync(string key);
    }
}
