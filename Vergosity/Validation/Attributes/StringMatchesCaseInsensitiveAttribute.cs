#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use this attribute to create validation for a string value. The rule
	/// determines if the string's comparison values matches - the match is NOT
	/// case-sensitive.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class StringMatchesCaseInsensitiveAttribute : ValidationAttribute
	{
		private readonly string comparisonValue;

		/// <summary>
		///   Initializes a new instance of the <see cref="StringMatchesCaseInsensitiveAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="comparisonValue"> The comparison value. </param>
		public StringMatchesCaseInsensitiveAttribute(string name, string failMessage, string comparisonValue)
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
			Rule = new StringMatchesCaseInsensitive(RuleName, FailMessage, (string)target, comparisonValue);
			return Rule;
		}

		#endregion
	}
}