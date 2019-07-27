using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TwentySevenQ.NUnit.WebApi.Extension
{
    public class HttpStatusConstraint : EqualConstraint
    {
        private const int STATUS_CODE_NOT_RESOLVED = -1;

        public HttpStatusConstraint(HttpStatusCode expected) : base((int)expected)
        {
        }
        public HttpStatusConstraint(int expected) : base(expected)
        {
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            var statusCode = STATUS_CODE_NOT_RESOLVED;

            if ( (actual is IStatusCodeActionResult statusResult)  ) 
                statusCode = GetStatusCode(statusResult);

            //else if (actual is RedirectResult redirectResult) { // TODO: C# 7.1
            if (actual is RedirectResult) 
                statusCode = GetStatusCode(actual as RedirectResult);

            //else if (actual is ForbidResult forbidResult) { // TODO: C# 7.1
            if (actual is ForbidResult) 
                statusCode = GetStatusCode(actual as ForbidResult);
            
            if (statusCode == STATUS_CODE_NOT_RESOLVED) {
                throw new AssertionException($"Expected instance of {typeof(IStatusCodeActionResult).FullName} to test, but was {actual.GetType().FullName}");
            }

            return base.ApplyTo(statusCode); 
        }
      
        private int GetStatusCode(IStatusCodeActionResult result) {
            return result.StatusCode ?? 0;
        }

        private int GetStatusCode(RedirectResult result) {
            return // moved permanently and method MUST NOT be changed
                    result.Permanent && result.PreserveMethod ? StatusCodes.Status308PermanentRedirect :
                    // moved permanently and method MAY be changed
                    result.Permanent && ! result.PreserveMethod ? StatusCodes.Status301MovedPermanently :
                    // moved temporarily and method MUST NOT be changed
                    ! result.Permanent && result.PreserveMethod ? StatusCodes.Status307TemporaryRedirect : 
                    // moved temporarily and method MAY be changed
                    StatusCodes.Status302Found;
        }

        private int GetStatusCode(ForbidResult result) {
            return StatusCodes.Status403Forbidden;
        }
    }
}
