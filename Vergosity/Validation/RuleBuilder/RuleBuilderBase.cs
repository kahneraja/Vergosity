namespace Vergosity.Validation.RuleBuilder
{
	internal abstract class RuleBuilderBase
	{
		private readonly RuleBuilderSource source;
		private RuleList rules;

		/// <summary>
		///   Initializes a new instance of the <see cref="RuleBuilderBase" /> class.
		/// </summary>
		/// <param name="source"> The source. </param>
		protected RuleBuilderBase(RuleBuilderSource source)
		{
			this.source = source;
		}

		/// <summary>
		///   Creates the rules.
		/// </summary>
		public void CreateRules()
		{
			rules = source.BuildRules();
		}

		/// <summary>
		///   Retrieves the rules.
		/// </summary>
		/// <returns> </returns>
		public RuleList RetrieveRules()
		{
			return rules;
		}
	}
}