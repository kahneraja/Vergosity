namespace Vergosity.Validation
{
	/// <summary>
	/// </summary>
	public abstract class Rule : RulePolicy
	{
		/// <summary>
		///   Initializes a new instance of the <see cref="Rule" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		public Rule(string name, string message)
			: base(name, message)
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="Rule" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="priority"> The priority. </param>
		public Rule(string name, string message, int priority)
			: base(name, message, priority)
		{
		}
	}
}