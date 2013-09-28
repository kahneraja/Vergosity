namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   Use rule to determine if the target value is true.
	/// </summary>
	public class IsTrue : Rule
	{
		private readonly bool target;

		/// <summary>
		///   Initializes a new instance of the <see cref="IsTrue" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> if set to <c>true</c> [target]. </param>
		public IsTrue(string name, string message, bool target)
			: base(name, message)
		{
			this.target = target;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="IsTrue" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> if set to <c>true</c> [target]. </param>
		/// <param name="severity"> The severity. </param>
		public IsTrue(string name, string message, bool target, Severity severity)
			: base(name, message)
		{
			this.target = target;
			Severity = severity;
		}

		/// <summary>
		///   Renders this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			IsValid = target == true;
			return Result = new Result(this);
		}
	}
}