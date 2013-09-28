#region

using System;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// Use this custom attribute to validate an IComparable
	/// type to determine if the value is within the specified range.
	/// </summary>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	public class RangeAttribute : ValidationAttribute
	{
		private readonly object endRange;
		private readonly object startRange;

		/// <summary>
		///   Initializes a new instance of the <see cref="RangeAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		/// <param name="startRange"> The start range. </param>
		/// <param name="endRange"> The end range. </param>
		public RangeAttribute(string name, string failMessage, object startRange, object endRange)
			: base(name, failMessage)
		{
			if(startRange is IComparable && endRange is IComparable)
			{
				this.startRange = startRange;
				this.endRange = endRange;
			}
			else
			{
				throw new ArgumentException("The start and end range items must be IComparable.");
			}
		}

		#region Overrides of ValidationAttribute

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public override RulePolicy CreateRule(object target)
		{
			if(target is IComparable)
			{
				Rule = new Range<IComparable>(RuleName, FailMessage, (IComparable)target, (IComparable)startRange, (IComparable)endRange);
			}
			else
			{
				throw new ArgumentException("The arguments must be IComparable.");
			}
			return Rule;
		}

		#endregion
	}
}