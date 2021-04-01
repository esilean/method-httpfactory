using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Fac.HttpMethods.Factories.Interfaces;
using Fac.HttpMethods.Response;

namespace Fac.HttpMethods.Factories
{
    public class PutHttpMethod : IMethodFactory
    {
        public async Task<ResponseDto> Execute(HttpClient httpClient, string path, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await httpClient.PutAsync(path, content, cancellationToken);

            return new ResponseDto
            { 
                Data = "", 
                StatusCode = 200,
                Method = "Put"
            };
        }
    }
}