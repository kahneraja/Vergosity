namespace Vergosity.Actions
{
	/// <summary>
	///   Use to indicate the result of the action.
	/// </summary>
	public enum ActionResult
	{
		/// <summary>
		///   Indicates that the action completed successfully.
		/// </summary>
		Success = 1,

		/// <summary>
		///   Indicates that the action failed duringn processing.
		/// </summary>
		Fail = 2,

		/// <summary>
		///   Indicaets the action state is unknown.
		/// </summary>
		Unknown = 99
	}
}