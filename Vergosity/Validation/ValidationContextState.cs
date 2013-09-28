namespace Vergosity.Validation
{
	/// <summary>
	///     Use to indicate the state of the <see cref="ValidationContextBase" /> item.
	/// </summary>
	public enum ValidationContextState
	{
		/// <summary>
		///     Use to indicate the validation context has not been evaluated.
		/// </summary>
		NotEvaluated = 1,
		/// <summary>
		///     Use to indicate the validation evaluates to success.
		/// </summary>
		Success = 2,
		/// <summary>
		///     Use to indicate the validation evaluates to failure.
		/// </summary>
		Failure = 3
	}
}