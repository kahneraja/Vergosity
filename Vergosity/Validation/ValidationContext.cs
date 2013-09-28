#region

using Vergosity.Actions;

#endregion

namespace Vergosity.Validation
{
	/// <summary>
	///     Use to retrieve rules and other information after rendering
	///     rule sets.
	/// </summary>
	public class ValidationContext : ValidationContextBase
	{
		/// <summary>
		///     Builds the rules from the specified <see cref="Actions.Action" />.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns></returns>
		public override RuleList BuildRules(Action action)
		{
			this.Rules.AddRange(RuleBuilderService.RetrieveRules(action));
			return this.Rules;
		}
	}
}