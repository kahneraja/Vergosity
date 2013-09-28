namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   Use this rule to determine if two objects are not equal.
	/// </summary>
	public class AreNotEqual : Rule
	{
		private readonly object comparisonTarget;
		private readonly object target;

		/// <summary>
		///   Initializes a new instance of the <see cref="AreNotEqual" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="comparisonTarget"> The comparison target. </param>
		public AreNotEqual(string name, string message, object target, object comparisonTarget)
			: base(name, message)
		{
			this.target = target;
			this.comparisonTarget = comparisonTarget;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="AreNotEqual" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="comparisonTarget"> The comparison target. </param>
		/// <param name="severity"> The severity. </param>
		public AreNotEqual(string name, string message, object target, object comparisonTarget, Severity severity)
			: base(name, message)
		{
			this.target = target;
			this.comparisonTarget = comparisonTarget;
			Severity = severity;
		}

		/// <summary>
		///   Renders this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			IsValid = !target.Equals(comparisonTarget);
			return Result = new Result(this);
		}
	}
}