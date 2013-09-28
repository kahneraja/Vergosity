#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use this attribute to validate a string value is not empty space.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class 
		StringIsNotEmptySpaceAttribute : ValidationAttribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="StringIsNotEmptySpaceAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		public StringIsNotEmptySpaceAttribute(string name, string failMessage)
			: base(name, failMessage)
		{
		}

		#region Overrides of ValidationAttribute

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			Rule = new StringIsNotEmptySpace(RuleName, FailMessage, (string)target);
			return Rule;
		}

		#endregion
	}
}