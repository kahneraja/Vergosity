#region

using System.Linq;

#endregion

namespace Vergosity.Validation
{
	/// <summary>
	///   Use this abstract class to define composite or rule sets.
	/// </summary>
	public abstract class RuleComposite : RulePolicy
	{
		private bool hasErrors = false;
		private bool hasRules;
		private Results resultDetails = new Results();
		private RuleList rules = new RuleList();
		private bool exitRuleRendering = false;

		/// <summary>
		///   Initializes a new instance of the <see cref="RuleComposite" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		public RuleComposite(string name, string message)
			: base(name, message)
		{
		}

		/// <summary>
		///   Gets or sets the rules.
		/// </summary>
		/// <value> The rules. </value>
		public RuleList Rules
		{
			get
			{
				return rules;
			}
			set
			{
				rules = value;
			}
		}

		/// <summary>
		///   Gets or sets the resultDetails.
		/// </summary>
		/// <value> The resultDetails. </value>
		public Results ResultDetails
		{
			get
			{
				return resultDetails;
			}
			set
			{
				resultDetails = value;
			}
		}

		/// <summary>
		///   Gets or sets a value indicating whether this instance has rules.
		/// </summary>
		/// <value> <c>true</c> if this instance has rules; otherwise, <c>false</c> . </value>
		public bool HasRules
		{
			get
			{
				return hasRules;
			}
			set
			{
				hasRules = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance has errors.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has errors; otherwise, <c>false</c> .
		/// </value>
		public bool HasErrors
		{
			get
			{
				return hasErrors;
			}
			set
			{
				hasErrors = value;
			}
		}

		/// <summary>
		///   Renders this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			if(rules != null && rules.Count > 0)
			{
				hasRules = true;
				foreach(RulePolicy rule in rules)
				{
					if(!this.exitRuleRendering)
					{
						rule.OnRuleRendered += OnRuleRenderedHandler;
						resultDetails.Add(rule.Execute());						
					}
					else
					{
						break;
					}
				}
			}
			return ProcessResults();
		}

		/// <summary>
		/// Handles the OnRuleRendered event of the rule control. The rule's RenderType will
		/// determine if the rule set will continue evaluation. This allows for 
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="RuleEventArgs" /> instance containing the event data.</param>
		/// <exception cref="System.NotImplementedException"></exception>
		void OnRuleRenderedHandler(object sender, RuleEventArgs e)
		{
			if(this.RenderType == RenderType.ExitOnFirstFalseEvaluation && !e.Rule.IsValid)
			{
				this.exitRuleRendering = true;
			}

			if(this.RenderType == RenderType.ExitOnFirstTrueEvaluation && e.Rule.IsValid)
			{
				this.exitRuleRendering = true;
			}
		}

		/// <summary>
		///   Processes the results.
		/// </summary>
		/// <returns> </returns>
		private Result ProcessResults()
		{
			int errorCount = (from e in resultDetails
							  where e.IsValid == false
							  select e).Count();

			if(errorCount > 0)
			{
				IsValid = false;
				hasErrors = true;
			}
			else
			{
				IsValid = true;
			}
			return new Result(this);
		}
	}
}