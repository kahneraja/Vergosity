using System;
using NUnit.Framework;

namespace Vergosity.Framework.Tests.Validation
{
    [TestFixture]
    public class ActionTests
    {
        /// <summary>
        ///     Determines whether this instance [can run action validation].
        /// </summary>
        [Test]
        public void CanRunActionValidation()
        {
            var action = new TestAction("matt", DateTime.Now);
            action.Execute();
            Assert.IsFalse(action.ValidationContext.IsValid);
        }
    }
}