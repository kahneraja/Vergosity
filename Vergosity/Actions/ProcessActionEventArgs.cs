#region

using System;

#endregion

namespace Vergosity.Actions
{
	/// <summary>
	///   Use to define arguments for action events.
	/// </summary>
	public class ProcessActionEventArgs : EventArgs
	{
		private readonly bool allowActionExecute;

		/// <summary>
		/// Initializes a new instance of the <see cref="ProcessActionEventArgs"/> class.
		/// </summary>
		/// <param name="allowActionExecute">if set to <c>true</c> [allow action execute].</param>
		public ProcessActionEventArgs(bool allowActionExecute)
		{
			this.allowActionExecute = allowActionExecute;
		}

		/// <summary>
		///   Gets a value indicating whether [allow action execute].
		/// </summary>
		/// <value> <c>true</c> if [allow action execute]; otherwise, <c>false</c> . </value>
		public bool AllowActionExecute
		{
			get
			{
				return allowActionExecute;
			}
		}
	}
}