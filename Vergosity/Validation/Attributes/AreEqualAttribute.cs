#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use attribute to validate that the specified target is equal to the
	/// comparison object.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class AreEqualAttribute : ValidationAttribute
	{
		private readonly object comparisonTarget;

		#region Overrides of ValidationAttribute

		/// <summary>
		///   Initializes a new instance of the <see cref="AreEqualAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="comparisonObject"> The comparisonObject. </param>
		public AreEqualAttribute(string name, string failMessage, object comparisonObject)
			: base(name, failMessage)
		{
			comparisonTarget = comparisonObject;
		}

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			Rule = new AreEqual(RuleName, FailMessage, target, comparisonTarget);
			return Rule;
		}

		#endregion
	}
}