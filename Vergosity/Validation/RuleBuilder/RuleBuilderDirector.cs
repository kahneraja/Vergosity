namespace Vergosity.Validation.RuleBuilder
{
	internal class RuleBuilderDirector
	{
		private RuleBuilderBase builder;
		private Builders builders = new Builders();

		/// <summary>
		///   Gets or sets the builders.
		/// </summary>
		/// <value> The builders. </value>
		public Builders Builders
		{
			get
			{
				return builders;
			}
			set
			{
				builders = value;
			}
		}

		/// <summary>
		///   Defines the builder.
		/// </summary>
		/// <param name="builder"> The builder. </param>
		public void DefineBuilder(RuleBuilderBase builder)
		{
			this.builder = builder;
		}

		/// <summary>
		///   Creates the rules.
		/// </summary>
		public void CreateRules()
		{
			builder.CreateRules();
		}

		/// <summary>
		///   Retrieves the rules.
		/// </summary>
		/// <returns> </returns>
		public RuleList RetrieveRules()
		{
			return builder.RetrieveRules();
		}
	}
}