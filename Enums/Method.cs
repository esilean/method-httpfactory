using System.Runtime.Serialization;

namespace Fac.HttpMethods.Enums
{
    public enum Method
    {
        [EnumMember(Value = "GET")]
        GET,
        [EnumMember(Value = "POST")]
        POST,
        [EnumMember(Value = "PUT")]
        PUT,
        [EnumMember(Value = "DELETE")]
        DELETE
    }
}