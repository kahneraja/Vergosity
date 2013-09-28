#region

using Vergosity.Actions;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal class ActionRuleSource : RuleBuilderSource
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="ActionRuleSource" /> class.
		/// </summary>
		/// <param name="factory"> The factory. </param>
		/// <param name="action"> The action. </param>
		public ActionRuleSource(RuleBuilderFactory factory, Action action)
			: base(factory, action)
		{
		}
	}
}