using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Fac.HttpMethods.Enums;
using Fac.HttpMethods.Factories.DefHeaders;
using Fac.HttpMethods.Factories.Interfaces;
using Fac.HttpMethods.Response;

namespace Fac.HttpMethods.Factories
{
    public class HttpMethodFactory : IHttpMethodFactory
    {
        private readonly IDictionary<Method, IMethodFactory> _methods;

        private IHttpClientFactory _httpClientFactory;

        public HttpMethodFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _methods = new Dictionary<Method, IMethodFactory>();
            Initialize();
        }

        private void Initialize()
        {
            _methods.Add(Method.GET, new GetHttpMethod());
            _methods.Add(Method.POST, new PostHttpMethod());
            _methods.Add(Method.PUT, new PutHttpMethod());
            _methods.Add(Method.DELETE, new DeleteHttpMethod());
        }

        public async Task<ResponseDto> Execute(Method method, 
                                               string path, 
                                               string httpClientName = null, 
                                               HttpContent content = null, 
                                               IList<Headers> headers = null, 
                                               CancellationToken cancellationToken = default)
        {
            if(!_methods.ContainsKey(method))
                throw new Exception("");

            var httpClient = new HttpClient();

            if(!string.IsNullOrWhiteSpace(httpClientName))
            {
                httpClient = _httpClientFactory.CreateClient(httpClientName);
            }
            else 
            {
                httpClient.BaseAddress = new Uri("https://606517eef091970017786fbb.mockapi.io/bank/");
            }

            httpClient.DefaultRequestHeaders.Clear();
            if(headers != null && headers.Any())
            {
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Name, header.Value); 
            }

            return await _methods[method].Execute(httpClient, path, content, cancellationToken);
        }

    }
}