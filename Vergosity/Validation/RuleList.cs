#region

using System.Collections.Generic;

#endregion

namespace Vergosity.Validation
{
	/// <summary>
	/// A list of <see cref="Vergosity.Validation.RulePolicy"/> items.
	/// </summary>
	public class RuleList : List<RulePolicy>
	{

		/// <summary>
		/// Compares the rule priority.
		/// </summary>
		/// <param name="ruleA">The rule A.</param>
		/// <param name="ruleB">The rule B.</param>
		/// <returns></returns>
		public int Compare(RulePolicy ruleA, RulePolicy ruleB)
		{
			return ruleA.Priority.CompareTo(ruleB.Priority);
		}
	}
}