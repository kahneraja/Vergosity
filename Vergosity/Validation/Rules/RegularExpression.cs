#region

using System;
using System.Text.RegularExpressions;

#endregion

namespace Vergosity.Validation.Rules
{
	/// <summary>
	///   Use to determine if the target matches the specified regular expression.
	/// </summary>
	public class RegularExpression : Rule
	{
		private readonly string regularExpressionText;
		private readonly string target;

		/// <summary>
		///   Initializes a new instance of the <see cref="RegularExpression" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="regularExpressionText"> The regular expression text. </param>
		public RegularExpression(string name, string message, string target, string regularExpressionText)
			: base(name, message)
		{
			if(null != target)
			{
				this.regularExpressionText = regularExpressionText;
				this.target = target;
			}
			else
			{
				//By definition, any object compares greater than a null reference,
				//and two null references compare equal to each other.
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}
		}

		/// <summary>
		///   Initializes a new instance of the <see cref="RegularExpression" /> class.
		/// </summary>
		/// <param name="name"> The name. </param>
		/// <param name="message"> The message. </param>
		/// <param name="target"> The target. </param>
		/// <param name="regularExpressionText"> The regular expression text. </param>
		/// <param name="severity"> The severity. </param>
		public RegularExpression(string name, string message, string target, string regularExpressionText, Severity severity)
			: base(name, message)
		{
			if(null != target)
			{
				this.regularExpressionText = regularExpressionText;
				this.target = target;
				Severity = severity;
			}
			else
			{
				//By definition, any object compares greater than a null reference,
				//and two null references compare equal to each other.
				throw new NullReferenceException("Cannot evaluate null object(s).");
			}
		}

		/// <summary>
		///   Matches the regular expression.
		/// </summary>
		/// <returns> </returns>
		private bool MatchRegularExpression()
		{
			bool isMatch = false;

			//instantiate RegEx;
			var regularExpression = new Regex(regularExpressionText);

			//evaluate regular express for a match;
			Match match = regularExpression.Match(target);
			if(match.Success)
			{
				isMatch = true;
			}
			else
			{
				isMatch = false;
			}
			return isMatch;
		}

		/// <summary>
		///   Evaluates this instance.
		/// </summary>
		/// <returns> </returns>
		public override Result Render()
		{
			IsValid = MatchRegularExpression();
			return Result = new Result(this);
		}
	}
}