#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class RegularExpressionAttribute : ValidationAttribute
	{
		private readonly string regularExpressionText;

		/// <summary>
		///   Initializes a new instance of the <see cref="RegularExpressionAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="regularExpressionText"> The regular expression text. </param>
		public RegularExpressionAttribute(string name, string failMessage, string regularExpressionText)
			: base(name, failMessage)
		{
			this.regularExpressionText = regularExpressionText;
		}

		#region Overrides of ValidationAttribute

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			Rule = new RegularExpression(RuleName, FailMessage, (string)target, regularExpressionText);
			return Rule;
		}

		#endregion
	}
}