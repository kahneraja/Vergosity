#region

using System;

#endregion

namespace Vergosity.Validation.Attributes
{
	/// <summary>
	/// The base class for a validation attribute. This custom attribute
	/// allows developers to create custom attributes that target a custom rule.
	///
	/// Typically, the custom attribute and rule will be developed together. The attribute
	/// requires the ability to initialize the specified custom rule.
	/// </summary>
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public abstract class ValidationAttribute : Attribute
	{
		private string failMessage;
		private RulePolicy rule;
		private string ruleName;
		private object target;

		/// <summary>
		///   Initializes a new instance of the <see cref="ValidationAttribute" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="failMessage"> The fail message. </param>
		public ValidationAttribute(string name, string failMessage)
		{
			ruleName = name;
			this.failMessage = failMessage;
		}

		/// <summary>
		///   Gets or sets the fail message.
		/// </summary>
		/// <value> The fail message. </value>
		public string FailMessage
		{
			get
			{
				return failMessage;
			}
			set
			{
				failMessage = value;
			}
		}

		/// <summary>
		///   Gets or sets the name of the rule.
		/// </summary>
		/// <value> The name of the rule. </value>
		public string RuleName
		{
			get
			{
				return ruleName;
			}
			set
			{
				ruleName = value;
			}
		}

		/// <summary>
		///   Gets or sets the target.
		/// </summary>
		/// <value> The target. </value>
		public object Target
		{
			get
			{
				return target;
			}
			set
			{
				target = value;
			}
		}

		/// <summary>
		///   Gets or sets the rule.
		/// </summary>
		/// <value> The rule. </value>
		public RulePolicy Rule
		{
			get
			{
				return rule;
			}
			set
			{
				rule = value;
			}
		}

		/// <summary>
		///   Creates the rule.
		/// </summary>
		/// <param name="target"> </param>
		/// <returns> </returns>
		public abstract RulePolicy CreateRule(object target);
	}
}