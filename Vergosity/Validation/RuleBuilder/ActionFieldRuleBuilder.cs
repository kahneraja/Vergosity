#region

using System;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	/// <summary>
	///   Use to build rules from the <see cref="Action" /> field members.
	/// </summary>
	internal class ActionFieldRuleBuilder : RuleBuilderBase
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="ActionFieldRuleBuilder" /> class.
		/// </summary>
		/// <param name="source"> The source. </param>
		public ActionFieldRuleBuilder(RuleBuilderSource source)
			: base(source)
		{
		}
	}
}