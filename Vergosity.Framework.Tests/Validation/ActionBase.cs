using System;
using Vergosity.Validation;
using Action = Vergosity.Actions.Action;

namespace Vergosity.Framework.Tests.Validation
{
    internal class ActionBase : Vergosity.Actions.Action
    {
        private readonly ValidationContext validationContext = new TestValidationContext();

        /// <summary>
        ///     Class implementors must override and implement this <see cref="ValidationContext" /> property.
        ///     <see
        ///         cref="ValidationContext" />
        ///     is an abstract class, therefore, a sub-class that implements the abstract class will be needed.
        /// </summary>
        /// <value>
        ///     The validation context.
        /// </value>
        public override IValidationContext ValidationContext
        {
            get { return validationContext; }
        }

        /// <summary>
        ///     Use this method to validate the action. Validation may include any business rules, required data, and specific data formats.
        /// </summary>
        /// <returns></returns>
        protected override IValidationContext ValidateAction()
        {
            return validationContext.RenderRules(validationContext.BuildRules(this));
        }

        protected override void PostValidateAction()
        {
            base.PostValidateAction();
            if (!this.validationContext.IsValid)
            {
                foreach (Result exceptionResult in this.validationContext.ExceptionResults)
                {
                    Console.WriteLine("---------------------{0}----------------------", exceptionResult.RulePolicy.Name);
                    Console.WriteLine("{0}: {1}", exceptionResult.RulePolicy.Name, exceptionResult.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}