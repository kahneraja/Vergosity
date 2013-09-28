#region

using System;
using System.Collections.Generic;
using Vergosity.Validation.Attributes;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal abstract class RuleBuilderFactory
	{
		private Type memberType;
		private RuleList rules;
		private RuleBuilderSource source;
		private List<object> validationAttributes = new List<object>();

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
		///   Gets or sets the builder builderSource.
		/// </summary>
		/// <value> The builder builderSource. </value>
		public RuleBuilderSource BuilderSource
		{
			get
			{
				return source;
			}
			set
			{
				source = value;
			}
		}

		/// <summary>
		///   Gets or sets the validation attributes.
		/// </summary>
		/// <value> The validation attributes. </value>
		public List<object> ValidationAttributes
		{
			get
			{
				return validationAttributes;
			}
			set
			{
				validationAttributes = value;
			}
		}

		/// <summary>
		///   Gets or sets the type of the member.
		/// </summary>
		/// <value> The type of the member. </value>
		public Type MemberType
		{
			get
			{
				return memberType;
			}
			set
			{
				memberType = value;
			}
		}

		/// <summary>
		///   Retrieves the member info.
		/// </summary>
		protected void RetrieveMemberTypeInfo()
		{
			MemberType = BuilderSource.Action.GetType();
		}

		/// <summary>
		/// Executes the specified builderSource.
		/// </summary>
		/// <returns></returns>
		/// ///
		public RuleList BuildRules()
		{
			Rules = new RuleList();
			foreach(var attribute in ValidationAttributes)
			{
				ValidationAttribute validation = (ValidationAttribute)attribute;
			    Rules.Add(validation.CreateRule(validation.Target));
			}
			return Rules;
		}

		/// <summary>
		///   Executes the specified builder source.
		/// </summary>
		/// <param name="builderSource"> The builder source. </param>
		/// <returns> </returns>
		public RuleList Execute(RuleBuilderSource builderSource)
		{
			BuilderSource = builderSource;
			RetrieveMemberTypeInfo();
			RetrieveMemberAttributes();

			return BuildRules();
		}

		/// <summary>
		///   Retrieves the member validationAttributes.
		/// </summary>
		protected abstract void RetrieveMemberAttributes();
	}
}