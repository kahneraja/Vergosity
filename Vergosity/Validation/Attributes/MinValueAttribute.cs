#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use this attribute to validate the minimum value for the
	/// IComparable type.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class MinValueAttribute : ValidationAttribute
	{
		private readonly object comparisonObject;

		/// <summary>
		///   Initializes a new instance of the <see cref="MinValueAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="comparisonObject"> The comparison object. </param>
		public MinValueAttribute(string name, string failMessage, object comparisonObject)
			: base(name, failMessage)
		{
			if(!(comparisonObject is IComparable))
			{
				throw new Exception("Cannot evaluate attribute and rule with a type that is not IComparable.");
			}
			this.comparisonObject = comparisonObject;
		}

		#region Overrides of ValidationAttribute

		/// <summary>
		/// Creates the rule.
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public override RulePolicy CreateRule(object target)
		{
			if(!(target is IComparable))
			{
				throw new Exception("Cannot evaluate attribute and rule with a type that is not IComparable.");
			}
			Rule = new MinValue<IComparable>(RuleName, FailMessage, (IComparable)target, (IComparable)comparisonObject);
			return Rule;
		}

		#endregion
	}
}