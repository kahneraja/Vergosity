#region

using System.Collections.Generic;
using System.Linq;
using Vergosity.Actions;

#endregion

namespace Vergosity.Validation
{
	/// <summary>
	///     Use the ValidationContext to manage rules and resultDetails from the validation process.
	/// </summary>
	public abstract class ValidationContextBase : IValidationContext
	{
		private readonly Results exceptions = new Results();
		private readonly Results information = new Results();
		private readonly Results warnings = new Results();
		private bool exitRuleRendering;
		private bool isValid = true;
		private RenderType renderType = RenderType.EvaluateAllRules;
		private Results results = new Results();
		private RuleList rules = new RuleList();
		private ValidationContextState state = ValidationContextState.NotEvaluated;

		#region IValidationContext Members

		/// <summary>
		///     Gets or sets the results.
		/// </summary>
		/// <value> The results. </value>
		public Results Results
		{
			get
			{
				return results;
			}
			set
			{
				results = value;
			}
		}

		/// <summary>
		///     Gets or sets the rules.
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
		///     Gets a value indicating whether this instance is valid.
		/// </summary>
		/// <value>
		///     <c>true</c> if this instance is valid; otherwise, <c>false</c> .
		/// </value>
		public bool IsValid
		{
			get
			{
				return isValid;
			}
		}

		#endregion

		/// <summary>
		///     Gets the exception results.
		/// </summary>
		/// <value>
		///     The exception results.
		/// </value>
		public Results ExceptionResults
		{
			get
			{
				List<Result> exceptions = results.FindAll(r => r.RulePolicy.Severity == Severity.Exception);
				foreach (Result r in exceptions)
					this.exceptions.Add(r);
				return this.exceptions;
			}
		}

		/// <summary>
		///     Gets the warning results.
		/// </summary>
		/// <value>
		///     The warning results.
		/// </value>
		public Results WarningResults
		{
			get
			{
				List<Result> warnings = results.FindAll(r => r.RulePolicy.Severity == Severity.Warning);
				foreach (Result r in warnings)
					this.warnings.Add(r);
				return this.warnings;
			}
		}

		/// <summary>
		///     Gets the information results.
		/// </summary>
		/// <value>
		///     The information results.
		/// </value>
		public Results InformationResults
		{
			get
			{
				List<Result> information = results.FindAll(r => r.RulePolicy.Severity == Severity.Information);
				foreach (Result r in information)
					this.information.Add(r);
				return this.information;
			}
		}

		/// <summary>
		///     Gets the type of the render.
		/// </summary>
		/// <value>
		///     The type of the render.
		/// </value>
		public RenderType RenderType
		{
			get
			{
				return renderType;
			}
			set
			{
				renderType = value;
			}
		}

		/// <summary>
		///     Gets or sets the state.
		/// </summary>
		/// <value>
		///     The state.
		/// </value>
		public ValidationContextState State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
			}
		}

		/// <summary>
		///     Builds the rules.
		/// </summary>
		/// <param name="action"> The action. </param>
		/// <returns> </returns>
		public abstract RuleList BuildRules(Action action);

		/// <summary>
		///     Renders the rules.
		/// </summary>
		/// <returns> </returns>
		public IValidationContext RenderRules()
		{
			results = new Results();
			if (rules == null || rules.Count < 1)
			{
				return this;
			}
			else
			{
				//sort rules based on priority;
				rules.Sort();
			}

			foreach (RulePolicy rule in rules)
			{
				if (!exitRuleRendering)
				{
					rule.OnRuleRendered += OnRuleRenderedHandler;
					results.Add(rule.Execute());
				}
				else
				{
					break;
				}
			}

			ProcessResults();
			return this;
		}

		/// <summary>
		///     Called when [rule rendered handler].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">
		///     The <see cref="RuleEventArgs" /> instance containing the event data.
		/// </param>
		private void OnRuleRenderedHandler(object sender, RuleEventArgs e)
		{
			if (RenderType == RenderType.ExitOnFirstFalseEvaluation && !e.Rule.IsValid)
			{
				exitRuleRendering = true;
			}

			if (RenderType == RenderType.ExitOnFirstTrueEvaluation && e.Rule.IsValid)
			{
				exitRuleRendering = true;
			}
		}

		/// <summary>
		///     Renders the rules.
		/// </summary>
		/// <param name="rules"> The rules. </param>
		/// <returns> </returns>
		public IValidationContext RenderRules(RuleList rules)
		{
			this.rules = rules;
			return RenderRules();
		}

		/// <summary>
		///     Processes the results.
		/// </summary>
		protected void ProcessResults()
		{
			int failedRulesCount = (from r in results
			                        where r.IsValid == false
			                        select r).Count();

			if (failedRulesCount > 0)
			{
				isValid = false;
			}
		}
	}
}