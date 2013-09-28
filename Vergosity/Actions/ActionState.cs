namespace Vergosity.Actions
{
	/// <summary>
	///   Use enum to indicate the state of the action.
	/// </summary>
	public enum ActionState
	{
		/// <summary>
		///   Use to indicate the action has not executed.
		/// </summary>
		NotExecuted = 1,

		/// <summary>
		///   Use to indicate the action is in process.
		/// </summary>
		InProcess = 2,

		/// <summary>
		///   Use to indicate the action is complete.
		/// </summary>
		Complete = 3
	}
}