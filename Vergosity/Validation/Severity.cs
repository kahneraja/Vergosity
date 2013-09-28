namespace Vergosity.Validation
{
	/// <summary>
	///   Use to specify the type of result when a rule fails evaluation.
	/// </summary>
	public enum Severity
	{
		/// <summary>
		///   Use to indicate a failed rules' result is an exception.
		/// </summary>
		Exception = 1,

		/// <summary>
		///   Use to indicate a failed rule's result is a warning.
		/// </summary>
		Warning = 2,

		/// <summary>
		///   Use to indicate a failed rule's result is informational.
		/// </summary>
		Information = 3
	}
}