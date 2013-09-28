#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use this custom attribute to validate a string object. The attribute
	/// initializes a rule to validate if the string value is not null or empty, and
	/// is also within the specified length range (min/max).
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class StringIsNotNullEmptyRangeAttribute : ValidationAttribute
	{
		private readonly int maxLength;
		private readonly int minLength;

		/// <summary>
		///   Initializes a new instance of the <see cref="StringIsNotNullEmptyRangeAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="minLength"> Length of the min. </param>
		/// <param name="maxLength"> Length of the max. </param>
		public StringIsNotNullEmptyRangeAttribute(string name, string failMessage, int minLength, int maxLength)
			: base(name, failMessage)
		{
			this.minLength = minLength;
			this.maxLength = maxLength;
		}

		#region Overrides of ValidationAttribute

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			Rule = new StringIsNotNullEmptyRange(RuleName, FailMessage, target, minLength, maxLength);
			return Rule;
		}

		#endregion
	}
}