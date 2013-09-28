#region

using System;
using Vergosity.Validation.RuleBuilder;
using Action = Vergosity.Actions.Action;

#endregion

namespace Vergosity.Validation
{
	/// <summary>
	/// The rule builder service is responsible for retrieving rules from the
	/// specified business action using different factories (i.e., action,
	/// field, or property).
	///
	/// This allows the developer to implement rule attributes on fields, properties, or
	/// the specified target action itself.
	/// </summary>
	public static class RuleBuilderService
	{
		/// <summary>
		///   Retrieves the rules.
		/// </summary>
		/// <param name="action"> The action. </param>
		/// <returns> </returns>
		public static RuleList RetrieveRules(Action action)
		{
			RuleList rules = new RuleList();
			try
			{
				if(action == null)
				{
					throw new ArgumentNullException("action");
				}

				RuleBuilderFactory actionRuleFactory = new ActionRuleFactory();
				RuleBuilderFactory fieldRuleFactory = new FieldRuleFactory();
				RuleBuilderFactory propertyRuleFactory = new PropertyRuleFactory();

				RuleBuilderDirector director = new RuleBuilderDirector();
				director.Builders.Add(new ActionObjectRuleBuilder(new ActionRuleSource(actionRuleFactory, action)));
				director.Builders.Add(new ActionPropertyRuleBuilder(new PropertyRuleSource(propertyRuleFactory, action)));
				director.Builders.Add(new ActionFieldRuleBuilder(new FieldRuleSource(fieldRuleFactory, action)));

				foreach(RuleBuilderBase builder in director.Builders)
				{
					director.DefineBuilder(builder);
					director.CreateRules();
					rules.AddRange(director.RetrieveRules());
				}
			}
			catch(Exception)
			{
				throw;
			}
			return rules;
		}
	}
}