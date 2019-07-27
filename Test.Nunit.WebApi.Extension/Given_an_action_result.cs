using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using NUnit.Framework.Constraints;

using Status = TwentySevenQ.NUnit.WebApi.Extension;
using TwentySevenQ.NUnit.WebApi.Extension;

namespace Test.TwentySevenQ.NUnit.WebApi.Extension
{
    public class Given_an_action_result
    {        
        [SetUp]
        public void Setup()
        {
        }

    #region Success tests

        [Test]
        public void When_ok_Then_it_has_expected_status_code()
        {
            new OkResult().Is(Status.Is.Ok);
        }

        [Test]
        public void When_created_Then_it_has_expected_status_code()
        {
            new CreatedResult("", new object()).Is(Status.Is.Created);
        }
        
        [Test]
        public void When_created_Then_it_has_expected_location()
        {
            var location = "new/location";
            var act = new CreatedResult(location, new object());
            Assert.That(act, Status.Is.Created().And.CreatedAt(location));
            
        }
        
        // 203 Non-authoritative Information
        [Test]
        public void When_non_authoritative_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status203NonAuthoritative).Is( Status.Is.NonAuthoritative);
        }

        // 204 No Content
        [Test]
        public void When_no_content_Then_it_has_expected_status_code()
        {
            new NoContentResult().Is(Status.Is.NoContent);
        }

        // 205 Reset Content
        [Test]
        public void When_reset_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(205).Is(Status.Is.ResetContent);
        }

        // 206 Partial Content
        [Test]
        public void When_partial_content_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status206PartialContent).Is(Status.Is.PartialContent);
        }

        // 226 IM Used
        [Test]
        public void When_im_used_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status226IMUsed).Is(Status.Is.IMUsed);
        }

        
    #endregion

    #region Redirect tests
        // 300 Multiple Choices    
        [Test]
        public void When_multiple_choices_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status300MultipleChoices).Is(Status.Is.MultipleChoices);
        }
        // 303 See Other
        [Test]
        public void When_see_other_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status304NotModified).Is(Status.Is.NotModified);
        }
        // 304 Not Modified       
        [Test]
        public void When_not_modified_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status304NotModified).Is(Status.Is.NotModified);
        }
        // 305 Use Proxy       
        [Test]
        public void When_use_proxy_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status305UseProxy).Is(Status.Is.UseProxy);
        }
       
        // 302 Temporary Redirect        
        [TestCase(false, false)] 
        // 302 Temporary Redirect     
        [TestCase(false, true)]  
        // 307 Permanent Redirect     
        [TestCase(true, false)]    
        // 308 Permanent Redirect 
        [TestCase(true, true)]
        public void When_redirect_Then_it_has_expected_status_code(bool permanent, bool preserveMethod)
        {
            Func<EqualConstraint> expectedStatus = Status.Is.MovedPreserveMethod;

            if (permanent && !preserveMethod)
                expectedStatus = Status.Is.Moved;

            else if (permanent && preserveMethod)
                expectedStatus = Status.Is.MovedPreserveMethod;

            else if (!permanent && !preserveMethod)
                expectedStatus = Status.Is.Redirect;
            
            else
                expectedStatus = Status.Is.RedirectPreserveMethod;
            
            new RedirectResult(".", permanent, preserveMethod).Is(expectedStatus);
        }
    
        // 302 Temporary Redirect        
        [TestCase(false, false, "/new/location")] 
        // 302 Temporary Redirect     
        [TestCase(false, true, "/new/location")]  
        // 307 Permanent Redirect     
        [TestCase(true, false, "/new/location")]    
        // 308 Permanent Redirect 
        [TestCase(true, true, "/new/location")]
        public void When_redirect_to_location_Then_it_has_expected_location(bool permanent, bool preserveMethod, string location)
        {
            var act = new RedirectResult(location, permanent, preserveMethod);

            Assert.That(act, RedirectsTo.Location(location));
        }

        // 302 Temporary Redirect        
        [TestCase(false, false, "/new/location")] 
        // 302 Temporary Redirect     
        [TestCase(false, true, "/new/location")]  
        // 307 Permanent Redirect     
        [TestCase(true, false, "/new/location")]    
        // 308 Permanent Redirect 
        [TestCase(true, true, "/new/location")]
        public void When_redirect_to_location_Then_it_has_expected_status_code_and_location(bool permanent, bool preserveMethod, string location)
        {
            var act = new RedirectResult(location, permanent, preserveMethod);

            EqualConstraint expectedStatus = null;

            if (permanent && !preserveMethod)
                expectedStatus = Status.Is.Moved();

            else if (permanent && preserveMethod)
                expectedStatus = Status.Is.MovedPreserveMethod();

            else if (!permanent && !preserveMethod)
                expectedStatus = Status.Is.Redirect();

            else
                expectedStatus = Status.Is.RedirectPreserveMethod();

            Assert.That(act, expectedStatus.And.RedirectsTo(location));
        }
    
    #endregion

    #region Client error tests
        // 400 Bad Request
        [Test]
        public void When_bad_request_Then_it_has_expected_status_code()
        {
            new BadRequestResult().Is(Status.Is.BadRequest);
        }
        // 401 Unauthorized
        [Test]
        public void When_unauthorized_Then_it_has_expected_status_code()
        {
            new UnauthorizedResult().Is(Status.Is.Unauthorized);
        }
        // 402 Payment Required
        [Test]
        public void When_payment_required_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status402PaymentRequired).Is(Status.Is.PaymentRequired);
        }
        // 403 Forbidden
        [Test]
        public void When_forbidden_Then_it_has_expected_status_code()
        {
            new ForbidResult().Is(Status.Is.Forbidden);
        }
        // 404 Not Found
        [Test]
        public void When_not_found_Then_it_has_expected_status_code()
        {
            //var act = new NotFoundResult();
            //Assert.That(act, Status.Is.NotFound());
            new NotFoundResult().Is(Status.Is.NotFound);
        }
        // 405 Method Not Allowed
        [Test]
        public void When_method_not_allowed_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status405MethodNotAllowed).Is(Status.Is.MethodNotAllowed);
        }
        // 406 Not Acceptable
        [Test]
        public void When_not_acceptable_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status406NotAcceptable).Is(Status.Is.NotAcceptable);
        }
        // 407 Proxy Authentication Required
        [Test]
        public void When__Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status407ProxyAuthenticationRequired).Is(Status.Is.ProxyAuthenticationRequired);
        }
        // 408 Request Timeout
        [Test]
        public void When_request_timeout_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status408RequestTimeout).Is(Status.Is.RequestTimeout);
        }
        // 409 Conflict
        [Test]
        public void When_conflict_Then_it_has_expected_status_code()
        {
            new ConflictResult().Is(Status.Is.Conflict);
        }
        // 410 Gone
        [Test]
        public void When_gone_Then_it_has_expected_status_code()
        { 
            new StatusCodeResult(StatusCodes.Status410Gone).Is(Status.Is.Gone);
        }
        // 411 Length Required
        [Test]
        public void When_length_required_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status411LengthRequired).Is(Status.Is.LengthRequired);
        }
        // 412 Precondition Failed
        [Test]
        public void When_precondition_failed_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status412PreconditionFailed).Is(Status.Is.PreconditionFailed);
        }
        // 413 Payload Too Large
        [Test]
        public void When_payload_too_large_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status413PayloadTooLarge).Is(Status.Is.PayloadToLarge);
        }
        // 415 Unsupported Media Type
        [Test]
        public void When_unsupported_media_type_Then_it_has_expected_status_code()
        {
            new UnsupportedMediaTypeResult().Is(Status.Is.UnsupportedMediaType);
        }
        // 416 Requested Range Not Satisfiable
        [Test]
        public void When_range_not_satisfiable_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status416RangeNotSatisfiable).Is(Status.Is.RangeNotSatisfiable);
        }
        // 417 Expectation Failed
        [Test]
        public void When_expectation_failed_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status417ExpectationFailed).Is(Status.Is.ExpectationFailed);
        }
        // 421 Misdirected Request
        [Test]
        public void When_misdirected_request_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status421MisdirectedRequest).Is(Status.Is.Misdirected);
        }
        // 426 Upgrade Required
        [Test]
        public void When_upgrade_required_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status426UpgradeRequired).Is(Status.Is.UpgradeRequired);
        }
        // 428 Precondition Required
        [Test]
        public void When_precondition_required_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status428PreconditionRequired).Is(Status.Is.PreconditionRequired);
        }
        // 429 Too Many Requests
        [Test]
        public void When_too_many_requests_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status429TooManyRequests).Is(Status.Is.TooManyRequests);
        }
        // 431 Request Header Fields Too Large
        [Test]
        public void When_header_fields_too_large_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status431RequestHeaderFieldsTooLarge).Is(Status.Is.HeaderFieldsTooLarge);
        }
        // 451 Unavailable For Legal Reasons
        [Test]
        public void When_unavailable_for_legal_reasons_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status451UnavailableForLegalReasons).Is(Status.Is.UnavailableForLegalReasons);
        }
    #endregion

    #region System error tests
        // 500 Internal Server Error
        [Test]
        public void When_server_error_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status500InternalServerError).Is(Status.Is.InternalServerError);
        }
        // 501 Not Implemented
        [Test]
        public void When_not_implemented_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status501NotImplemented).Is(Status.Is.NotImplemented);
        }
        // 502 Bad Gateway
        [Test]
        public void When_bad_gateway_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status502BadGateway).Is(Status.Is.BadGateway);
        }
        // 503 Service Unavailable
        [Test]
        public void When_service_unavailable_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status503ServiceUnavailable).Is(Status.Is.ServiceUnavailable);
        }
        // 504 Gateway Timeout
        [Test]
        public void When_gateway_timeout_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status504GatewayTimeout).Is(Status.Is.GatewayTimeout);
        }
        // 505 HTTP Version Not Supported
        [Test]
        public void When_http_version_not_supported_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status505HttpVersionNotsupported).Is(Status.Is.HttpVersionNotSupported);
        }
        // 506 Variant Also Negotiates
        [Test]
        public void When_variant_also_negotiates_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status506VariantAlsoNegotiates).Is(Status.Is.VariantAlsoNegotiates);
        }
        // 510 Not Extended
        [Test]
        public void When_not_extended_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status510NotExtended).Is(Status.Is.NotExtended);
        }
        // 511 Network Authentication Required
        [Test]
        public void When_network_authentication_required_Then_it_has_expected_status_code()
        {
            new StatusCodeResult(StatusCodes.Status511NetworkAuthenticationRequired).Is(Status.Is.NetworkAuthenticationRequired);
        }
    #endregion

    }

    internal static class StatusCodeTestHelper{
        public static void Is(this StatusCodeResult act, Func<IResolveConstraint> test) {
            Assert.That<StatusCodeResult>(act, test());
        }

        public static void Is(this ActionResult act, Func<IResolveConstraint> test) {
            Assert.That(act, test());
        }
        
    }
}