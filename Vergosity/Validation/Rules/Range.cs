#region

using System;

#endregion

namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   Use to determine if the target is within the specified start and end values of the type.
	/// </summary>
	/// <typeparam name="T"> </typeparam>
	public class Range<T> : RuleComposite where T : IComparable
	{
		private readonly T endRange;
		private readonly T startRange;
		private readonly T target;

		/// <summary>
		/// Initializes a new instance of the <see cref="Range&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="message">The message.</param>
		/// <param name="target">The target.</param>
		/// <param name="startRange">The start range.</param>
		/// <param name="endRange">The end range.</param>
		public Range(string name, string message, T target, T startRange, T endRange)
			: base(name, message)
		{
			this.target = target;
			this.startRange = startRange;
			this.endRange = endRange;

			ConfigureRules();
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="Range&lt;T&gt;" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="startRange"> The start range. </param>
		/// <param name="endRange"> The end range. </param>
		/// <param name="severity"> The severity. </param>
		public Range(string name, string message, T target, T startRange, T endRange, Severity severity)
			: base(name, message)
		{
			this.target = target;
			this.startRange = startRange;
			this.endRange = endRange;
			Severity = severity;

			ConfigureRules();
		}

		/// <summary>
		///   Determines whether [is within date range].
		/// </summary>
		private void ConfigureRules()
		{
			Rules.Add(new MinValue<T>("MinValue", "The value must be equal to or greater than start range value.", target, startRange));
			Rules.Add(new MaxValue<T>("MinValue", "The value must be equal to or less than end range value.", target, endRange));
		}
	}
}