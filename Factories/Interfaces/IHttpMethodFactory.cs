using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Fac.HttpMethods.Enums;
using Fac.HttpMethods.Factories.DefHeaders;
using Fac.HttpMethods.Response;

namespace Fac.HttpMethods.Factories.Interfaces
{
    public interface IHttpMethodFactory
    {
         Task<ResponseDto> Execute(Method method, 
                                   string path, 
                                   string httpClientName = null, 
                                   HttpContent content = null, 
                                   IList<Headers> headers = null, 
                                   CancellationToken cancellationToken = default);
    }
}