using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Fac.HttpMethods.Factories.Interfaces;
using Fac.HttpMethods.Response;

namespace Fac.HttpMethods.Factories
{
    public class GetHttpMethod : IMethodFactory
    {
        public async Task<ResponseDto> Execute(HttpClient httpClient, string path, HttpContent content, CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync(path, cancellationToken);
            var contentResult = await response.Content.ReadAsStringAsync();

            return new ResponseDto
            { 
                Data = contentResult, 
                StatusCode = (int)response.StatusCode,
                Method = "Get"
            };
        }
    }
}