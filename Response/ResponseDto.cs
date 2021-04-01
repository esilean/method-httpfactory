namespace Fac.HttpMethods.Response
{
    public class ResponseDto
    {
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public string Method { get; set; }
    }
}