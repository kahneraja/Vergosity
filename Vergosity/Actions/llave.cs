namespace Vergosity.Actions
{
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	internal sealed class llave
	{
		private string elLlave = string.Empty;
		private readonly bool haskey;

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public string __llave
		{
			get
			{
				return elLlave;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="llave"/> class.
		/// </summary>
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public llave()
		{
			this.elLlave = Vergosity.Properties.Resources.PublicKey;
			if(!string.IsNullOrWhiteSpace(this.elLlave))
			{
				this.haskey = true;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="llave"/> is haskey.
		/// </summary>
		/// <value>
		///   <c>true</c> if haskey; otherwise, <c>false</c>.
		/// </value>
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public bool Haskey
		{
			get
			{
				return haskey;
			}
		}
	}
}