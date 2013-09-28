#region

using System;
using System.Linq;
using Vergosity.Actions;

#endregion

namespace Vergosity.Framework.Tests.Action
{
	[ActionRoles("Boss,Manager,Admin,")]
	internal class ActionWithRoles : Actions.Action
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="ActionWithRoles" /> class.
		/// </summary>
		public ActionWithRoles()
		{
			
		}

		protected override void Authorize()
		{
            //this.Roles = this.InitializeRoles(this);
            //base.Authorize();
            //this.IsAuthorized = this.Roles.Count > 0;

		    string role = "Dude";
            this.Roles = this.InitializeRoles(this);
		    var r = (from item in this.Roles
		             where item.ToLower() == role.ToLower()
		             select item).FirstOrDefault();

            Console.WriteLine("Role: {0}", r);
		    if (string.IsNullOrEmpty(r))// no match found; cannot allow/authorize;
		    {
		        this.IsAuthorized = false;
		    }
		}
	}
}