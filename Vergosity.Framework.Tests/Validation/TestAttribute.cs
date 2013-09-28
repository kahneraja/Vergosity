using Vergosity.Validation;
using Vergosity.Validation.Attributes;

namespace Vergosity.Framework.Tests.Validation
{
    public class ActionTestAttribute : ValidationAttribute
    {
        public ActionTestAttribute(string name, string failMessage)
            : base(name, failMessage)
        {
        }

        #region Overrides of ValidationAttribute

        /// <summary>
        ///     Creates the rule.
        /// </summary>
        /// <param name="target"> </param>
        /// <returns> </returns>
        public override RulePolicy CreateRule(object target)
        {
            Rule = new TestRule(RuleName, FailMessage, (TestAction) target);
            return Rule;
        }

        #endregion
    }
}