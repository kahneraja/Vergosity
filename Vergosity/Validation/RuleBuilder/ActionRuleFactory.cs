#region

using System.Collections.Generic;
using Vergosity.Validation.Attributes;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal class ActionRuleFactory : RuleBuilderFactory
	{
		#region Overrides of RuleBuilderFactory

		/// <summary>
		/// Retrieves the member attributes.
		/// </summary>
		protected override void RetrieveMemberAttributes()
		{
			if(MemberType != null)
			{
                ValidationAttributes = new List<object>(MemberType.GetCustomAttributes(typeof(ValidationAttribute), true));
			    foreach (object validationAttribute in ValidationAttributes)
			    {
			        ((ValidationAttribute) validationAttribute).Target = this.BuilderSource.Action;
			    }
				foreach (object attribute in ValidationAttributes)
				{
					((ValidationAttribute)attribute).Target = this.BuilderSource.Action;
				}
			}
		}

		#endregion
	}
}