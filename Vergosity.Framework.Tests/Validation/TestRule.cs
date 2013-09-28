using System;
using Vergosity.Validation;
using Vergosity.Validation.Rules;

namespace Vergosity.Framework.Tests.Validation
{
    internal class TestRule : RuleComposite
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TestRule" /> class.
        /// </summary>
        /// <param name="name"> The name. </param>
        /// <param name="message"> The message. </param>
        public TestRule(string name, string message, TestAction target) : base(name, message)
        {
            RenderType = RenderType.EvaluateAllRules;
            Rules.Add(new IsNotNullRule("TestActionIsNotNull", "The action cannot be null.", target));
            if (target != null)
            {
                Rules.Add(new StringIsNotEmptySpace("NameIsValid", "The name cannot be empty string.", target.Name));
                Rules.Add(new Range<DateTime>("CurrentDateIsValid", "The date must be within date range.", target.CurrentDateTime, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1)));
            }
        }
    }
}