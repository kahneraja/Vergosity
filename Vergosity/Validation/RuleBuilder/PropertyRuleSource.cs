#region

using Vergosity.Actions;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal class PropertyRuleSource : RuleBuilderSource
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="PropertyRuleSource" /> class.
		/// </summary>
		/// <param name="factory"> The factory. </param>
		/// <param name="action"> The action. </param>
		public PropertyRuleSource(RuleBuilderFactory factory, Action action)
			: base(factory, action)
		{
		}
	}
}