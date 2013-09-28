#region

using System;
using NUnit.Framework;
using Vergosity.Validation;
using Vergosity.Validation.Rules;

#endregion

namespace Vergosity.Framework.Tests.Validation
{
	[TestFixture]
	public class RuleTests
	{
		[Test]
		public void RegularExpressionRuleIsNotValid()
		{
			string regularExpressionText = RegularExpressionConstants.Name;
			string target = "Matt Valencia 1966";
			RegularExpression rule = new RegularExpression("RegularExpressionIsValid", "The RegularExpression does not match.", target, regularExpressionText);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void AreEqualIsNotTrue()
		{
			object target = 1;
			object comparisonObject = 2;
			AreEqual rule = new AreEqual("AreEqual", "AreEqualIsTrue", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void AreEqualIsNotTrueWithNullComparisonObject()
		{
			object target = 1;
			object comparisonObject = null;
			AreEqual rule = new AreEqual("AreEqual", "AreEqualIsTrue", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void AreEqualIsTrue()
		{
			object target = 1;
			object comparisonObject = 1;
			AreEqual rule = new AreEqual("AreEqual", "AreEqualIsTrue", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void AreNotEqualIsNotTrueWithDifferentValues()
		{
			object target = 1;
			object comparisonObject = 2;
			AreNotEqual rule = new AreNotEqual("AreEqual", "AreNotEqualIsTrue", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void AreNotEqualIsNotTrueWithNullComparisonObject()
		{
			object target = 1;
			object comparisonObject = null;
			AreNotEqual rule = new AreNotEqual("AreEqual", "AreNotEqualIsTrue", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsFalseRuleIsNotValid()
		{
			IsFalse rule = new IsFalse("IsFalse", "IsFalseRule", true);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsFalseRuleIsValid()
		{
			IsFalse rule = new IsFalse("IsFalse", "IsFalseRule", false);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsNotNullRuleIsNotValid()
		{
			object target = null;
			IsNotNullRule rule = new IsNotNullRule("IsNotNull", "The target is null. Cannot be null.", target);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsNotNullRuleIsValid()
		{
			int i = 0;
			IsNotNullRule rule = new IsNotNullRule("IsNotNull", "The target is null. Cannot be null.", i);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsNullRuleIsNotValid()
		{
			object target = string.Empty;
			IsNull rule = new IsNull("IsNotNull", "The target is null. Cannot be null.", target);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsNullRuleIsValid()
		{
			object target = null;
			IsNull rule = new IsNull("IsNotNull", "The target is null. Cannot be null.", target);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsTrueRuleIsNotValid()
		{
			IsTrue rule = new IsTrue("IsTrue", "The item is not valid. Must be true.", false);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void IsTrueRuleIsValid()
		{
			IsTrue rule = new IsTrue("IsTrue", "The item is not valid. Must be true.", true);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void MaxValueDateTimeIsNotValid()
		{
			DateTime target = DateTime.Now.AddMonths(1);
			DateTime comparisonValue = DateTime.Now.AddMinutes(1);
			MaxValue<DateTime> rule = new MaxValue<DateTime>("MaxValueRule", "The target is not valid. Must be equal or less than comparison value.", target, comparisonValue);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void MaxValueDateTimeIsValid()
		{
			DateTime target = DateTime.Now;
			DateTime comparisonValue = DateTime.Now.AddMinutes(1);
			MaxValue<DateTime> rule = new MaxValue<DateTime>("MaxValueRule", "The target is not valid. Must be equal or less than comparison value.", target, comparisonValue);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void MaxValueIntIsValid()
		{
			int target = 10;
			int comparisonValue = 10;
			MaxValue<int> rule = new MaxValue<int>("MaxValueRule", "The target is not valid. Must be equal or less than comparison value.", target, comparisonValue);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void MinValueRuleDateTimeIsValid()
		{
			DateTime target = DateTime.Now.AddDays(1);
			DateTime comparisonObject = DateTime.Now;
			MinValue<DateTime> rule = new MinValue<DateTime>("MinValue", "The target value is not valid. Cannot be less than comparison value.", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void MinValueRuleIntIsNotValid()
		{
			int target = 1;
			int comparisonObject = 10;
			MinValue<int> rule = new MinValue<int>("MinValue", "The target value is not valid. Cannot be less than comparison value.", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void MinValueRuleIntIsValid()
		{
			int target = 10;
			int comparisonObject = 1;
			MinValue<int> rule = new MinValue<int>("MinValue", "The target value is not valid. Cannot be less than comparison value.", target, comparisonObject);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void RangeRuleIsNotValid()
		{
			int target = 11;
			int startRange = 0;
			int endRange = 10;
			Range<int> rule = new Range<int>("RangeRuleIsValid", "The target value is not within the specified range.", target, startRange, endRange);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void RangeRuleIsValid()
		{
			int target = 5;
			int startRange = 0;
			int endRange = 10;
			Range<int> rule = new Range<int>("RangeRuleIsValid", "The target value is not within the specified range.", target, startRange, endRange);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void RegularExpressionRuleIsValid()
		{
			string regularExpressionText = RegularExpressionConstants.Name;
			string target = "Matt Valencia";
			RegularExpression rule = new RegularExpression("RegularExpressionIsValid", "The RegularExpression does not match.", target, regularExpressionText);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringIsNotEmptySpaceRuleIsNotValid()
		{
			string target = string.Empty;
			StringIsNotEmptySpace rule = new StringIsNotEmptySpace("StringIsNotEmptySpace", "The string cannot be empty space.", target);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringIsNotEmptySpaceRuleIsValid()
		{
			string target = "Matt";
			StringIsNotEmptySpace rule = new StringIsNotEmptySpace("StringIsNotEmptySpace", "The string cannot be empty space.", target);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringIsNotNullEmptyRangeRuleIsNotValidWithEmptyString()
		{
			int maxLength = 10;
			int minLength = 1;
			object target = string.Empty;
			StringIsNotNullEmptyRange rule = new StringIsNotNullEmptyRange("StringIsNotNullEmptyRange", "The string cannot be null or empty - must be within specified range.", target, minLength, maxLength);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringIsNotNullEmptyRangeRuleIsNotValidWithNull()
		{
			int maxLength = 10;
			int minLength = 1;
			object target = null;
			StringIsNotNullEmptyRange rule = new StringIsNotNullEmptyRange("StringIsNotNullEmptyRange", "The string cannot be null or empty - must be within specified range.", target, minLength, maxLength);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringIsNotNullEmptyRangeRuleIsNotValidWithOutOfRange()
		{
			int maxLength = 10;
			int minLength = 1;
			object target = "Matt Valencia";
			StringIsNotNullEmptyRange rule = new StringIsNotNullEmptyRange("StringIsNotNullEmptyRange", "The string cannot be null or empty - must be within specified range.", target, minLength, maxLength);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringIsNotNullEmptyRangeRuleIsValid()
		{
			int maxLength = 10;
			int minLength = 1;
			object target = "Matt";
			StringIsNotNullEmptyRange rule = new StringIsNotNullEmptyRange("StringIsNotNullEmptyRange", "The string cannot be null or empty - must be within specified range.", target, minLength, maxLength);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringMatchesCaseInsensitiveRuleIsNotValid()
		{
			string target = "MATT";
			string comparisonValue = "matt24";
			StringMatchesCaseInsensitive rule = new StringMatchesCaseInsensitive("StringMatchesCaseInsensitive", "The target string value does not match the comparison value.", target, comparisonValue);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringMatchesCaseInsensitiveRuleIsValid()
		{
			string target = "MATT";
			string comparisonValue = "matt";
			StringMatchesCaseInsensitive rule = new StringMatchesCaseInsensitive("StringMatchesCaseInsensitive", "The target string value does not match the comparison value.", target, comparisonValue);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringMatchesExactlyRuleIsNotValid()
		{
			string target = "matt";
			string comparisonValue = "matt ";
			StringMatchesExactly rule = new StringMatchesExactly("StringMatchesExactly", "The string value is not valid - does not match comparison value.", target, comparisonValue);
			Result result = rule.Execute();

			Assert.IsFalse(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}

		[Test]
		public void StringMatchesExactlyRuleIsValid()
		{
			string target = "matt";
			string comparisonValue = "matt";
			StringMatchesExactly rule = new StringMatchesExactly("StringMatchesExactly", "The string value is not valid - does not match comparison value.", target, comparisonValue);
			Result result = rule.Execute();

			Assert.IsTrue(result.IsValid);
			Assert.IsNotNullOrEmpty(result.Message);
			Assert.IsNotNull(result.RulePolicy);
			Assert.AreEqual(result.RulePolicy.Severity, Severity.Exception);
		}
	}
}