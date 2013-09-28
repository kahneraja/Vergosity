#region

using Vergosity.Actions;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	/// <summary>
	///   Use to build rules associated to the specified <see cref="Action" /> .
	/// </summary>
	internal class ActionObjectRuleBuilder : RuleBuilderBase
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="ActionObjectRuleBuilder" /> class.
		/// </summary>
		/// <param name="source"> The source. </param>
		public ActionObjectRuleBuilder(RuleBuilderSource source)
			: base(source)
		{
		}
	}
}