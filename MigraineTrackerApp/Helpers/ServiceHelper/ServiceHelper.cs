using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MigraineTrackerApp.Helpers.ServiceHelper
{
    public class ServiceResult<T>
    {
        public HttpStatusCode status { get; set; }
        public string message { get; set; }
        public T content { get; set; }
    }
    public enum HttpStatusCode
    {
        Continue = 100,
        SwitchingProtocols = 101,
        Processing = 102,
        EarlyHints = 103,
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritativeInformation = 203,
        NoContent = 204,
        Resetcontent = 205,
        PartialContent = 206,
        MultiStatus = 207,
        AlreadyReported = 208,
        IMUsed = 226,
        MultipleChoices = 300,
        Ambiguos = 300,
        MovedPermanently = 301,
        Moved = 301,
        Found = 302,
        Redirect = 302,
        SeeOther = 303,
        RedirectMethod = 303,
        NotModified = 304,
        UseProxy = 305,
        Unused = 306,
        TemporaryRedirect = 307,
        RedirectKeepVerb = 307,
        PermanentRedirect = 308,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        LengthRequired = 411,
        PreconditionFailed = 412,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        UnsupportedMediaType = 415,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        MisdirectedRequest = 421,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        RequestHeaderFieldsTooLarge = 431,
        UnavailableForLegalReasons = 451,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HttpVersionNotSupported = 505,
        VariantAlsoNegotiates = 506,
        InsufficientStorage = 507,
        LoopDetected = 508,
        NotExtended = 510,
        ServiceException = 999,
        Unknown = 1000

    }
    public class ApiHandlers<T>
    {
        public ServiceResult<T> GetServiceResult(HttpResponseMessage response)
        {
            try
            {
                if (response == null)
                {
                    return new ServiceResult<T>()
                    {
                        status = HttpStatusCode.Unknown,
                        message = null
                    };
                }

                String responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode && response.Content != null && !string.IsNullOrWhiteSpace(responseString))
                {
                    var _data = JsonConvert.DeserializeObject<T>(responseString);
                    return new ServiceResult<T>()
                    {
                        status = HttpStatusCode.OK,
                        content = _data
                    };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var _data = JsonConvert.DeserializeObject<T>(responseString);
                    return new ServiceResult<T>()
                    {
                        status = HttpStatusCode.BadRequest,

                        content = _data

                    };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return new ServiceResult<T>()
                    {
                        status = HttpStatusCode.Unauthorized,
                        message = "Response Failed"
                    };
                }
                else
                {
                    return new ServiceResult<T>()
                    {
                        status = HttpStatusCode.Unknown,
                        message = "Response Failed"
                    };
                }

            }
            catch (Exception ex)
            {
                return new ServiceResult<T>()
                {
                    status = HttpStatusCode.Unknown,
                    message = ex.Message
                };
            }
        }
    }


}
