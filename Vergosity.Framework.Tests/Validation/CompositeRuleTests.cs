using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Vergosity.Validation.Rules;
using Vergosity.Validation;

namespace Vergosity.Framework.Tests.Validation
{
	[TestFixture]
	public class CompositeRuleTests
	{
		/// <summary>
		/// Determines whether this instance [can render rule set and exit on first false evaluation].
		/// </summary>
		[Test]
		public void CanRenderRuleSetAndExitOnFirstFalseEvaluation()
		{
			string target = null;
			ValidationContext context = new ValidationContext();
			context.RenderType = RenderType.ExitOnFirstFalseEvaluation;

			StringIsNotNullEmptyRange compositeRule = new StringIsNotNullEmptyRange("TargetStringIsNotNullEmptyRange", "Target is not valid.", target, 5, 8);
			compositeRule.Priority = 20;
			compositeRule.RenderType = RenderType.ExitOnFirstFalseEvaluation;
			context.Rules.Add(compositeRule);

			StringIsNotEmptySpace emptySpaceRule = new StringIsNotEmptySpace("TestStringIsNotEmptySpace", "The target cannot be an empty string.", string.Empty);
			emptySpaceRule.Priority = 10;
			context.Rules.Add(emptySpaceRule);

			context.RenderRules();
			Assert.IsFalse(context.IsValid);
			Assert.AreEqual(context.ExceptionResults.Count, 1);
		}
	}
}
