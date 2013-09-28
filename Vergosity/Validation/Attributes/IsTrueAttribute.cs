#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use to validate the value of the target is true.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class IsTrueAttribute : ValidationAttribute
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="IsTrueAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		public IsTrueAttribute(string name, string failMessage)
			: base(name, failMessage)
		{
		}

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			Rule = new IsTrue(RuleName, FailMessage, (bool)target);
			return Rule;
		}
	}
}