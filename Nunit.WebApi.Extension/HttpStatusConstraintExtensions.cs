using NUnit.Framework.Constraints;

namespace TwentySevenQ.NUnit.WebApi.Extension
{
    public static class HttpStatusConstraintExtensions {

        /// <summary>
        /// Compose RedirectResult.Url with other constraints
        /// <summary>
        public static HttpLocationConstraint RedirectsTo(this ConstraintExpression expression, string expected) {
            var constraint = new HttpLocationConstraint(expected);
            expression.Append(constraint);
            return constraint;
        }

        /// <summary>
        /// Compose CreatedResult.Url with other constraints
        /// <summary>
        public static HttpLocationConstraint CreatedAt(this ConstraintExpression expression, string expected) {
            var constraint = new HttpLocationConstraint(expected);
            expression.Append(constraint);
            return constraint;
        }
    }
    
    public abstract class RedirectsTo {

        /// <summary>
        /// Get constraint that checks if RedirectResult redirects to the expected location
        /// <summary>
       public static HttpLocationConstraint Location(string location)
        {
            return new HttpLocationConstraint(location); 
        }
    }

    public abstract class CreatedAt {

        /// <summary>
        /// Get constraint that checks if CreateResult exists at the expected location
        /// <summary>
       public static HttpLocationConstraint Location(string location)
        {
            return new HttpLocationConstraint(location); 
        }
    }
}