#region

using System;

#endregion

namespace Vergosity.Validation.Rules
{
	// One of several string content evaluation possibilities.
	// This one performs a case insensitive match.
	/// <summary>
	///   Use to determine if the target string value matches the specified comparison value. The rule performs a case-insensitive match.
	/// </summary>
	public class StringMatchesCaseInsensitive : Rule
	{
		private readonly string comparisonValue;
		private readonly string target;

		/// <summary>
		/// Initializes a new instance of the <see cref="StringMatchesCaseInsensitive"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="message">The message.</param>
		/// <param name="target">The target.</param>
		/// <param name="comparisonValue">The comparison value.</param>
		public StringMatchesCaseInsensitive(string name, string message, string target, string comparisonValue)
			: base(name, message)
		{
			if(comparisonValue == null)
			{
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}
			if(target == null)
			{
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}

			this.comparisonValue = comparisonValue;
			this.target = target;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="StringMatchesCaseInsensitive" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="comparisonValue"> The comparison value. </param>
		/// <param name="severity"> The severity. </param>
		public StringMatchesCaseInsensitive(string name, string message, string target, string comparisonValue, Severity severity)
			: base(name, message)
		{
			if(comparisonValue == null)
			{
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}
			if(target == null)
			{
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}

			this.comparisonValue = comparisonValue;
			this.target = target;
			Severity = severity;
		}

		/// <summary>
		///   Compares this instance.
		/// </summary>
		/// <returns> </returns>
		private bool Compare()
		{
			return string.Compare(target, comparisonValue, StringComparison.OrdinalIgnoreCase) == 0;
		}

		// override executed by rule engine from action rule evaluation request
		/// <summary>
		///   Evaluates this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			IsValid = Compare();
			return Result = new Result(this);
		}
	}
}