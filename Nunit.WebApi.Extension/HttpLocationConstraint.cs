using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TwentySevenQ.NUnit.WebApi.Extension
{
    public class HttpLocationConstraint : EqualConstraint
    {
        public HttpLocationConstraint(string expected) : base(expected)
        {
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            var location = null as string;

            //if (! (actual is RedirectResult redirectResult) ) // TODO: C# 7.1
            if (actual is RedirectResult) 
                location = GetLocation(actual as RedirectResult);

            if (location == null && actual is CreatedResult)
                location = GetLocation(actual as CreatedResult);

            //if (! (actual is RedirectResult redirectResult) ) // TODO: C# 7.1
            if (location == null)
                throw new AssertionException($"Expected instance of {typeof(RedirectResult).FullName} to test, but was {actual.GetType().FullName}");

            return base.ApplyTo(location);
        }

        private string GetLocation(RedirectResult result) {
            return result.Url;
        }
        private string GetLocation(CreatedResult result) {
            return result.Location;
        }
    }

}