using System.Net;
using Microsoft.AspNetCore.Http;
using NUnit.Framework.Constraints;
using NUnitFramework = NUnit.Framework;

namespace TwentySevenQ.NUnit.WebApi.Extension
{    
    /// <summary>
    /// Extend Is to add methods to get constraints for specific http status codes
    /// <summary>
    public class Is : NUnitFramework.Is {

        #region Success : 2XX
        // 200 Ok
        public static EqualConstraint Ok() => HttpStatusCode.OK.Expect();
        // 201 Created
        public static EqualConstraint Created() => HttpStatusCode.Created.Expect();
        // 202 Accepted
        public static EqualConstraint Accepted() => HttpStatusCode.Accepted.Expect();
        // 203 Non-authoritative Information
        public static EqualConstraint NonAuthoritative() => HttpStatusCode.NonAuthoritativeInformation.Expect();
        // 204 No Content
        public static EqualConstraint NoContent() => HttpStatusCode.NoContent.Expect();
        // 205 Reset Content
        public static EqualConstraint ResetContent() => HttpStatusCode.ResetContent.Expect();
        // 206 Partial Content
        public static EqualConstraint PartialContent() => HttpStatusCode.PartialContent.Expect();
        // 226 IM Used
        public static EqualConstraint IMUsed() => StatusCodes.Status226IMUsed.Expect();
        
        #endregion

        #region Redirect : 3XX
        /// <summary>
        /// 300 Multiple Choices
        /// </summary>        
        public static EqualConstraint MultipleChoices() => HttpStatusCode.MultipleChoices.Expect();
        /// <summary>
        /// 301 Moved Permanently
        /// </summary>
        public static EqualConstraint Moved() => HttpStatusCode.Moved.Expect();
        /// <summary>
        /// 302 Found
        /// </summary>
        public static EqualConstraint Found() => HttpStatusCode.Found.Expect();
        /// <summary>
        /// 302 Redirect
        /// </summary>
        public static EqualConstraint Redirect() => HttpStatusCode.Redirect.Expect();
        /// <summary>
        /// 303 See Other
        /// </summary>
        public static EqualConstraint SeeOther() => HttpStatusCode.SeeOther.Expect();
        /// <summary>
        /// 304 Not Modified
        /// </summary>
        public static EqualConstraint NotModified() => HttpStatusCode.NotModified.Expect();
        /// <summary>
        /// 305 Use Proxy
        /// </summary>
        public static EqualConstraint UseProxy() => HttpStatusCode.UseProxy.Expect();
        /// <summary>
        /// 307 Temporary Redirect (MUST preserve method)
        /// </summary>
        public static EqualConstraint RedirectPreserveMethod() => HttpStatusCode.TemporaryRedirect.Expect();
        /// <summary>
        /// 308 Permanent Redirect (MUST preserve method)
        /// </summary>
        public static EqualConstraint MovedPreserveMethod() => StatusCodes.Status308PermanentRedirect.Expect();

        #endregion

        #region Client error : 4XX
        
        /// <summary>
        /// 400 Bad Request
        /// </summary>
        public static EqualConstraint BadRequest() => HttpStatusCode.BadRequest.Expect();
        /// <summary>
        /// 401 Unauthorized
        /// </summary>
        public static EqualConstraint Unauthorized() => HttpStatusCode.Unauthorized.Expect();
        /// <summary>
        /// 402 Payment Required
        /// </summary>
        public static EqualConstraint PaymentRequired() => HttpStatusCode.PaymentRequired.Expect();
        /// <summary>
        /// 403 Forbidden
        /// </summary>
        public static EqualConstraint Forbidden() => HttpStatusCode.Forbidden.Expect();
        /// <summary>
        /// 404 Not Found 
        /// </summary>
        public static EqualConstraint NotFound() => HttpStatusCode.NotFound.Expect();
        
        /// <summary>
        /// 405 Method Not Allowed
        /// </summary>
        public static EqualConstraint MethodNotAllowed() => HttpStatusCode.MethodNotAllowed.Expect();
        
        /// <summary>
        /// 406 Not Acceptable
        /// </summary>
        public static EqualConstraint NotAcceptable() => HttpStatusCode.NotAcceptable.Expect();
        /// <summary>
        /// 407 Proxy Authentication Required
        /// </summary>
        public static EqualConstraint ProxyAuthenticationRequired() => HttpStatusCode.ProxyAuthenticationRequired.Expect();
        /// <summary>
        /// 408 Request Timeout
        /// </summary>
        public static EqualConstraint RequestTimeout() => HttpStatusCode.RequestTimeout.Expect();
        /// <summary>
        /// 409 Conflict
        /// </summary>
        public static EqualConstraint Conflict() => HttpStatusCode.Conflict.Expect();
        /// <summary>
        /// 410 Gone
        /// </summary>
        public static EqualConstraint Gone() { return HttpStatusCode.Gone.Expect(); }
        /// <summary>
        /// 411 Length Required
        /// </summary>
        public static EqualConstraint LengthRequired() => HttpStatusCode.LengthRequired.Expect();
        /// <summary>
        /// 412 Precondition Failed
        /// </summary>
        public static EqualConstraint PreconditionFailed() => HttpStatusCode.PreconditionFailed.Expect();
        /// <summary>
        /// 413 Payload Too Large
        /// </summary>
        public static EqualConstraint PayloadToLarge() => HttpStatusCode.RequestEntityTooLarge.Expect();
        /// <summary>
        /// 415 Unsupported Media Type
        /// </summary>
        public static EqualConstraint UnsupportedMediaType() => HttpStatusCode.UnsupportedMediaType.Expect();
        
        /// <summary>
        /// 416 Requested Range Not Satisfiable
        /// </summary>
        public static EqualConstraint RangeNotSatisfiable() => HttpStatusCode.RequestedRangeNotSatisfiable.Expect();
        
        /// <summary>
        /// 417 Expectation Failed
        /// </summary>
        public static EqualConstraint ExpectationFailed() => HttpStatusCode.ExpectationFailed.Expect();
        
        /// <summary>
        /// 421 Misdirected Request
        /// </summary>
        public static EqualConstraint Misdirected() => StatusCodes.Status421MisdirectedRequest.Expect();
       
        /// <summary>
        /// 426 Upgrade Required
        /// </summary>
        public static EqualConstraint UpgradeRequired() => HttpStatusCode.UpgradeRequired.Expect();
        
        /// <summary>
        /// 428 Precondition Required
        /// </summary>
        public static EqualConstraint PreconditionRequired() => StatusCodes.Status428PreconditionRequired.Expect();
        
        /// <summary>
        /// 429 Too Many Requests
        /// </summary>
        public static EqualConstraint TooManyRequests() => StatusCodes.Status429TooManyRequests.Expect();
        
        /// <summary>
        /// 431 Request Header Fields Too Large
        /// </summary>

        public static EqualConstraint HeaderFieldsTooLarge() => StatusCodes.Status431RequestHeaderFieldsTooLarge.Expect();
        /// <summary>
        /// 451 Unavailable For Legal Reasons
        /// </summary>
        public static EqualConstraint UnavailableForLegalReasons() => StatusCodes.Status451UnavailableForLegalReasons.Expect();

        #endregion

        #region Server error : 5XX
        
        /// <summary>
        /// 500 Internal Server Error
        /// </summary>
        public static EqualConstraint InternalServerError() => HttpStatusCode.InternalServerError.Expect();
        /// <summary>
        /// 501 Not Implemented
        /// </summary>
        public static EqualConstraint NotImplemented() => HttpStatusCode.NotImplemented.Expect();
        /// <summary>
        /// 502 Bad Gateway
        /// </summary>
        public static EqualConstraint BadGateway() => HttpStatusCode.BadGateway.Expect();
        /// <summary>
        /// 503 Service Unavailable
        /// </summary>
        public static EqualConstraint ServiceUnavailable() => HttpStatusCode.ServiceUnavailable.Expect();
        /// <summary>
        /// 504 Gateway Timeout
        /// </summary>
        public static EqualConstraint GatewayTimeout() => HttpStatusCode.GatewayTimeout.Expect();
        /// <summary>
        /// 505 HTTP Version Not Supported
        /// </summary>
        public static EqualConstraint HttpVersionNotSupported() => HttpStatusCode.HttpVersionNotSupported.Expect();
        /// <summary>
        /// 506 Variant Also Negotiates
        /// </summary>
        public static EqualConstraint VariantAlsoNegotiates() => StatusCodes.Status506VariantAlsoNegotiates.Expect();
        /// <summary>
        /// 510 Not Extended
        /// </summary>
        public static EqualConstraint NotExtended() => StatusCodes.Status510NotExtended.Expect();
        /// <summary>
        /// 511 Network Authentication Required
        /// </summary>
        public static EqualConstraint NetworkAuthenticationRequired() => StatusCodes.Status511NetworkAuthenticationRequired.Expect();
        
        #endregion



    }

    /// <summary>
    /// Constraint builder to simplify creating constraints for http status codes
    /// <summary>
    internal static class HttpStatusCodeConstraintBuilder {
        public static EqualConstraint Expect(this HttpStatusCode expected) => new HttpStatusConstraint(expected);
        public static EqualConstraint Expect(this int expected) => new HttpStatusConstraint(expected);
    }
}