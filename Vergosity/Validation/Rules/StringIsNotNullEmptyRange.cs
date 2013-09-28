namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   Use to determine if the target string value is not null or empty.
	/// </summary>
	public class StringIsNotNullEmptyRange : RuleComposite
	{
		private readonly int maxLength;
		private readonly int minLength;
		private readonly object target;

		/// <summary>
		/// Initializes a new instance of the <see cref="StringIsNotNullEmptyRange"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="message">The message.</param>
		/// <param name="target">The target.</param>
		/// <param name="minLength">Length of the min.</param>
		/// <param name="maxLength">Length of the max.</param>
		public StringIsNotNullEmptyRange(string name, string message, object target, int minLength, int maxLength)
			: base(name, message)
		{
			this.target = target;
			this.minLength = minLength;
			this.maxLength = maxLength;

			ConfigureRules();
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="StringIsNotNullEmptyRange" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="minLength"> Length of the min. </param>
		/// <param name="maxLength"> Length of the max. </param>
		/// <param name="severity"> The severity. </param>
		public StringIsNotNullEmptyRange(string name, string message, object target, int minLength, int maxLength, Severity severity)
			: base(name, message)
		{
			this.target = target;
			this.minLength = minLength;
			this.maxLength = maxLength;
			Severity = severity;

			ConfigureRules();
		}

		/// <summary>
		///   Renders this instance.
		/// </summary>
		/// <returns> </returns>
		public void ConfigureRules()
		{
			Rules.Add(new IsNotNullRule("StringIsNotNull", "The target string item is null. Cannot be null.", target));
			if(target != null)
			{
				Rules.Add(new Range<int>("StringIsWithinRange", "The target is not within the specified range.", ((string)target).Length, minLength, maxLength));
				Rules.Add(new AreNotEqual("StringIsNotEqualEmptyString", "The target is an empty string - cannot be empty", target, string.Empty));
				Rules.Add(new StringIsNotEmptySpace("StringIsNotEmptySpace", "The target string cannot be empty space. Must contain valid characters.", (string)target));
			}
		}
	}
}