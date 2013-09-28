#region

using Vergosity.Actions;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal class FieldRuleSource : RuleBuilderSource
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="FieldRuleSource" /> class.
		/// </summary>
		/// <param name="factory"> The factory. </param>
		/// <param name="action"> The action. </param>
		public FieldRuleSource(RuleBuilderFactory factory, Action action)
			: base(factory, action)
		{
		}
	}
}