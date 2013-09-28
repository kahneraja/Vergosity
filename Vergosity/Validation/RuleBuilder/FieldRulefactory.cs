#region

using System;
using System.Collections.Generic;
using System.Reflection;
using Vergosity.Validation.Attributes;

#endregion

namespace Vergosity.Validation.RuleBuilder
{
	internal class FieldRuleFactory : RuleBuilderFactory
	{
		#region Overrides of RuleBuilderFactory

		/// <summary>
		///   Retrieves the member attributes.
		/// </summary>
		protected override void RetrieveMemberAttributes()
		{
			List<FieldInfo> fieldInfos = new List<FieldInfo>(MemberType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance));
			foreach(FieldInfo fieldInfo in fieldInfos)
			{
				List<Attribute> customAttributes = new List<Attribute>(Attribute.GetCustomAttributes(fieldInfo, typeof(ValidationAttribute), true));
				foreach(Attribute attribute in customAttributes)
				{
					ValidationAttribute att = (ValidationAttribute)attribute;
					att.Target = fieldInfo.GetValue(BuilderSource.Action);
					ValidationAttributes.Add(att);
				}
			}
		}

		#endregion
	}
}