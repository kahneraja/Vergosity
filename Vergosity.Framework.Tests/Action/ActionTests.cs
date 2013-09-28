#region

using System;
using NUnit.Framework;
using Vergosity.Validation;

#endregion

namespace Vergosity.Framework.Tests.Action
{
	[TestFixture]
	public class ActionTests
	{
		/// <summary>
		///     Determines whether this instance [can retrieve action roles].
		/// </summary>
		[Test]
		public void CanRetrieveActionRoles()
		{
			ActionWithRoles action = new ActionWithRoles();
			action.ValidationContext = new ValidationContext();
			action.Execute();

			foreach (var role in action.Roles)
				Console.WriteLine(role);
		}
	}
}