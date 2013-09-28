namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   Use to determine if the targe is null.
	/// </summary>
	public class IsNull : Rule
	{
		private readonly object target;

		/// <summary>
		///   Initializes a new instance of the <see cref="IsNull" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		public IsNull(string name, string message, object target)
			: base(name, message)
		{
			this.target = target;
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="IsNull" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="severity"> The severity. </param>
		public IsNull(string name, string message, object target, Severity severity)
			: base(name, message)
		{
			this.target = target;
			Severity = severity;
		}

		/// <summary>
		///   Evaluates this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			IsValid = (null == target) ? true : false;
			return Result = new Result(this);
		}
	}
}