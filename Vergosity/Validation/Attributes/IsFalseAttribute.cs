#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use to validate the value of the target is false.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class IsFalseAttribute : ValidationAttribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="IsFalseAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		public IsFalseAttribute(string name, string failMessage)
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
			Rule = new IsFalse(RuleName, FailMessage, (bool)target);
			return Rule;
		}

		#endregion
	}
}