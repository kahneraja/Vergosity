namespace Vergosity.Validation
{
	/// <summary>
	///   Use to define a validation context.
	/// </summary>
	public interface IValidationContext
	{
		/// <summary>
		///   Gets a value indicating whether this instance is valid.
		/// </summary>
		/// <value> <c>true</c> if this instance is valid; otherwise, <c>false</c> . </value>
		bool IsValid
		{
			get;
		}

		/// <summary>
		///   Gets or sets the rules.
		/// </summary>
		/// <value> The rules. </value>
		RuleList Rules
		{
			get;
			set;
		}

		/// <summary>
		///   Gets or sets the results.
		/// </summary>
		/// <value> The results. </value>
		Results Results
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		ValidationContextState State{ get; set; }
	}
}