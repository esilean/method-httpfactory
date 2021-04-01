using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Fac.HttpMethods.Response;

namespace Fac.HttpMethods.Factories.Interfaces
{
    public interface IMethodFactory
    {
         Task<ResponseDto> Execute(HttpClient httpClient, string path, HttpContent content = null, CancellationToken cancellationToken = default);
    }
}