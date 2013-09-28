namespace Vergosity.Validation
{
	/// <summary>
	/// </summary>
	public class Result
	{
		private bool isValid = false;
		private string message;
		private RulePolicy rulePolicy;

		/// <summary>
		///   Initializes a new instance of the <see cref="Result" /> class.
		/// </summary>
		public Result()
		{
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="Result" /> class.
		/// </summary>
		/// <param name="rulePolicy"> The rule policy. </param>
		public Result(RulePolicy rulePolicy)
		{
			this.rulePolicy = rulePolicy;
			isValid = rulePolicy.IsValid;
			message = rulePolicy.Message;
		}

		/// <summary>
		///   Gets or sets the rule policy.
		/// </summary>
		/// <value> The rule policy. </value>
		public RulePolicy RulePolicy
		{
			get
			{
				return rulePolicy;
			}
			set
			{
				rulePolicy = value;
			}
		}

		/// <summary>
		///   Gets or sets a value indicating whether this instance is valid.
		/// </summary>
		/// <value> <c>true</c> if this instance is valid; otherwise, <c>false</c> . </value>
		public bool IsValid
		{
			get
			{
				return isValid;
			}
			set
			{
				isValid = value;
			}
		}

		/// <summary>
		///   Gets or sets the message.
		/// </summary>
		/// <value> The message. </value>
		public string Message
		{
			get
			{
				return message;
			}
			set
			{
				message = value;
			}
		}
	}
}