#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use to validate the value of the target is not null.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class IsNotNullAttribute : ValidationAttribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="IsNotNullAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		public IsNotNullAttribute(string name, string failMessage)
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
			Rule = new IsNotNullRule(RuleName, FailMessage, target);
			return Rule;
		}

		#endregion
	}
}