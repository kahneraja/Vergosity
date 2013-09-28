#region

using System;
using Action = Vergosity.Actions.Action;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal abstract class RuleBuilderSource
	{
		private Action action;
		private RuleBuilderFactory factory;

		/// <summary>
		///   Initializes a new instance of the <see cref="RuleBuilderSource" /> class.
		/// </summary>
		/// <param name="factory"> The factory. </param>
		/// <param name="action"> The action. </param>
		protected RuleBuilderSource(RuleBuilderFactory factory, Action action)
		{
			if(factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			if(action == null)
			{
				throw new ArgumentNullException("action");
			}
			this.factory = factory;
			this.action = action;
		}

		/// <summary>
		///   Gets or sets the action.
		/// </summary>
		/// <value> The action. </value>
		public Action Action
		{
			get
			{
				return action;
			}
			set
			{
				action = value;
			}
		}

		public RuleBuilderFactory Factory
		{
			get
			{
				return factory;
			}
			set
			{
				factory = value;
			}
		}

		/// <summary>
		///   Builds the rules.
		/// </summary>
		/// <returns> </returns>
		public virtual RuleList BuildRules()
		{
			return factory.Execute(this);
		}
	}
}