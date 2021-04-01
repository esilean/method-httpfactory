using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fac.HttpMethods.Enums;
using Fac.HttpMethods.Factories.DefHeaders;
using Fac.HttpMethods.Factories.Interfaces;
using Fac.HttpMethods.Request;
using Fac.HttpMethods.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fac.HttpMethods.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly ILogger<RequestsController> _logger;
        private readonly IHttpMethodFactory _httpMethodFactory;

        public RequestsController(ILogger<RequestsController> logger,
                                  IHttpMethodFactory httpMethodFactory)
        {
            _logger = logger;
            _httpMethodFactory = httpMethodFactory;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> Post([FromBody] RequestDto requestDto, CancellationToken cancelattionToken)
        {
            Method method = Method.GET;
            var headers = new List<Headers>();

            ResponseDto response = new ResponseDto();
            switch(requestDto.Method)
            {
                case "get":
                    method = Method.GET;
                    headers.Add(new Headers{ Name = "x-header", Value = "get" });
                    response = await _httpMethodFactory.Execute(method, "bev", "Bev", headers: headers);
                    break;
                case "post":
                    method = Method.POST;
                    break;
                case "put":
                    method = Method.PUT;
                    break;
                case "delete":
                    method = Method.DELETE;
                    headers.Add(new Headers{ Name = "x-header", Value = "delete" });
                    response = await _httpMethodFactory.Execute(method, "bev/2");
                    break;
                default:
                    break;
            }

            return response;
        }
    }
}
