#region

using System;
using System.Collections.Generic;
using System.Reflection;
using Vergosity.Validation.Attributes;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal class PropertyRuleFactory : RuleBuilderFactory
	{
		#region Overrides of RuleBuilderFactory

		/// <summary>
		///   Retrieves the member attributes.
		/// </summary>
		protected override void RetrieveMemberAttributes()
		{
			List<PropertyInfo> propertyInfos = new List<PropertyInfo>(MemberType.GetProperties(BindingFlags.Public | BindingFlags.Instance));
			foreach(PropertyInfo info in propertyInfos)
			{
				List<Attribute> propertyAttributes = new List<Attribute>(Attribute.GetCustomAttributes(info, typeof(ValidationAttribute), true));
				foreach(Attribute attribute in propertyAttributes)
				{
					if(attribute is ValidationAttribute)
					{
						ValidationAttribute att = (ValidationAttribute)attribute;
						att.Target = info.GetValue(BuilderSource.Action, null);
						ValidationAttributes.Add(att);
					}
				}
			}
		}

		#endregion
	}
}