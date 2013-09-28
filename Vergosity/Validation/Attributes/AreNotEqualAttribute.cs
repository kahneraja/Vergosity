#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use to validate that the target object is not equal to the comparison object.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class AreNotEqualAttribute : ValidationAttribute
	{
		private readonly object comparisonObject;

		/// <summary>
		///   Initializes a new instance of the <see cref="AreNotEqualAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="comparisonObject"> The comparison object. </param>
		public AreNotEqualAttribute(string name, string failMessage, object comparisonObject)
			: base(name, failMessage)
		{
			this.comparisonObject = comparisonObject;
		}

		#region Overrides of ValidationAttribute

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			Rule = new AreNotEqual(RuleName, FailMessage, target, comparisonObject);
			return Rule;
		}

		#endregion
	}
}