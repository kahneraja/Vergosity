using Vergosity.Actions;
using Vergosity.Validation;

namespace Vergosity.Framework.Tests.Validation
{
    internal class TestValidationContext : ValidationContext
    {
        /// <summary>
        ///     Builds the rules from the specified <see cref="Actions.Action" />.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public override RuleList BuildRules(Vergosity.Actions.Action action)
        {
            return RuleBuilderService.RetrieveRules(action);
        }
    }
}