#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use to validate the max value of the target is equal to or less than
	/// the comparison value.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class MaxValueAttribute : ValidationAttribute
	{
		private readonly object comparisonObject;

		/// <summary>
		///   Initializes a new instance of the <see cref="MaxValueAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="comparisonObject"> The comparison object. </param>
		public MaxValueAttribute(string name, string failMessage, object comparisonObject)
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
			Rule = new MaxValue<IComparable>(RuleName, FailMessage, (IComparable)target, (IComparable)comparisonObject);
			return Rule;
		}

		#endregion
	}
}