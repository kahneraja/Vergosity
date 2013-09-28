#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use this rule to determine if the string value matches the
	/// comparison value exactly.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class StringMatchesExactlyAttribute : ValidationAttribute
	{
		private readonly string comparisonValue;

		/// <summary>
		///   Initializes a new instance of the <see cref="StringMatchesExactlyAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="comparisonValue"> The comparison value. </param>
		public StringMatchesExactlyAttribute(string name, string failMessage, string comparisonValue)
			: base(name, failMessage)
		{
			this.comparisonValue = comparisonValue;
		}

		#region Overrides of ValidationAttribute

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			Rule = new StringMatchesExactly(RuleName, FailMessage, (string)target, comparisonValue);
			return Rule;
		}

		#endregion
	}
}