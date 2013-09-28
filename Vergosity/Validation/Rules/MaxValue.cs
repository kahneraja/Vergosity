#region

using System;

#endregion

namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   A rule to evaluate if the target type exceeds the specified max value.
	/// </summary>
	/// <typeparam name="T"> </typeparam>
	public class MaxValue<T> : Rule where T : IComparable
	{
		private readonly T comparisonValue;
		private readonly T target;

		/// <summary>
		///   Initializes a new instance of the <see cref="MaxValue&lt;T&gt;" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="comparisonValue"> The comparison value. </param>
		public MaxValue(string name, string message, T target, T comparisonValue)
			: base(name, message)
		{
			if(null != comparisonValue)
			{
				this.comparisonValue = comparisonValue;
				this.target = target;
			}
			else
			{
				//By definition, any object compares greater than a null reference,
				//and two null references compare equal to each other.
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="MaxValue&lt;T&gt;" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="comparisonValue"> The comparison value. </param>
		/// <param name="severity"> The severity. </param>
		public MaxValue(string name, string message, T target, T comparisonValue, Severity severity)
			: base(name, message)
		{
			//check for nulls;
			if(null != comparisonValue)
			{
				this.comparisonValue = comparisonValue;
				this.target = target;
				Severity = severity;
			}
			else
			{
				//By definition, any object compares greater than a null reference,
				//and two null references compare equal to each other.
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}
		}

		/// <summary>
		///   Compares this instance.
		/// </summary>
		/// <returns> </returns>
		private bool Compare()
		{
			IsValid = false;
			/*
			Less than zero This instance is less than obj.
			Zero This instance is equal to obj.
			Greater than zero This instance is greater than obj.
			*/
			if(((IComparable)target).CompareTo(comparisonValue) <= 0)
			{
				IsValid = true;
			}
			return IsValid;
		}

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