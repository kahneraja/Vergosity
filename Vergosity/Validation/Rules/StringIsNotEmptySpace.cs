namespace Vergosity.Validation.Rules
{
	/// <summary>
	/// Use rule to determine if the string value contains only empty space.
	/// </summary>
	public class StringIsNotEmptySpace : Rule
	{
		private readonly string target;

		/// <summary>
		/// Initializes a new instance of the <see cref="StringIsNotEmptySpace"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="message">The message.</param>
		/// <param name="target">The target.</param>
		public StringIsNotEmptySpace(string name, string message, string target)
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
			IsValid = !string.IsNullOrWhiteSpace(target);
			return Result = new Result(this);
		}
	}
}