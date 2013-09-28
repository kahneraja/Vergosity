using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vergosity.Validation
{
	/// <summary>
	/// Use to provide the event handler information about the specified 
	/// rule. 
	/// </summary>
	public class RuleEventArgs : EventArgs
	{
		private RulePolicy rule;

		/// <summary>
		/// Gets the rule.
		/// </summary>
		/// <value>
		/// The rule.
		/// </value>
		public RulePolicy Rule
		{
			get
			{
				return rule;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RuleEventArgs"/> class.
		/// </summary>
		/// <param name="rule">The rule.</param>
		/// <exception cref="System.ArgumentNullException">rule</exception>
		public RuleEventArgs(RulePolicy rule)
		{
			if(rule == null)
			{
				throw new ArgumentNullException("rule");
			}
			this.rule = rule;
		}
	}
}
