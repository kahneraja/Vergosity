#region

using System;
using System.Collections.Generic;

#endregion

namespace Vergosity.Actions
{
	/// <summary>
	///     Use to define a list of roles associated to a specified business
	///     action class.
	/// </summary>
	public class ActionRolesAttribute : Attribute
	{
		private readonly List<string> roles = new List<string>();

		/// <summary>
		///     Initializes a new instance of the <see cref="ActionRolesAttribute" /> class.
		/// </summary>
		/// <param name="roleList">The role list.</param>
		/// <exception cref="System.ArgumentException">roleList</exception>
		public ActionRolesAttribute(string roleList)
		{
			if (string.IsNullOrEmpty(roleList))
			{
				throw new ArgumentException("roleList");
			}
			string[] source = roleList.Split(',');
			foreach (string role in source)
			{
				if (!string.IsNullOrEmpty(role))
				{
					this.Roles.Add(role.Trim());
				}
			}
		}

		/// <summary>
		///     Gets or sets the roles.
		/// </summary>
		/// <value>
		///     The roles.
		/// </value>
		public List<string> Roles
		{
			get
			{
				return roles;
			}
		}
	}
}