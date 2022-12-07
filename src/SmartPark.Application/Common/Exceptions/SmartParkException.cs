using System.Net;

namespace SmartPark.Application.Common.Exceptions;
public class SmartParkException : Exception
{
    public string Code { get; }
    public HttpStatusCode StatusCode { get; set; }

    public SmartParkException(string code)
    {
        Code = code;
    }

    public SmartParkException(string message, HttpStatusCode httpStatusCode, params object[] args) : this(string.Empty, message, httpStatusCode, args)
    {
    }

    public SmartParkException(string code, string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest, params object[] args) : this(null!, code, message, args)
    {
        StatusCode = httpStatusCode;
    }

    public SmartParkException(Exception innerException, string message, params object[] args)
        : this(innerException, string.Empty, message, args)
    {
    }

    public SmartParkException(Exception innerException, string code, string message, params object[] args)
        : base(string.Format(message, args), innerException)
    {
        Code = code;
    }
}