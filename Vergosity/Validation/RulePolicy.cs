#region

using System;

#endregion

namespace Vergosity.Validation
{
	/// <summary>
	/// This abstract class provides the base rule policy for all types of rules in this framework. This class contains the common elements of a rule whether composite or simple. Use this class to define other types of rules with more specialized behavior.
	/// </summary>
	public abstract class RulePolicy : IRuleComponent, IComparable<RulePolicy>
	{
		private bool isValid = false;
		private string message;
		private string name;
		private int priority;
		private RenderType renderType = RenderType.EvaluateAllRules;
		private Result result = new Result();
		private Severity severity = Severity.Exception;

		/// <summary>
		///   Initializes a new instance of the <see cref="RulePolicy" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		public RulePolicy(string name, string message)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("The rule policy name cannot be null, empty, or contain only whitespace.", "name");
			}

			if(string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentException("The rule policy message cannot be null, empty, or contain only whitespace.", "message");
			}

			this.name = name;
			this.message = message;
			priority = 0;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="RulePolicy" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="priority"> The priority. </param>
		public RulePolicy(string name, string message, int priority)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("The rule policy name cannot be null, empty, or contain only whitespace.", "name");
			}

			if(string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentException("The rule policy message cannot be null, empty, or contain only whitespace.", "message");
			}

			this.name = name;
			this.message = message;
			this.priority = priority;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RulePolicy"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="message">The message.</param>
		/// <param name="priority">The priority.</param>
		/// <param name="severity">The severity.</param>
		/// <exception cref="System.ArgumentException">
		/// The rule policy name cannot be null, empty, or contain only whitespace.;name
		/// or
		/// The rule policy message cannot be null, empty, or contain only whitespace.;message
		/// </exception>
		public RulePolicy(string name, string message, int priority, Severity severity)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("The rule policy name cannot be null, empty, or contain only whitespace.", "name");
			}

			if(string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentException("The rule policy message cannot be null, empty, or contain only whitespace.", "message");
			}

			this.name = name;
			this.message = message;
			severity = severity;
			this.priority = priority;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RulePolicy"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="message">The message.</param>
		/// <param name="severity">Type of the render.</param>
		public RulePolicy(string name, string message, Severity severity)
		{
			if(string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("The rule policy name cannot be null, empty, or contain only whitespace.", "name");
			}

			if(string.IsNullOrWhiteSpace(message))
			{
				throw new ArgumentException("The rule policy message cannot be null, empty, or contain only whitespace.", "message");
			}

			this.name = name;
			this.message = message;
			severity = severity;
			priority = 0;
		}

		/// <summary>
		///   Gets or sets the message.
		/// </summary>
		/// <value> The message. </value>
		public string Message
		{
			get
			{
				return message;
			}
			set
			{
				message = value;
			}
		}

		/// <summary>
		///   Gets or sets the name.
		/// </summary>
		/// <value> The name. </value>
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		/// <summary>
		///   Gets or sets the priority.
		/// </summary>
		/// <value> The priority. </value>
		public int Priority
		{
			get
			{
				return priority;
			}
			set
			{
				priority = value;
			}
		}

		/// <summary>
		/// Gets or sets the type of the render.
		/// </summary>
		/// <value>
		/// The type of the render.
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
		///   Gets or sets the result.
		/// </summary>
		/// <value> The result. </value>
		public Result Result
		{
			get
			{
				return result;
			}
			set
			{
				result = value;
			}
		}

		/// <summary>
		///   Gets or sets the type of the result.
		/// </summary>
		/// <value> The type of the result. </value>
		public Severity Severity
		{
			get
			{
				return severity;
			}
			set
			{
				severity = value;
			}
		}

		/// <summary>
		///   Gets or sets a value indicating whether this instance is valid.
		/// </summary>
		/// <value> <c>true</c> if this instance is valid; otherwise, <c>false</c> . </value>
		public bool IsValid
		{
			get
			{
				return isValid;
			}
			set
			{
				isValid = value;
			}
		}

		#region IRuleComponent Members

		/// <summary>
		///   Executes this instance.
		/// </summary>
		/// <returns> </returns>
		public Result Execute()
		{
			try
			{
				result = Render();
				this.OnRuleRenderComplete(new RuleEventArgs(this));
			}
			catch(Exception)
			{
				throw;
			}
			return result;
		}

		#endregion

		/// <summary>
		///   Renders this instance.
		/// </summary>
		/// <returns> </returns>
		public abstract Result Render();

		/// <summary>
		/// Occurs when [on rule render].
		/// </summary>
		public event EventHandler<RuleEventArgs> OnRuleRendered;

		/// <summary>
		/// Raises the <see cref="E:RuleRenderComplete"/> event.
		/// </summary>
		/// <param name="args">The <see cref="Vergosity.Validation.RuleEventArgs"/> instance containing the event data.</param>
		public virtual void OnRuleRenderComplete(RuleEventArgs args)
		{
			EventHandler<RuleEventArgs> handler = OnRuleRendered;
			if(handler != null)
			{
				handler(this, args);
			}
		}

		#region IComparable<RulePolicy> Members

		/// <summary>
		/// Compares the current object with another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This object is equal to <paramref name="other" />. Greater than zero This object is greater than <paramref name="other" />.
		/// </returns>
		public int CompareTo(RulePolicy other)
		{
			return this.priority.CompareTo(other.Priority);
		}

		#endregion
	}
}