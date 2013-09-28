#region

using System;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	/// <summary>
	///   Use to build rules using the <see cref="Action" /> property members.
	/// </summary>
	internal class ActionPropertyRuleBuilder : RuleBuilderBase
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="ActionPropertyRuleBuilder" /> class.
		/// </summary>
		/// <param name="source"> The source. </param>
		public ActionPropertyRuleBuilder(RuleBuilderSource source)
			: base(source)
		{
		}
	}
}