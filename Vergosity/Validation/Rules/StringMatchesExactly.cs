#region

using System;

#endregion

namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   Use to determine if the target string value matches the comparison value explicitly.
	/// </summary>
	public class StringMatchesExactly : Rule
	{
		private readonly string comparisonValue;
		private readonly string target;

		/// <summary>
		///   Initializes a new instance of the <see cref="StringMatchesExactly" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="comparisonValue"> The comparison value. </param>
		public StringMatchesExactly(string name, string message, string target, string comparisonValue)
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
		///   Initializes a new instance of the <see cref="StringMatchesExactly" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="comparisonValue"> The comparison value. </param>
		/// <param name="severity"> The severity. </param>
		public StringMatchesExactly(string name, string message, string target, string comparisonValue, Severity severity)
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
			// Must have exact match, case sensitive
			return string.Compare(target, comparisonValue, StringComparison.Ordinal) == 0;
		}

		/// <summary>
		///   Renders this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			IsValid = Compare();
			return Result = new Result(this);
		}
	}
}