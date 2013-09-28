namespace Vergosity.Validation.Rules
{
	/// <summary>
	/// Use rule to determine if the target object is not null.
	/// </summary>
	public class IsNotNullRule : Rule
	{
		private readonly object target;

		/// <summary>
		///   Initializes a new instance of the <see cref="IsNotNullRule" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		public IsNotNullRule(string name, string message, object target)
			: base(name, message)
		{
			this.target = target;
		}

		/// <summary>
		///   Renders this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			IsValid = target != null;
			return Result = new Result(this);
		}
	}
}